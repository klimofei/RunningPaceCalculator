using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pace
    {
        public const double metersInKm = 1000;
        public const double metersInMi = 1609.344;

        public TimeSpan Time {  get; set; }
        public double DistanceInUnits { get; set; } // km for metric, mi for impereal
        public MeasurmentSystem MeasurmentSystem { get; set; }
        
        public Pace(TimeSpan time, double distanceInUnits, MeasurmentSystem measurmentSystem)
        {
            Time = time;
            DistanceInUnits = distanceInUnits;
            MeasurmentSystem = measurmentSystem;
        }

        public TimeSpan ReturnPace ()
        {
            TimeSpan result = new TimeSpan();
            double metersInSecond = GetMetersInSecond();

            if (MeasurmentSystem == MeasurmentSystem.Metric)
            {
                var paceInSeconds = metersInKm / metersInSecond; // <- seconds per 1 km
                result = new TimeSpan(0, 0, Convert.ToInt32(paceInSeconds));
            }
            else if ( MeasurmentSystem == MeasurmentSystem.Impereial)
            {
                var paceInSeconds = metersInMi / metersInSecond; // <- seconds per 1 mi
                result = new TimeSpan(0, 0, Convert.ToInt32(paceInSeconds));
            }

            return result;

        }

        public double GetMetersInSecond ()
        {
            double timeInSeconds = Time.TotalSeconds;
            double metersInSecond = 0;

            switch (MeasurmentSystem)
            {
                case MeasurmentSystem.Metric:
                    metersInSecond = DistanceInUnits * metersInKm / timeInSeconds;
                    break;
                case MeasurmentSystem.Impereial:
                    metersInSecond = DistanceInUnits * metersInMi / timeInSeconds;
                    break;
            }
            return metersInSecond;
        }

        public int ConvertPaceToSeconds()
        {
            int result = 0;
            result = Time.Hours * 60 * 60 + Time.Minutes * 60 + Time.Seconds;
            return result;
        }

    }
}
