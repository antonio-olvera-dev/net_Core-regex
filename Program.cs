using System;

namespace net_core_regex
{
    class Program
    {
        static void Main(string[] args)
        {

            FilterWithRegex filterWithRegex = new("<my-email@gmail.com>");


            Console.WriteLine(filterWithRegex.WithinTwoValues("<", ">"));
        }






    }
}
