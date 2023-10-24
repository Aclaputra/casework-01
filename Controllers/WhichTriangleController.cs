using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WhichTriangleController : ControllerBase
{
    private readonly ILogger<WhichTriangleController> _logger;

    public WhichTriangleController(ILogger<WhichTriangleController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{a}/{b}/{c}", Name = "GetTriangle")]
    public String Get(long a, long b, long c)
    {
        string? WhichTriangleResult;

        if ((a==b && a!=c) || (b==c && b!=a)) 
        {
            WhichTriangleResult = "Isoceles";
        } 
        else if (a!=b && a!=c) 
        {
            WhichTriangleResult = "Scalene";
        } 
        else if (a==b && b==c) 
        {
            WhichTriangleResult = "Equilateral";
        } 
        else 
        {
            WhichTriangleResult = "triangle type not found.";
        }

        return WhichTriangleResult;
    }

}