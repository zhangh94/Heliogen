using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace Heliogen
{
    interface IHeliostat
    {
        /// <summary>
        /// Compute the normal vector required to reflect the sun to a target
        /// </summary>
        /// <param name="sunAzimuth">The azimuth of the sun</param>
        /// <param name="sunElevation">The elevation of the sun</param>
        /// <param name="target">The point at which you want to place the center of the reflected beam</param>
        UnitVector3D GetPointingNormal(Angle sunAzimuth, Angle sunElevation, Point3D target);
    }
}
