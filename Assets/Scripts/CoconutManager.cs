using UnityEngine;
using System.Collections;

public class CoconutManager : MonoBehaviour {

	// magnitude at which cocnuts stop moving
	public float sleepMagnitude = 1.0f;

	// don't start checking for this time
	public float startCheckInSeconds = 2.5f; 

	//check with this frequency
	public float checkEverySecond = 1.0f;

	// is available for pickup?
	public bool availableForPickup = true;

	// Use this for initialization
	void Start () {
		StartCoroutine (GoToSleep());	
	}
	
	// GoToSleep is called once from start
	IEnumerator GoToSleep () {
		yield return new WaitForSeconds(startCheckInSeconds);

		//print(gameObject.name + " : Start check");

		while (rigidbody.angularVelocity.magnitude > sleepMagnitude ||
		       rigidbody.velocity.magnitude > sleepMagnitude)
		{
			yield return new WaitForSeconds(checkEverySecond);
			//print(gameObject.name + " : wait...");
		}

		//print(gameObject.name + " : STOP!");

		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
		rigidbody.Sleep();
	
	}
}
