using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingWays
{
    public class AsyncAwaitExample1
    {

        public async void Calculate(int number1, int number2)
        {
            Console.WriteLine(@"Just before await call:");
            // While waiting for the result of AddTwoNumbers, the program continues with caller of Calculate.
            await AddTwoNumbers(number1, number2);
            Console.WriteLine(@"Just after await call:");
        }

        private Task<int> AddTwoNumbers(int number1, int number2)
        {
            Task<int> task = new Task<int>(this.AddTwoNumbersBackGround, new Tuple<int, int>(number1, number2));
            task.ContinueWith(this.WriteTaskResultToConsole);
            task.Start();

            return task;
        }

        private int AddTwoNumbersBackGround(object numbersTuple)
        {
            var result = 0;

            if (numbersTuple is Tuple<int, int> numbers)
            {
                result = numbers.Item1 + numbers.Item2;
                Thread.Sleep(12000);
            }

            return result;
        }

        private void WriteTaskResultToConsole(Task<int> previousTask)
        {
            Console.WriteLine($"Result: {previousTask.Result.ToString()}");
        }
    }

    public class AsyncAwaitExample2
    {

        public async void Calculate(int number1, int number2)
        {
            Console.WriteLine(@"Just before await call:");
            try
            {
                // While waiting for the result of AddTwoNumbers, the program continues with caller of Calculate.
                int x = await AddTwoNumbers(number1, number2);
            }
            catch (Exception ex)
            {
                ;
            }

            Console.WriteLine(@"Just after await call:");
        }

        private async Task<int> AddTwoNumbers(int number1, int number2)
        {
            Task<int> task = new Task<int>(this.AddTwoNumbersBackGround, new Tuple<int, int>(number1, number2));
            task.Start();

            try
            {
                await task;
            }
            catch (Exception ex)
            {
                if (task.IsFaulted)
                {
                    ;
                }
            }

            return task.Result;
        }

        private int AddTwoNumbersBackGround(object numbersTuple)
        {
            var result = 0;

            if (numbersTuple is Tuple<int, int> numbers)
            {
                result = numbers.Item1 + numbers.Item2;
                Thread.Sleep(12000);
                return 3 / (numbers.Item1 - numbers.Item1);
            }

            return result;
        }
    }

    public class AsyncAwaitExample3
    {

        public async void Calculate(int number1, int number2)
        {
            Console.WriteLine(@"Just before await call:");
            try
            {
                // While waiting for the result of AddTwoNumbers, the program continues with caller of Calculate.
                int x = await AddTwoNumbers(number1, number2);
            }
            catch (Exception ex)
            {
                ;
            }

            Console.WriteLine(@"Just after await call:");
        }

        private async Task<int> AddTwoNumbers(int number1, int number2)
        {
            Task<int> task = new Task<int>(this.AddTwoNumbersBackGround, new Tuple<int, int>(number1, number2));
            task.Start();

            try
            {
                await task;
            }
            catch (AggregateException ex)
            {
                ex.Handle((x) =>
                {
                    Console.WriteLine(@"EXCEPTION");
                    return true;
                });
            }

            return task.Result;
        }

        private int AddTwoNumbersBackGround(object numbersTuple)
        {
            var result = 0;

            if (numbersTuple is Tuple<int, int> numbers)
            {
                result = numbers.Item1 + numbers.Item2;
                Thread.Sleep(12000);
                return 3 / (numbers.Item1 - numbers.Item1);
            }

            return result;
        }
    }
}
