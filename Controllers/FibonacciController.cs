using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FibonacciController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public FibonacciController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // non nullable ?
    private static readonly List<dynamic> FizzBuzzResult = new List<dynamic>{};

    [HttpGet(Name = "GetFibonacci")]
    public IEnumerable<dynamic> Get()
    {
        for (int i=1; i<=100; i++) {
            if (i % 15 == 0) {
                FizzBuzzResult.Add("FizzBuzz");
                continue;
            } else if (i % 5 == 0) {
                FizzBuzzResult.Add("Buzz");
                continue;
            } else if (i % 3 == 0) {
                FizzBuzzResult.Add("Fizz");
                continue;
            } else {
                FizzBuzzResult.Add(i);
            }
        }
        return Enumerable.Range(1,1).Select(index => new Fibonacci(0) 
        {
            Result = FizzBuzzResult
        })
        .ToArray();
    }
}