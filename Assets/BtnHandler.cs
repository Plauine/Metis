using Metis.Item;
using UnityEngine;


namespace Metis.Utils
{
	/// <summary>
	/// Class, handles the ThrowBall functionality. 
	/// </summary>
	public class BtnHandler : MonoBehaviour
	{
		/// <summary>
		/// Reference to the TrajectoryCalculation script 
		/// </summary>
		[SerializeField]
		private TrajectoryCalculation _tc;

		/// <summary>
		/// The position of this object will be used as position from where the ball gets
		/// thrown. 
		/// </summary>
		[SerializeField]
		private GameObject _hand;

		/// <summary>
		/// The object that will be thrown from the user. 
		/// </summary>
		[SerializeField]
		private GameObject pokeball;

		/// <summary>
		/// The velocity that determines the flight of the ball 
		/// </summary>
		[SerializeField]
		private Vector3 _velocity;

		/// <summary>
		/// The drag of the ball. Necessary for the trajectory calculation.
		/// </summary>
		[SerializeField]
		private float _drag;

		// Update is called once per frame
		void Update()
		{
			// get always the estimations 
			_tc.GetEstimation(_hand.transform.position, _velocity, 0.0f, _drag);

			// throw the ball if user presses Z 
			if (Input.GetKeyDown(KeyCode.Z)) ThrowBall();
		}

		/// <summary>
		/// Function, instantiates a ball and throws the ball with the current velocity.
		/// </summary>
		private void ThrowBall()
		{
			GameObject go = Instantiate(pokeball);
			go.transform.position = _hand.transform.position;
			Rigidbody rb = go.GetComponent<Rigidbody>();
			rb.velocity = _velocity;
		}
	}

}
