using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class DataContext:IDataContext
    {
        public List<Event> EventList { get; set; }

        public DataContext()
        {
            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                EventList = csv.GetRecords<Event>().ToList();
            }
        }
    }
}
