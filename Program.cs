﻿using net_core_regex.Models;
using System;

namespace net_core_regex
{
    class Program
    {

        private static FilterWithRegex regex_1;
        private static FilterWithRegex regex_2;

        static void Main(string[] args)
        {
            CreateRegex();
            ShowResults();
        }


        private static void CreateRegex()
        {
            regex_1 = new("<my-email@gmail.com>");
            regex_2 = new("MyPassword123456+*");
        }

        private static void ShowResults()
        {
            Console.WriteLine(regex_1.WithinTwoValues("<", ">"));

            Console.WriteLine(regex_2.Password(new Mpassword
            {
                UpperCase = true,
                LowerCase = true,
                Number = true,
                SpecialCharacter = true,
                Longitude = new Mlongitude
                {
                    Start = 6,
                    End = 20
                }

            }));
        }


    }
}
