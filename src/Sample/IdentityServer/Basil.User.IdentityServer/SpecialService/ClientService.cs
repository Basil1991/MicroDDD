using Basil.User.Core.IRepositories;
using Basil.User.Core.Model;
using DotNetCore.CAP;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Basil.Util.Cache;
using Basil.Util.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basil.User.IdentityServer.SpecialService {
    public class ClientService : IClientStore {
        private IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository) {
            this.clientRepository = clientRepository;
        }

        public async Task<Client> FindClientByIdAsync(string clientId) {
            var clientModel = await Task.Run(() => clientRepository.GetAllIncludingFromCacheAside(a=>a.m_ClientScopes).Where(a => a.Name == clientId).FirstOrDefault());
            return getClient(clientModel);
        }

        private Client getClient(m_Client model) {
            var client = new Client();
            client.ClientId = model.Name;
            client.ClientSecrets = new List<Secret> {
                new Secret(model.Password)
            };
            client.AllowedScopes = model.m_ClientScopes.Select(a => a.Scope).ToList();
            client.AllowedGrantTypes = getGrantTypes(model.AllowedGrantTypes);

            return client;
        }

        private ICollection<string> getGrantTypes(string grant) {
            switch (grant) {
                case "ClientCredentials":
                    return GrantTypes.ClientCredentials;
                case "ResourceOwnerPassword":
                    return GrantTypes.ResourceOwnerPassword;
                default: throw new ArgumentException(grant);
            }
        }
    }
}
