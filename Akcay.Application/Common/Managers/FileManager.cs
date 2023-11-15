using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Akcay.Application.Common.Managers;

public class FileManager : IFileService
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly ImageSetting _imageSetting;

    public FileManager(IHostingEnvironment hostingEnvironment, IOptions<ImageSetting> imageSetting)
    {
        _hostingEnvironment = hostingEnvironment;
        _imageSetting = imageSetting.Value;
    }

    public string UploadPhoto(IFormFile file, string directory)
    {
        string root = $"Images/{directory}/";
        string uploadFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", root);
        var currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        string imageHeaderKey = "";

        bool exists = Directory.Exists(uploadFolder);

        if (!exists)
            Directory.CreateDirectory(uploadFolder);

        if (file.Length <= 0) return "false";
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName).ToLower();
        var path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", root, fileName);
        
        using (var stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        if (currentEnvironment != null && currentEnvironment == "Development")
        {
            imageHeaderKey = _imageSetting.LocalKey;
        }
        else
        {
            imageHeaderKey = _imageSetting.HostKey;
        }

        var url = imageHeaderKey + Path.Combine(root, fileName);
        return url;
    }
}