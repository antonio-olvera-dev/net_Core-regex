using System;
using System.Text.RegularExpressions;
using net_core_regex.Models;

namespace net_core_regex
{
    public class FilterWithRegex
    {
        private String Content;

        public FilterWithRegex(String content) => this.Content = content;

        public String WithinTwoValues(String start, String end)
        {
            Regex regex = this.CreateRegex(pattern: $"(?<={start}).*?(?={end})");

            return regex.Match(Content).Value;
        }


        public String Password(Mpassword mPassword)
        {
            string pattern = this.CreatePatternPassword(mPassword);
            Regex regex = this.CreateRegex(pattern: pattern);

            return regex.Match(Content).Value;
        }

        public String Email()
        {
            string pattern = @"^(?=[a-z0-9._]+@[a-z]+\.[a-z]{2})[a-z0-9_.@]{10,30}$";
            Regex regex = this.CreateRegex(pattern: pattern);

            return regex.Match(Content).Value;
        }     

        public String Url()
        {
            string pattern = @"^https?:\/\/.*$";
            Regex regex = this.CreateRegex(pattern: pattern);

            return regex.Match(Content).Value;
        }


        private String CreatePatternPassword(Mpassword mPassword)
        {
            string newPattern = "";
            string startPattern = $"^[A-Za-z0-9+*]*";
            string endtPattern = $"[A-Za-z0-9+*]{{{mPassword.Longitude.Start},{mPassword.Longitude.End}}}$";

            newPattern += startPattern;
            newPattern += mPassword.LowerCase ? "(?=.*[a-z])+" : "";
            newPattern += mPassword.UpperCase ? "(?=.*[A-Z])+" : "";
            newPattern += mPassword.Number ? "(?=.*[0-9])+" : "";
            newPattern += mPassword.SpecialCharacter ? "(?=.*[+*])+" : "";
            newPattern += endtPattern;

            return newPattern;
        }

        private Regex CreateRegex(String pattern, RegexOptions regexOptions = RegexOptions.Multiline)
        {
            return new Regex(pattern, regexOptions);
        }
    }
}
