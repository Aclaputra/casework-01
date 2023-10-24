using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FibonacciController : ControllerBase
{
    private readonly ILogger<FibonacciController> _logger;

    public FibonacciController(ILogger<FibonacciController> logger)
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
        var even = 0;

        for (int i = startIndex; i <= times; i++)
        {
            if (i % isFizzBuzz == even)
            {
                FizzBuzzResult.Add("FizzBuzz");
            }
            else if (i % isBuzz == even)
            {
                FizzBuzzResult.Add("Buzz");
            }
            else if (i % isFizz == even)
            {
                FizzBuzzResult.Add("Fizz");
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