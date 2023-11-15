using Microsoft.AspNetCore.Http;

namespace Akcay.Application.Common.Interfaces;

public interface IFileService
{
    public string UploadPhoto(IFormFile file,string directory);
}