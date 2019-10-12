using UnityEngine;

namespace Metis.Item
{	
	/// <summary>
	/// Class, handles the logic, when a thrown object will hit something. 
	/// </summary>
	public class SpawnObjHandler : MonoBehaviour
	{
		/// <summary>
		/// Object that will be instantiated when something is hit
		/// </summary>
		[SerializeField]
		private GameObject _newObj;

		/// <summary>
		/// Function, will be executed when the gameobject collides with another object.
		/// Instantiates the new object and destroys the current one.
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionEnter(Collision collision)
		{
			GameObject go = Instantiate(_newObj, collision.contacts[0].point, _newObj.transform.rotation);
			Destroy(this.gameObject);
		}
	}
}