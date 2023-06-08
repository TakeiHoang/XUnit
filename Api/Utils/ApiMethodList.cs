using Account;
using Core.Ultilities.Api;
using Core.Ultilities.Model;
using ListResources;
using ListUsers;
using Newtonsoft.Json;
using SingleResource;
using SingleUser;
using System.Text;
using User;

namespace Api.Utils
{
    public class ApiMethodList : BaseApi
    {
        #region Get Method
        /// <summary>
        /// Get list of user 
        /// </summary>
        /// <param name="pageNo"> Page number </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return list of users info </returns>
        public async Task<ListUsersModel> GetListOfUsers<T>(int pageNo, int delay = 0,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var response = await SendRequest<ListUsersModel>(HttpMethod.Get, getListUsersOnpageEndpoint + pageNo,
                expectedStatus: expectedStatus);
            return response;
        }

        /// <summary>
        /// Get list of user delayed
        /// </summary>
        /// <param name="pageNo"> Page number </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return list of users info </returns>
        public async Task<ListUsersModel> GetListOfUsersDelayed<T>(int delay = 3,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var response = await SendRequest<ListUsersModel>(HttpMethod.Get, createUser + $"?delay={delay}",
                expectedStatus: expectedStatus);
            return response;
        }

        /// <summary>
        /// Get single user
        /// </summary>
        /// <param name="userId"> User ID </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return single user info </returns>
        public async Task<SingleUserModel> GetSingleUser<T>(int userId,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var response = await SendRequest<SingleUserModel>(HttpMethod.Get, getSingleUserEndpoint + userId,
                expectedStatus: expectedStatus);
            return response;
        }

        /// <summary>
        /// Get list of resources
        /// </summary>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return list of resources info </returns>
        public async Task<ListResourcesModel> GetListOfResources<T>(
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var response = await SendRequest<ListResourcesModel>(HttpMethod.Get, getListResourceEndpoint,
                expectedStatus: expectedStatus);
            return response;
        }

        /// <summary>
        /// Get single resource
        /// </summary>
        /// <param name="resourceId"> Resource ID </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return single resource info </returns>
        public async Task<SingleResourceModel> GetSingleResource<T>(int resourceId,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var response = await SendRequest<SingleResourceModel>(HttpMethod.Get, getSingleResourceEndpoint + resourceId,
                expectedStatus: expectedStatus);
            return response;
        }
        #endregion

        #region POST Method
        /// <summary>
        /// Create new user with POST
        /// </summary>
        /// <param name="name"> User name </param>
        /// <param name="job"> User job </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return user created info </returns>
        public async Task<UserResultModel> CreateUser<T>(string name, string job,
            HttpStatusCode expectedStatus = HttpStatusCode.Created)
        {
            var user = new UserModel
            {
                Name = name,
                Job = job
            };

            string parseToJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(parseToJson, Encoding.UTF8, "application/json");
            var response = await SendRequest<UserResultModel>(HttpMethod.Post, createUser, content,
                expectedStatus: expectedStatus);
            return response;
        }

        /// <summary>
        /// Register account
        /// </summary>
        /// <param name="email"> Email </param>
        /// <param name="password"> Password </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return user created info </returns>
        public async Task<AccountResultModel> RegisterAccount<T>(string email, string password,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var account = new AccountModel 
            { 
                Email = email, 
                Password = password 
            };

            string parseToJson = JsonConvert.SerializeObject(account);
            HttpContent content = new StringContent(parseToJson, Encoding.UTF8, "application/json");
            var response = await SendRequest<AccountResultModel>(HttpMethod.Post, registerAccount, content,
                expectedStatus: expectedStatus);
            return response;
        }

        /// <summary>
        /// Login account
        /// </summary>
        /// <param name="email"> Email </param>
        /// <param name="password"> Password </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return user created info </returns>
        public async Task<AccountResultModel> LoginAccount<T>(string email, string password,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var account = new AccountModel
            {
                Email = email,
                Password = password
            };

            string parseToJson = JsonConvert.SerializeObject(account);
            HttpContent content = new StringContent(parseToJson, Encoding.UTF8, "application/json");
            var response = await SendRequest<AccountResultModel>(HttpMethod.Post, registerAccount, content,
                expectedStatus: expectedStatus);
            return response;
        }
        #endregion

        #region PUT Method
        /// <summary>
        /// Update user with PUT base on userId
        /// </summary>
        /// <param name="name"> User name </param>
        /// <param name="job"> User job </param>
        /// <param name="userId"> User ID </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return user updated / created info </returns>
        public async Task<UserResultModel> PutUser<T>(string name, string job, int userId,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var user = new UserModel
            {
                Name = name,
                Job = job
            };

            string parseToJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(parseToJson, Encoding.UTF8, "application/json");
            var response = await SendRequest<UserResultModel>(HttpMethod.Put,
                getSingleUserEndpoint + userId,
                content, expectedStatus: expectedStatus);
            return response;
        }
        #endregion

        #region PATCH Method
        /// <summary>
        /// Update user with PATCH base on userId
        /// </summary>
        /// <param name="name"> User name </param>
        /// <param name="job"> User job </param>
        /// <param name="userId"> User ID </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Return user updated info </returns>
        public async Task<UserResultModel> PatchUser<T>(string name, string job, int userId,
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            var user = new UserModel
            {
                Name = name,
                Job = job
            };

            string parseToJson = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(parseToJson, Encoding.UTF8, "application/json");
            var response = await SendRequest<UserResultModel>(HttpMethod.Patch,
                getSingleUserEndpoint + userId, content,
                expectedStatus: expectedStatus);
            return response;
        }
        #endregion

        #region DELETE Method
        /// <summary>
        /// Delete user base on userId
        /// </summary>
        /// <param name="userId"> User ID </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns></returns>
        public async Task<UserResultModel> DeleteUser<T>(int userId,
            HttpStatusCode expectedStatus = HttpStatusCode.NoContent)
        {
            var response = await SendRequest<UserResultModel>(HttpMethod.Delete,
                getSingleUserEndpoint + userId,
                expectedStatus: expectedStatus);
            return response;
        }
        #endregion
    }
}