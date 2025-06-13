using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RaceResultPrediction
    {
        private Pace _pace;
        private double _distanceInMeters;

        public RaceResultPrediction(Pace pace, double distanceIn_distanceInMetersMeters) 
        { 
            _pace = pace;
            _distanceInMeters = _distanceInMeters;

        }
        public TimeSpan GetRaceResult()
        {
            TimeSpan result = TimeSpan.Zero;

            return result;
        }

        private int ConvertPaceToSeconds (Pace pace)
        {
            int result = 0;
            result = pace.Minutes * 60 + pace.Seconds;
            return result;
        }
    }
}
