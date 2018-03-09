using Basil.Domain.Repositories;
using Basil.User.Core.IRepositories;
using Basil.User.Core.Model;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Basil.Util.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basil.User.IdentityServer.SpecialService {
    public class ProfileService : IProfileService {
        //services
        private readonly IUserRepository _userRepository;
        private readonly ICacher _cacher;

        public ProfileService(IUserRepository userRepository, ICacher cacher) {
            _userRepository = userRepository;
            _cacher = cacher;
        }
        //Get user profile date in terms of claims when calling /connect/userinfo
        public async Task GetProfileDataAsync(ProfileDataRequestContext context) {
            if (!string.IsNullOrEmpty(context.Subject.Identity.Name)) {
                m_User user = await _userRepository.FirstOrDefaultAsync(a => a.Name == context.Subject.Identity.Name);

                if (user != null) {
                    var claims = ResourceOwnerPasswordValidator.GetUserClaims(user);
                    context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                }
            }
            else {
                //get subject from context (this was set ResourceOwnerPasswordValidator.ValidateAsync),
                //where and subject was set to my user id.
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

                if (!string.IsNullOrEmpty(userId?.Value) && int.Parse(userId.Value) > 0) {
                    //get user from db (find user by user id)
                    var user = _userRepository.Get(int.Parse(userId.Value));

                    // issue the claims for the user
                    if (user != null) {
                        var claims = ResourceOwnerPasswordValidator.GetUserClaims(user);

                        context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                    }
                }
            }
        }
        //check if user account is active.
        public async Task IsActiveAsync(IsActiveContext context) {
            //get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id");

            if (!string.IsNullOrEmpty(userId?.Value) && int.Parse(userId.Value) > 0) {
                var user = await _userRepository.GetAsync(int.Parse(userId.Value));

                if (user != null) {
                    if (user.Enabled) {
                        context.IsActive = user.Enabled;
                    }
                }
            }
        }
    }
}