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

    [HttpGet("{times}", Name = "GetFibonacci")]
    public IEnumerable<dynamic> Get(long times)
    {
        var isFizzBuzz = 15;
        var isBuzz = 5;
        var isFizz = 3;
        var startIndex = 1;

        for (int i = startIndex; i <= times; i++)
        {
            if (i % isFizzBuzz == 0)
            {
                FizzBuzzResult.Add("FizzBuzz");
                continue;
            }
            else if (i % isBuzz == 0)
            {
                FizzBuzzResult.Add("Buzz");
                continue;
            }
            else if (i % isFizz == 0)
            {
                FizzBuzzResult.Add("Fizz");
                continue;
            }
            else
            {
                FizzBuzzResult.Add(i);
            }
        }

        return Enumerable.Range(1, 1).Select(index => new Fibonacci(0)
        {
            Result = FizzBuzzResult
        })
        .ToArray();
    }
}