using System.Collections.Generic;
using UnityEngine;

namespace Metis.Item
{
	/// <summary>
	/// Class, handles the calculation and the visualisation of the trajectory. 
	/// </summary>
	public class TrajectoryCalculation : MonoBehaviour
	{
		// GO that will be instantiated for the prediction
		[SerializeField]
		private GameObject _estimationPoint;

		// Parent obj. All predicition points will be children of this object. 
		[SerializeField]
		private GameObject _predictions; 

		/// <summary>
		/// List that saves all prediction points
		/// </summary>
		private List<GameObject> _points;

		/// <summary>
		/// Initialises the list where the predicition points will be saved. 
		/// </summary>
		private void Awake()
		{
			_points = new List<GameObject>();
		}

		/// <summary>
		/// Computes an array of Trajectory object positions by time.
		/// Predict the flight of the object that can be thrown by the user. 
		/// </summary>
		/// <param name="startPos">Starting Position</param>
		/// <param name="velocity">velocity vector</param>
		/// <param name="yFloor">Minimum height, below which is clipped</param>
		/// <param name="drag">Drag of object</param>
		/// Solution found her: https://stackoverflow.com/questions/37580258/how-to-draw-projectile-trajectory-with-unity3ds-built-in-physics-engine
		public void GetEstimation(Vector3 startPos, Vector3 velocity, float yFloor, float drag)
		{
			float timeIncrement = Time.fixedDeltaTime;
			Vector3 pos = startPos;
			
			ClearList(_points);

			while (pos.y > yFloor)
			{
				velocity += Physics.gravity * timeIncrement;
				velocity *= Mathf.Clamp01(1f - drag * timeIncrement);
				pos += velocity * timeIncrement;
				if (pos.y < yFloor)
				{
					//new OnPredictFloorCollision(pos, loopCounts * timeIncrement);
					break;
				}

				GameObject go = Instantiate(_estimationPoint, pos, Quaternion.identity);
				go.transform.parent = _predictions.transform;
				_points.Add(go);
			}
		}

		/// <summary>
		/// Function, iterates over the list and destroys all saved gameobjects in the scene and clears the given list. 
		/// </summary>
		/// <param name="list"></param>
		private void ClearList(List<GameObject> list)
		{
			foreach (GameObject go in list)
			{
				Destroy(go);
			}
			list.Clear();
		}

	}
}
