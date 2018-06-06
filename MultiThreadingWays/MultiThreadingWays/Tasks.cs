using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingWays
{
    public class TasksExample01
    {
        public void AddTwoNumbers(int n1, int n2)
        {
            var task = new Task<int>(this.AddTwoNumbersBackGround, new Tuple<int, int>(n1, n2));
            task.ContinueWith(WriteTaskResultToConsole);
            task.Start();
        }

        private int AddTwoNumbersBackGround(object numbersTuple)
        {
            var result = 0;

            if (numbersTuple is Tuple<int, int> numbers)
            {
                result = numbers.Item1 + numbers.Item2;
                Thread.Sleep(8000);
            }

            return result;
        }

        private void WriteTaskResultToConsole(Task<int> previousTask)
        {
            Console.WriteLine($"Result: {previousTask.Result.ToString()}");
        }
    }

    public class TasksExample02
    {
        public void AddTwoNumbers(int n1, int n2)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                int result = AddTwoNumbersBackGround(new Tuple<int, int>(n1, n2));
                WriteToConsole(result);
            });
        }

        private int AddTwoNumbersBackGround(Tuple<int, int> numbersTuple)
        {
            var result = 0;

            if (numbersTuple is Tuple<int, int> numbers)
            {
                result = numbers.Item1 + numbers.Item2;
                Thread.Sleep(10000);
            }

            return result;
        }

        private void WriteToConsole(int result)
        {
            Console.WriteLine($"Result: {result}");
        }
    }
}
