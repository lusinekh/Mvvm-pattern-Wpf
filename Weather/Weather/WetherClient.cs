using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class Posturi
    {
        public Posturi() { }
        public string GetData(string s)
        {
            Uri uri = new Uri($"http://api.openweathermap.org/data/2.5/weather?q={s}&mode=xml&units=imperial&APPID=bb2032039d792ad07a05d24bcdf1a085");
            var webclient = new WebClient();
            var result = webclient.DownloadString(uri);
            return result;
        }
    }
}