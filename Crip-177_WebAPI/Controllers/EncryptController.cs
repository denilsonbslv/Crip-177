using Crip_177_WebAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace Crip_177_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncryptController : ControllerBase
    {
        private readonly IEncryptionService _encryptionService;

        public EncryptController(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        [HttpPost]
        public ActionResult<string> EncryptText([FromBody] JsonElement payload)
        {
            string inputText;
            try
            {
                inputText = payload.GetProperty("inputText").GetString();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest(new { message = "The inputText field is required." });
            }

            string encryptedText = _encryptionService.Encrypt(inputText);
            return Ok(encryptedText);
        }
    }
}
