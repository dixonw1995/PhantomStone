using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public static class Vector3Extension
	{
		public static float Axis (this Vector3 vector3, Vector3 axis){
			if (axis == Vector3.zero)
				return 0;
			if (axis.x == 0 && axis.y == 0)
				return vector3.z;
			if (axis.x == 0 && axis.z == 0)
				return vector3.y;
			if (axis.y == 0 && axis.z == 0)
				return vector3.x;
			return 0;
		}
	}
}

