using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_core_regex.Models
{
    public class Mpassword
    {
        public bool UpperCase { get; set; }
        public bool LowerCase { get; set; }
        public bool Number { get; set; }
        public bool SpecialCharacter { get; set; }
        public Mlongitude Longitude { get; set; }

        public Mpassword()
        {
            this.UpperCase = false;
            this.LowerCase = true;
            this.Number = false;
            this.SpecialCharacter = false;
            this.Longitude = new Mlongitude
            {
                Start = 4,
                End = 25
            };
        }

    }

    public class Mlongitude
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
}
