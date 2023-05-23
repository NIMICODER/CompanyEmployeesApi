using CompanyEmployees.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{

    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service) => _service = service;

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            //var result = await _service.AuthenticationService.RegisterUser(userForRegistration);    
            //if (result.Succeeded)
            //{
            //    foreach(var error in result.Errors)
            //    {
            //        ModelState.TryAddModelError(error.Code, error.Description);
            //    }
            //    return BadRequest(ModelState);
            //}
            //return StatusCode(201);




            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded) return StatusCode(201);
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);

        }

    }

    //internal class ValidationFilterAttribute : Attribute, IAsyncActionFilter
    //{
    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        if (!context.ModelState.IsValid)
    //        {
    //            // If the model state is invalid, return a bad request response with the validation errors
    //            context.Result = new BadRequestObjectResult(context.ModelState);
    //            return;
    //        }

    //        if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
    //        {
    //            // If the Authorization header is missing, return a unauthorized response
    //            context.Result = new UnauthorizedResult();
    //            return;
    //        }

    //        string token = context.HttpContext.Request.Headers["Authorization"];

    //        // Validate the token against some authentication service
    //        bool isValidToken = ValidateToken(token);

    //        if (!isValidToken)
    //        {
    //            // If the token is invalid, return a unauthorized response
    //            context.Result = new UnauthorizedResult();
    //            return;
    //        }

    //        // If all validation checks pass, continue with the action execution
    //    }

    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        // Log the result of the action execution
    //        if (context.Result is ObjectResult objectResult)
    //        {
    //            Console.WriteLine($"Action executed with status code {objectResult.StatusCode}: {objectResult.Value}");
    //        }
    //    }

    //    private bool ValidateToken(string token)
    //    {
    //        // Placeholder authentication service method that returns true if the token is valid
    //        return token == "valid_token";
    //    }

    //    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}




    //public class AuthenticationController : ControllerBase
    //{
    //    private readonly ILoggerManager _logger;
    //    private readonly IMapper _mapper;
    //    private readonly UserManager<User> _userManager;
    //    public AuthenticationController(ILoggerManager logger, IMapper mapper,
    //   UserManager<User> userManager)
    //    {
    //        _logger = logger;
    //        _mapper = mapper;
    //        _userManager = userManager;
    //    }


    //    [HttpPost]
    //    //[ServiceFilter(typeof(ValidationFilterAttribute))]
    //    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    //    {
    //        var user = _mapper.Map<User>(userForRegistration);
    //        var result = await _userManager.CreateAsync(user, userForRegistration.Password);
    //        if (!result.Succeeded)
    //        {
    //            foreach (var error in result.Errors)
    //            {
    //                ModelState.TryAddModelError(error.Code, error.Description);
    //            }
    //            return BadRequest(ModelState);
    //        }
    //        await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
    //        return StatusCode(201);
    //    }
    //}

}
