using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pace
    {
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        MeasurmentSystem MeasurmentSystem { get; set; }
    }
}
