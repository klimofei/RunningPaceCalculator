using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RaceResultPrediction
    {
        // Conventional race distacnes in meters
        private const double OneKmDistance = 1000;
        private const double OneMiDistance = 1609.344;
        private const double FiveKmDistance = OneKmDistance * 5;
        private const double FiveMiDistacne = 5 * OneMiDistance;
        private const double TenKmDistance = OneKmDistance * 10;
        private const double TenMiDistance =  OneMiDistance * 10;
        private const double HalfMarathonDistance = 21097.5;
        private const double MarathonDistance = 42195;

       public TimeSpan OneKmResult { get; set; } 
       public TimeSpan OneMiResult { get; set; } 
       public TimeSpan FiveKmResult { get; set; } 
       public TimeSpan FiveMiResult { get; set; } 
       public TimeSpan TenKmResult { get; set; } 
       public TimeSpan TenMiResult { get; set; } 
       public TimeSpan HalfMarathonResult { get; set; } 
       public TimeSpan MarathonResult { get; set; } 

        private Pace _pace;
        private double _customDistacneInUnits;

        public RaceResultPrediction(Pace pace) 
        { 
            _pace = pace;
            GetRaceResultForConventionalDistances();
        }

        public RaceResultPrediction(Pace pace, double customDistacneInUnits, MeasurmentSystem measurmentSystem)
        {
            _pace = pace;
            GetRaceResultForConventionalDistances();

        }

        public void GetRaceResultForConventionalDistances()
        {
            OneKmResult = new TimeSpan(0, 0, Convert.ToInt32(OneKmDistance / _pace.GetMetersInSecond()));
            OneMiResult = new TimeSpan(0, 0, Convert.ToInt32( OneMiDistance / _pace.GetMetersInSecond()));
            FiveKmResult = new TimeSpan(0, 0, Convert.ToInt32(FiveKmDistance / _pace.GetMetersInSecond()));
            FiveMiResult = new TimeSpan(0, 0, Convert.ToInt32(FiveMiDistacne / _pace.GetMetersInSecond()));
            //TenKmResult 
            //TenMiResult 
            //HalfMarathonResult 
            //MarathonResult 

        }

       


    }
}
