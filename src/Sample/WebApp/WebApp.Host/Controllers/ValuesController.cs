using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Host.Controllers {
    /// <summary>
    /// 获取所有信息
    /// </summary>
    /// <returns></returns>
    [Route("webapp/[controller]/[action]")]
    public class ValuesController : Controller {
        /// <summary>
        /// 获取测试Client Bearer Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetClientToken() {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (disco.IsError) {
                return disco.Error;
            }
            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api");

            if (tokenResponse.IsError) {
                return tokenResponse.Error;
            }
            return tokenResponse.AccessToken;
        }

        /// <summary>
        /// 获取测试Client ResourceOwner Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetRoClientToken() {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (disco.IsError) {
                return disco.Error;
            }
            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("Basil", "123456", "api");

            if (tokenResponse.IsError) {
                return tokenResponse.Error;
            }
            return tokenResponse.AccessToken;
        }

    }
}
