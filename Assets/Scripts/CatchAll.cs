using UnityEngine;
using System.Collections;

public class CatchAll : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (Literals.MainCharacter == other.gameObject.tag)
		{

			other.gameObject.SendMessage (Literals.Respawn, SendMessageOptions.RequireReceiver);
			return;
		}

		Destroy(other.gameObject);
	}
}
