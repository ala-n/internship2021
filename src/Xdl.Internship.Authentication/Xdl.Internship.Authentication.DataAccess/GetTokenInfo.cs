using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Xdl.Internship.Authentication.DataAccess
{
    public class GetTokenInfo
    {
        public Dictionary<string, string> TokenData(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            string id = tokenS.Claims.First(claim => claim.Type == "nameid").Value;
            string firstName = tokenS.Claims.First(claim => claim.Type == "given_name").Value;
            string lastName = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
            string role = tokenS.Claims.First(claim => claim.Type == "role").Value;
            Dictionary<string, string> tokenInfo = new Dictionary<string, string>();
            tokenInfo.Add("id", id);
            tokenInfo.Add("firstName", firstName);
            tokenInfo.Add("lastName", lastName);
            tokenInfo.Add("role", role);
            return tokenInfo;
        }
    }
}
