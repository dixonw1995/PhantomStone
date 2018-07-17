using UnityEngine;

public static class BoundsExtensions
{
	public static bool IsVisibleEntirelyFrom(this Bounds bounds, Camera camera) {
		Vector3 minPoint = camera.WorldToViewportPoint (bounds.min);
		Vector3 maxPoint = camera.WorldToViewportPoint(bounds.max);
		return (minPoint.x > 0 && minPoint.x < 1
			&& minPoint.y > 0 && minPoint.y < 1
			&& minPoint.z > 0
			&& maxPoint.x > 0 && maxPoint.x < 1
			&& maxPoint.y > 0 && maxPoint.y < 1
			&& maxPoint.z > 0);
	}
}
