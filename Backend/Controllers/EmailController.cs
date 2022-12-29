using EmailProject.Controllers.Validators;
using EmailProject.Controllers.DTO;
using EmailProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace EmailProject.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IEmailService _emailService;
        private readonly SaveEmailValidator _saveEmailValidator;
        private readonly IsEmailValid _isEmailValid;

        public EmailController(ILogger<EmailController> logger, IEmailService emailService, SaveEmailValidator saveEmailValidator, IsEmailValid isEmailValid)
		{
            _logger = logger;
            _emailService = emailService;
            _saveEmailValidator = saveEmailValidator;
            _isEmailValid = isEmailValid;
        }

        [HttpPost("send")]
        public IActionResult Send([FromBody]EmailDTO request)
        {
            try
            {
                _saveEmailValidator.ValidateAndThrow(request);
                _emailService.SaveEmail(request);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("history/{userEmail}")]
        public IActionResult GetHistory(string userEmail)
        {
            try
            {
                _isEmailValid.ValidateAndThrow(userEmail);
                var result = _emailService.GetEmails(userEmail);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
	}
}

