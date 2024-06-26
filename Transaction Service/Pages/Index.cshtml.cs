using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Transaction_Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Transaction_Service.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FileUploadService _fileUploadService;

        public IndexModel(ILogger<IndexModel> logger, FileUploadService fileUploadService)
        {
            _logger = logger;
            _fileUploadService = fileUploadService;
        }

        public List<string> ErrorMessages { get; set; } = new List<string>();
        public bool UploadSuccess { get; set; }

        public void OnGet()
        {
            ErrorMessages.Clear();
            UploadSuccess = false;
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ErrorMessages.Add("Please select a file to upload.");
                return Page();
            }

            try
            {
                var result = await _fileUploadService.UploadFileAsync(file);
                if (!result.Success)
                {
                    ErrorMessages.AddRange(result.ErrorMessages);
                    return Page();
                }

                UploadSuccess = true;
                return Page();
            }
            catch (DuplicateReferenceException)
            {
                ErrorMessages.Add("Duplicate reference number found. Each reference number must be unique.");
                return Page();
            }
            catch (InvalidFileException)
            {
                ErrorMessages.Add("Invalid file format or structure. Please check your file and try again.");
                return Page();
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error uploading file: {ex.Message}");
                ErrorMessages.Add($"Error uploading file. Please select a valid file.");
                return Page();
            }
        }
    }
}
