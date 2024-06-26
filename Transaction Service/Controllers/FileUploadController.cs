using Microsoft.AspNetCore.Mvc;
using Transaction_Service.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly FileUploadService _fileUploadService;

    public FileUploadController(FileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Please select a valid file.");
        }

        try
        {
            var result = await _fileUploadService.UploadFileAsync(file);
            if (!result.Success)
            {
                return BadRequest(result.ErrorMessages);
            }
            return Ok();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
