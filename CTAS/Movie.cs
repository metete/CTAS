using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTAS
{
    public class Movie
    {
        public string title;
        public string genre;
        public string duration;
        public string visionDate;
        public string saloon;
        public string session;
        public string seats = new string (new char[] {'0', '0', '0', '0', '0', '0', '0', '0', '0',
                                                      '0', '0', '0', '0', '0', '0', '0', '0', '0',
                                                      '0', '0', '0', '0', '0', '0', '0', '0', '0',
                                                      '0', '0', '0', '0', '0', '0', '0', '0', '0',
                                                      '0', '0', '0', '0', '0', '0', '0', '0', '0',
                                                      '0','0','0','0','0'});

        public string Properties(Movie mov)
        {
            string prop = mov.title + mov.genre + mov.duration + mov.visionDate + mov.saloon + mov.session;

            return prop;
        }
    }
}
