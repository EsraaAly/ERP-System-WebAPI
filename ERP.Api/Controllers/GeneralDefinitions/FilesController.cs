using ERP.Api.Constants;
using ERP.Api.Controllers.Base;
using ERP.Application.Common.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.GeneralDefinitions
{
    [ApiVersion("1.0")]
    public class FilesController : BaseController
    {
        private readonly IFileStorageService _fileStorageService;

        public FilesController(IMediator mediator, IFileStorageService fileStorageService) : base(mediator)
        {
            _fileStorageService = fileStorageService;
        }

        [HttpGet(ApiRoutes.GeneralDefinitions.Files.OpenFile + "/{folder}/{fileName}")]
        public async Task<IActionResult> OpenFile(string folder, string fileName)
        {
            var stream = await _fileStorageService.OpenFileAsync(folder, fileName);

            if (stream == null)
                return NotFound("File not found.");

            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(stream, contentType, fileName);
        }

        [HttpDelete(ApiRoutes.GeneralDefinitions.Files.DeleteFile + "/{folder}/{fileName}")]
        public async Task<IActionResult> DeleteFile(string folder, string fileName)
        {
            var result = await _fileStorageService.DeleteFileAsync(folder, fileName);

            if (result)
                return Ok(new { message = "File deleted successfully" });

            return BadRequest("Failed to delete file or file not found.");
        }
    }
}
