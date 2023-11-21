using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;

public class Logo
{
    [Function("GetLogo")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "logo.png")] HttpRequestData req)
    {
        // Return logo.png that's in the root of the project
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "image/png");

        var logo = System.IO.File.ReadAllBytes("logo.png");
        response.Body.Write(logo);

        return response;
    }
}