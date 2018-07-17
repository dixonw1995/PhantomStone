using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Collections;

namespace AssemblyCSharp
{
	public static class Utility
	{
		public static System.Random random = new System.Random ();

//		static int i, j, pos, count;
//
//		static string strResult;

//		public static TouchPhase? GetHits(this MonoBehaviour behav, ref Touch touch, Ray ray, ref RaycastHit[] hits) {
//			if (Input.touchCount > 0) {
//				touch = Input.GetTouch (0);
//				List<RaycastHit> tempHits = new List<RaycastHit> ();
//				//				ray = Camera.main.ScreenPointToRay (touch.position);
//				foreach (Camera camera in Camera.allCameras) {
//					ray = camera.ScreenPointToRay (touch.position);
//					Debug.DrawRay (ray.origin, ray.direction * 800f);
//					tempHits.AddRange (Physics.RaycastAll (ray, Mathf.Infinity));
//				}
//				hits = tempHits.ToArray ();
//				if (hits != null && hits.Length > 0)
//					return touch.phase;
//			}
//			return null;
//		}
//
//		public static void SendMessage(this GameObject[] objs, string method, object value, SendMessageOptions options = SendMessageOptions.DontRequireReceiver){
//			Array.ForEach (objs, obj => obj.SendMessage (method, value, options));
//		}
//
//		public static void SendMessage(this RaycastHit[] hits, string method, object value, SendMessageOptions options = SendMessageOptions.DontRequireReceiver){
//			Array.ForEach (hits, hit => hit.transform.SendMessage (method, value, options));
//		}


//		public static IEnumerator Lerp (Vector3 source, Vector3 destination, float time, Action<Vector3> callback) {
//			float startTime = Time.time;
//
//			while (Time.time < startTime + time) {
//				if (callback != null) {
//					callback (Vector3.Lerp (source, destination, time));
//				}
//				yield return null;
//			}
//
//			if (callback != null) {
//				callback (destination);
//			}
//			yield return "done";
//		}
//
//		public static void RestartCoroutine(this MonoBehaviour behav, Coroutine routine, IEnumerator enumerator) {
//			if (enumerator != null) {
//				if (routine != null) {
//					behav.StopCoroutine (routine);
//				}
//				routine = behav.StartCoroutine (enumerator);
//			}
//		}
	}
}

