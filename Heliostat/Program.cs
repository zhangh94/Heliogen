using System;
using System.Collections.Generic;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace Heliogen
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Heliostat> heliostats  = new List<Heliostat>();
            List<Angle> sunAzimuths     = new List<Angle>();
            List<Angle> sunElevations   = new List<Angle>();

            // define hardware locations
            heliostats.Add(new Heliostat(new Point3D(0, 10, 0)));
            heliostats.Add(new Heliostat(new Point3D(0, 20, 0)));
            Point3D receiver = new Point3D(0, 0, 10);

            // Case 1
            sunAzimuths.Add(Angle.FromDegrees(180));
            sunElevations.Add(Angle.FromDegrees(45));

            // Case 2
            sunAzimuths.Add(Angle.FromDegrees(175));
            sunElevations.Add(Angle.FromDegrees(40));

            Console.WriteLine($"Given a small heliostat field with a receiver at {receiver}:");
            for (int i = 0; i < sunAzimuths.Count; i++)
            {
                var sunAzimuth = sunAzimuths[i];
                var sunElevation = sunElevations[i];

                Console.WriteLine();
                Console.WriteLine($"When the sun Azimuth is at {sunAzimuth.Degrees} deg and sun Elevation is at {sunElevation.Degrees} deg:");

                foreach (var stat in heliostats)
                {
                    var pointingNorm = stat.GetPointingNormal(sunAzimuth, sunElevation, receiver);
                    Console.WriteLine($"A heliostat at {stat.location} should point {pointingNorm}");
                }
                
            }
            Console.WriteLine("Done");
        }
    }
}
