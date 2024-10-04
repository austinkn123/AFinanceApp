using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using AppLibrary.IRepositories;
using AppLibrary.Models;
using AppLibrary.Repositories;
using AppLibrary.UseCases.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace MyFianceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IAmazonCognitoIdentityProvider _cognitoIdentityProvider;
        private readonly CognitoUserPool _userPool;
        private readonly ILogger<UsersController> _logger;
        private readonly string _clientSecret;

        public UsersController(
            ILogger<UsersController> logger,
            IAmazonCognitoIdentityProvider cognitoIdentityProvider,
            IOptions<AwsCognitoSettings> awsCognitoSettings)
        {
            _logger = logger;
            _cognitoIdentityProvider = cognitoIdentityProvider;
            var settings = awsCognitoSettings.Value;
            _userPool = new CognitoUserPool(settings.UserPoolId, settings.ClientId, _cognitoIdentityProvider, settings.ClientSecret);
            _clientSecret = settings.ClientSecret; // Store the client secret
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromServices] GetAllUsers getAllUsers)
            => Ok(await getAllUsers.Execute());

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] User model, [FromServices] SignUpUser signUpUser)
        {
            var secretHash = ComputeSecretHash(_userPool.ClientID, model.User_Name, _clientSecret);

            var signUpRequest = new SignUpRequest
            {
                ClientId = _userPool.ClientID,
                Username = model.User_Name,
                Password = model.Password,
                SecretHash = secretHash,
                UserAttributes = new List<AttributeType>
                {
                    new AttributeType { Name = "email", Value = model.Email },
                    new AttributeType { Name = "given_name", Value = model.First_Name },
                    new AttributeType { Name = "family_name", Value = model.Last_Name },
                    new AttributeType { Name = "name", Value = $"{model.First_Name} {model.Last_Name}" }
                }
            };

            var signUpResponse = await _cognitoIdentityProvider.SignUpAsync(signUpRequest);

            
            // Store user in the database
            model.Cognito_User_Id = Guid.Parse(signUpResponse.UserSub);
            

            await signUpUser.Execute(model);
            return Ok();
        }

        private string ComputeSecretHash(string clientId, string username, string clientSecret)
        {
            var message = Encoding.UTF8.GetBytes(username + clientId);
            var key = Encoding.UTF8.GetBytes(clientSecret);

            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(message);
                return Convert.ToBase64String(hash);
            }
        }

        //[HttpGet("get-user/{id}")]
        //public async Task<IActionResult> Get([FromRoute] int id)
        //{
        //    var user = await _userRepository.GetById(id);
        //    return Ok(user);
        //}

        //[HttpPost("add-user")]
        //public async Task<IActionResult> AddUser([FromBody] User model)
        //{
        //    await _userRepository.AddUser(model);
        //    return Ok();
        //}

        //[HttpDelete("delete-user/{id}")]
        //public async Task<IActionResult> DeleteUser([FromRoute] int id)
        //{
        //    await _userRepository.DeleteUser(id);
        //    return Ok();
        //}

        //[HttpPatch("update-user")]
        //public async Task<IActionResult> UpdateUser([FromBody] User model)
        //{
        //    await _userRepository.UpdateUser(model);
        //    return Ok();
        //}
    }
}
