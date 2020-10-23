using System.Collections.Generic;

namespace Fibonacci.Api.Services
{
    public class FibonacciGenerator : IFibonacciGenerator
    {
        public IEnumerable<long> GetSequence()
        {
            var old = 0L;
            var older = 1L;
            var sum = 0L;

            while (true)
            {
                sum = old + older;
                older = old;
                old = sum;

                yield return sum;
            }
        }
    }
}