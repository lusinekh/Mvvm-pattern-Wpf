using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Weather
{
    class ConverterXmlToObjectl
    {
        
        public current Converter(string value)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(current));
            StringReader stringReader = new StringReader(value);
            return  (current)serializer.Deserialize(stringReader);
           
        }


    }
}
