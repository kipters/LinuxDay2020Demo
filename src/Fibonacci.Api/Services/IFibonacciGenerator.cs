using System.Collections.Generic;

namespace Fibonacci.Api.Services
{
    public interface IFibonacciGenerator
    {
        IEnumerable<long> GetSequence();
    }
}