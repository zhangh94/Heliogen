using System;
using System.Collections.Generic;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace Heliogen
{
    class Heliostat : IHeliostat
    {
        public Point3D location { get; set; }

        public Heliostat(Point3D initialLocation)
        {
            location = initialLocation;
        }

        public UnitVector3D GetPointingNormal(Angle sunAzimuth, Angle sunElevation, Point3D target)
        {
            // Define default orientation as north pointing in an ENU coordinate frame
            UnitVector3D defaultOrientation = UnitVector3D.Create(0, 1, 0);
            UnitVector3D pointingVecNorm;
            UnitVector3D rcvrVecNorm;
            UnitVector3D sunVecNorm;
            Vector3D pointingVec;
            Vector3D rcvrVec;

            // Compute vector from heliostat to receiver
            rcvrVec         = target - location;
            rcvrVecNorm     = rcvrVec.Normalize();

            // Compute vector from heliostat to sun via azimuth & elevation knowledge
            // Assume azimuth is clockwise rotation about Up
            sunVecNorm      = defaultOrientation.Rotate(UnitVector3D.Create(1, 0, 0), sunElevation); 
            sunVecNorm      = sunVecNorm.Rotate(UnitVector3D.Create(0, 0, 1), -sunAzimuth);

            // equivalent/more intutitive transform but with more computations
            //sunVecNorm    = defaultOrientation.Rotate(UnitVector3D.Create(0, 0, 1), -sunAzimuth);
            //var rotVec2   = UnitVector3D.Create(1, 0, 0).Rotate(UnitVector3D.Create(0, 0, 1), -sunAzimuth);
            //sunVecNorm    = sunVecNorm.Rotate(rotVec2, sunElevation);

            // bisect sun and rcvr vector, then normalize
            pointingVec     = (rcvrVecNorm + sunVecNorm) / 2;
            pointingVecNorm = pointingVec.Normalize();

            return pointingVecNorm;
        }
    }
}
