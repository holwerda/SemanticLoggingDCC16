using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC16_Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo3EventSource.Log.ApplicationStart();

            var createEvent = true;

            do
            {

                Console.WriteLine("Please select an Event from 1-4, or type X to Exit");
                var input = Console.ReadKey();
                Console.WriteLine("");

                switch (input.KeyChar)
                {
                    case '1':
                        Demo3EventSource.Log.Event1WasSelected("Hello World");
                        break;
                    case '2':
                        Demo3EventSource.Log.Event2GetById(123);
                        break;
                    case '3':
                        Demo3EventSource.Log.Event3SuperPowersActivated(123, "Clark", "Kent");
                        break;
                    case '4':
                        var ex = new Exception("Error Saving World");
                        Demo3EventSource.Log.Event4Error(123, ex.GetBaseException().ToString());
                        break;
                    case 'X':
                    case 'x':
                        createEvent = false;
                        Demo3EventSource.Log.ApplicationExit();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection. Try Again.");
                        break;
                }

            } while (createEvent);

            

        }
    }
}
