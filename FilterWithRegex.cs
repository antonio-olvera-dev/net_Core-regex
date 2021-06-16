using System;
using System.Text.RegularExpressions;
using net_core_regex.Models;

namespace net_core_regex
{

    /// <summary>
    /// The Class <c>FilterWithRegex</c> allows you to validate or filter the content of a String.
    /// <example>
    /// It is initialized as follows:
    /// <code>
    /// FilterWithRegex regex = new("Content to filter");
    /// </code>
    /// </example>
    /// </summary>
    public class FilterWithRegex
    {
        /// <value>Contain content to filter</value>
        private String Content;

        /// <summary>
        /// Constructor of <c>FilterWithRegex</c>.
        /// </summary>
        /// <param name="content">Content on which you want to filter or validate</param>
        public FilterWithRegex(String content) => this.Content = content;

        /// <summary>
        /// The <c>WithinTwoValues</c> method returns the value of the content within the indicated parameters.
        /// </summary>
        /// <param name="start">Match start</param>
        /// <param name="end">Match end</param>
        /// <returns>The value of the content within the indicated parameters</returns>
        public String WithinTwoValues(String start, String end)
        {
            Regex regex = this.CreateRegex(pattern: $"(?<={start}).*?(?={end})");

            return regex.Match(Content).Value;
        }

        /// <summary>
        /// The <c>Password</c> method returns the value of the content if the match is correct.
        /// </summary>
        /// <param name="mPassword">
        /// <example>
        /// It receives a series of parameters for the configuration of the regex
        /// <code>
        ///regex_2.Password(new Mpassword
        ///{
        ///    UpperCase = true,
        ///    LowerCase = true,
        ///    Number = true,
        ///    SpecialCharacter = true,
        ///    Longitude = new Mlongitude
        ///    {
        ///        Start = 6,
        ///        End = 20
        ///    }
        ///
        ///}
        /// </code>
        /// </example>
        /// </param>
        /// <returns>The value of <c>Content</c> if the match is correct.</returns>
        public String Password(Mpassword mPassword)
        {
            string pattern = this.CreatePatternPassword(mPassword);
            Regex regex = this.CreateRegex(pattern: pattern);

            return regex.Match(Content).Value;
        }

        /// <summary>
        /// The <c>Email</c> method returns the value of the content if the match is correct.
        /// </summary>
        /// <returns>The value of <c>Content</c> if the match is correct.</returns>
        public String Email()
        {
            string pattern = @"^(?=[a-z0-9._]+@[a-z]+\.[a-z]{2})[a-z0-9_.@]{10,30}$";
            Regex regex = this.CreateRegex(pattern: pattern);

            return regex.Match(Content).Value;
        }

        /// <summary>
        /// The <c>Url</c> method returns the value of the content if the match is correct.
        /// </summary>
        /// <returns>The value of <c>Content</c> if the match is correct.</returns>
        public String Url()
        {
            string pattern = @"^https?:\/\/.*$";
            Regex regex = this.CreateRegex(pattern: pattern);

            return regex.Match(Content).Value;
        }

        /// <summary>
        /// <c>CreatePatternPassword</c> receives a series of parameters to create a pattern and returns it.
        /// </summary>
        /// <param name="mPassword">A series of parameters to create a pattern.</param>
        /// <returns>Returns the custom pattern.</returns>
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

        /// <summary>
        /// It receives the pattern and regex options, if it does not receive anything it takes by default <code>RegexOptions.Multiline</code>.
        /// Then it returns the Regex already initialized and configured.
        /// </summary>
        /// <param name="pattern">A string containing the regex pattern.</param>
        /// <param name="regexOptions">The regex options.</param>
        /// <returns>Returns the Regex already initialized and configured.</returns>
        private Regex CreateRegex(String pattern, RegexOptions regexOptions = RegexOptions.Multiline)
        {
            return new Regex(pattern, regexOptions);
        }
    }
}
