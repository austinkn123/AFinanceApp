using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using AppLibrary.Models.User;
using AppLibrary.UseCases.Users;
using Google.Apis.Auth;
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

            var confirmRequest = new AdminConfirmSignUpRequest
            {
                UserPoolId = _userPool.PoolID,
                Username = model.User_Name
            };
            await _cognitoIdentityProvider.AdminConfirmSignUpAsync(confirmRequest);


            // Store user in the database
            model.Cognito_User_Id = Guid.Parse(signUpResponse.UserSub);
            

            await signUpUser.Execute(model);

            
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            var secretHash = ComputeSecretHash(_userPool.ClientID, model.User_Name, _clientSecret);

            var authRequest = new AdminInitiateAuthRequest
            {
                UserPoolId = _userPool.PoolID,
                ClientId = _userPool.ClientID,
                AuthFlow = AuthFlowType.ADMIN_USER_PASSWORD_AUTH,
                AuthParameters = new Dictionary<string, string>
                {
                    { "USERNAME", model.User_Name },
                    { "PASSWORD", model.Password },
                    { "SECRET_HASH", secretHash }
                }
            };

            try
            {
                var authResponse = await _cognitoIdentityProvider.AdminInitiateAuthAsync(authRequest);
                return Ok(new { Token = authResponse.AuthenticationResult.AccessToken });
            }
            catch (AmazonCognitoIdentityProviderException ex) when (ex.ErrorCode == "NotAuthorizedException")
            {
                return Unauthorized("Invalid username or password.");
            }
            catch (AmazonCognitoIdentityProviderException ex) when (ex.ErrorCode == "InvalidParameterException")
            {
                return BadRequest("Invalid parameters provided.");
            }
            catch (AmazonCognitoIdentityProviderException ex)
            {
                _logger.LogError(ex, "Cognito error during login: {ErrorCode}, {ErrorMessage}", ex.ErrorCode, ex.Message);
                return StatusCode(500, $"Authentication error: {ex.ErrorCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred during login.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] UserToken model)
        {
            var globalSignOutRequest = new GlobalSignOutRequest
            {
                AccessToken = model.Token
            };

            try
            {
                var response = await _cognitoIdentityProvider.GlobalSignOutAsync(globalSignOutRequest);
                _logger.LogInformation("Logout successful for token: {Token}", model.Token);
                return Ok("User logged out successfully.");
            }
            catch (NotAuthorizedException ex)
            {
                _logger.LogError(ex, "Invalid access token: {Token}", model.Token);
                return Unauthorized("Invalid access token.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during logout.");
                return StatusCode(500, "Internal server error.");
            }
        }

        //[HttpPost("google-sign-up")]
        //public async Task<IActionResult> GoogleSignUp([FromBody] string idToken, [FromServices] SignUpUser signUpUser)
        //{
        //    var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
        //    var user = new User
        //    {
        //        User_Name = payload.Email,
        //        Email = payload.Email,
        //        First_Name = payload.GivenName,
        //        Last_Name = payload.FamilyName,
        //        Cognito_User_Id = Guid.NewGuid() // Generate a new GUID for the user
        //    };

        //    await signUpUser.Execute(user);
        //    return Ok();
        //}

        //[HttpPost("google-login")]
        //public async Task<IActionResult> GoogleLogin([FromBody] string idToken)
        //{
        //    var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
        //    var secretHash = ComputeSecretHash(_userPool.ClientID, payload.Email, _clientSecret);

        //    var authRequest = new AdminInitiateAuthRequest
        //    {
        //        UserPoolId = _userPool.PoolID,
        //        ClientId = _userPool.ClientID,
        //        AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
        //        AuthParameters = new Dictionary<string, string>
        //        {
        //            { "USERNAME", payload.Email },
        //            { "SECRET_HASH", secretHash }
        //        }
        //    };

        //    try
        //    {
        //        var authResponse = await _cognitoIdentityProvider.AdminInitiateAuthAsync(authRequest);
        //        return Ok(new { Token = authResponse.AuthenticationResult.AccessToken });
        //    }
        //    catch (AmazonCognitoIdentityProviderException ex) when (ex.ErrorCode == "NotAuthorizedException")
        //    {
        //        return Unauthorized("Invalid username or password.");
        //    }
        //    catch (AmazonCognitoIdentityProviderException ex) when (ex.ErrorCode == "InvalidParameterException")
        //    {
        //        return BadRequest("Invalid parameters provided.");
        //    }
        //    catch (AmazonCognitoIdentityProviderException ex)
        //    {
        //        _logger.LogError(ex, "Cognito error during login: {ErrorCode}, {ErrorMessage}", ex.ErrorCode, ex.Message);
        //        return StatusCode(500, $"Authentication error: {ex.ErrorCode}");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An unexpected error occurred during login.");
        //        return StatusCode(500, "Internal server error.");
        //    }
        //}


        private string ComputeSecretHash(string clientId, string userName, string clientSecret)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(clientSecret)))
            {
                var data = Encoding.UTF8.GetBytes(userName + clientId);
                var hash = hmac.ComputeHash(data);
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
