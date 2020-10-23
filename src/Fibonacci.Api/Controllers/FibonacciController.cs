using System.Collections.Generic;
using System.Linq;
using Fibonacci.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fibonacci.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class FibonacciController : ControllerBase
    {
        private readonly ILogger<FibonacciController> _logger;
        private readonly IFibonacciGenerator _fibonacci;

        public FibonacciController(ILogger<FibonacciController> logger, IFibonacciGenerator fibonacci)
        {
            _logger = logger;
            _fibonacci = fibonacci;
        }

        [HttpGet("{count:int}")]
        public IActionResult Get(int count) 
        {
            _logger.LogInformation("Requesting {count} items", count);
            var sequence = _fibonacci.GetSequence().Take(count);
            return Ok(_fibonacci.GetSequence().Take(count));
        }

        [HttpGet("lessthan/{max:int}")]
        public IActionResult GetLessThan(int max) 
        {
            _logger.LogInformation("Requesting sequence limited to {max}", max);
            var sequence = _fibonacci.GetSequence().TakeWhile(n => n < max);
            return Ok(sequence);
        }

        [HttpGet("nth/{index:int}")]
        public IActionResult GetNth(int index)
        {
            _logger.LogInformation("Requesting number at index {index}", index);
            var number = _fibonacci
                .GetSequence()
                .Skip(index)
                .First();

            return Ok(number);
        }
    }
}