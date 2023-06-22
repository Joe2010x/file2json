using Microsoft.AspNetCore.Mvc;
using cwproj.Services;
using cwproj.Models;

namespace cwproj.Controllers;

public class HealthCheckRequest
{
    public bool? CheckMoreStuff { get; set; }
}

public class HealthCheckResponse
{
    public string? Message { get; set; }
}

[ApiController]
[Route("[controller]/[action]")]
public class NelfoUploadController : ControllerBase
{
    private readonly ILogger<NelfoUploadController> _logger;

    private readonly IFileReader _fileReader;

    public NelfoUploadController(ILogger<NelfoUploadController> logger,
    IFileReader fileReader)
    {
        _logger = logger;
        _fileReader = fileReader;
    }

    [HttpPost]
    public HealthCheckResponse HealthCheck(HealthCheckRequest? req)
    {
        _logger.LogInformation($"HealthCheck: {req?.CheckMoreStuff??false}");

        return new HealthCheckResponse()
        {
            Message = "OK"
        };
    }

    [HttpGet("[action]")]
    public List<List<string>> FileToJson ()
    {

       return _fileReader.GetLinesOfWords();
    }
}
