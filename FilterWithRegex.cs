using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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




        public Regex CreateRegex(String pattern, RegexOptions regexOptions = RegexOptions.Multiline)
        {
            return new Regex(pattern, regexOptions);
        }
    }
}
