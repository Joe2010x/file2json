using Microsoft.AspNetCore.Mvc;
using cwproj.Services;
using cwproj.Models;
using cwproject.Models;

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
    public Pricetilbud FileToJson ()
    {

       var lines = _fileReader.GetLinesOfWords();

       var rules_VHRecord = new List<Rule>();
        rules_VHRecord.Add(new Rule(1,"Must be","VH"));
        rules_VHRecord.Add(new Rule(2,"Must be","EFONELFO"));
        rules_VHRecord.Add(new Rule(3,"Must be","4.0"));
        rules_VHRecord.Add(new Rule(4,"Property","orgNo"));
        rules_VHRecord.Add(new Rule(11,"Property","orgName"));

        var ruleLine_VH = new RuleLine("VH",rules_VHRecord);

        var rules_VLRecord = new List<Rule>();
        rules_VLRecord.Add(new Rule(1,"Must be","VL"));
        rules_VLRecord.Add(new Rule(2,"Must be","1"));
        rules_VLRecord.Add(new Rule(3,"Property","productNo"));
        rules_VLRecord.Add(new Rule(4,"Property","description"));
        rules_VLRecord.Add(new Rule(7,"Property","priceUnit"));
        rules_VLRecord.Add(new Rule(9,"Property","price"));
        rules_VLRecord.Add(new Rule(10,"Property","quantity"));
        rules_VLRecord.Add(new Rule(17,"Property","stockProduct"));

        var ruleLine_VL = new RuleLine("VL",rules_VLRecord);

        var rules_VXRecord = new List<Rule>();
        rules_VXRecord.Add(new Rule(1,"Must be","VX"));
        rules_VXRecord.Add(new Rule(2,"Must be","VEKT"));
        rules_VXRecord.Add(new Rule(3,"Property","weight"));

        var ruleLine_VX = new RuleLine("VX", rules_VXRecord);

        var priceOffer = new Pricetilbud();

        for ( var i=0; i<lines.Count(); i++)
        {
            if (ruleLine_VH.isValid(lines[i])) 
                priceOffer.seller = new Seller(ruleLine_VH.produce<VHRecord>(lines[i]));

            if (ruleLine_VL.isValid(lines[i])) {
                priceOffer.addProduct(new Product(ruleLine_VL.produce<VLRecord>(lines[i])));
            }
            if (ruleLine_VX.isValid(lines[i])) 
                priceOffer.addWeight(ruleLine_VX.produce<VXRecord>(lines[i]));
        }
        return priceOffer;

    }
}
