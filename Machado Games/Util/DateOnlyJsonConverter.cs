using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Machado_Games.Util
{
    public class DateOnlyJsonConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public DateOnlyJsonConverter()
        {
            DateTimeFormat = "dd-mm-yyyy";
        }
        
    }
}