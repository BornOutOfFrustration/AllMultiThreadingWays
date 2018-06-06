using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingWays
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateWithTask();
        }

        static void CalculateWithTask()
        {
            int number1 = 8;
            int number2 = 17;

            TasksExample01 tasksExample = new TasksExample01();
            tasksExample.AddTwoNumbers(number1, number2);

            TasksExample02 tasksExample02 = new TasksExample02();
            tasksExample02.AddTwoNumbers(number1 + 1, number2 + 1);


            AsyncAwaitExample1 asyncAwaitExample = new AsyncAwaitExample1();
            try
            {
                asyncAwaitExample.Calculate(number1 + 2, number2 + 2);
            }
            catch(Exception ex)
            {
                ;
            }

            AsyncAwaitExample2 asyncAwaitExample2 = new AsyncAwaitExample2();
            try
            {
                asyncAwaitExample2.Calculate(number1 + 3, number2 + 3);
            }
            catch (Exception ex)
            {
                ;
            }

            AsyncAwaitExample3 asyncAwaitExample3 = new AsyncAwaitExample3();
            try
            {
                asyncAwaitExample3.Calculate(number1 + 4, number2 + 4);
            }
            catch (Exception ex)
            {
                ;
            }


            Console.WriteLine(@"=====");
            Console.ReadLine();

        }
    }
}
