using UnityEngine;
using System.Collections;

public class MainCharacterManager : MonoBehaviour {

	//number of carried coconuts
	private int coconutsInBasket = 0;

	// maximum coconuts fitting in basket
	public int maxBasketSize = 5;

	// the coconut in the hut prefab
	public Transform theCoconutInTheHut;

	private int score = 0;

	// invoke to respawn main character
	void Respawn()
	{
		// repos main character
		transform.position = transform.parent.position;

		//rotate main character
		transform.rotation = transform.parent.rotation;
	}

	void OnTriggerEnter(Collider other)
	{
		// local references to manager objects
		CoconutManager l_coconutManager;
		HutManager l_hutManager;

		l_coconutManager = other.gameObject.GetComponent<CoconutManager>();
		l_hutManager = other.transform.parent.gameObject.GetComponent<HutManager>();

		// do we have coconut manager
		if (l_coconutManager)
		{
			if (coconutsInBasket < maxBasketSize)
			{
				if (other.gameObject.GetComponent<CoconutManager>().availableForPickup)
				{
					// coconut no longer available
					other.gameObject.GetComponent<CoconutManager>().availableForPickup = false;

					// tell spawner coconut was picked up
					other.gameObject.transform.parent.gameObject.SendMessage(Literals.PickedUp, other.gameObject, SendMessageOptions.RequireReceiver);

					// add 1 to basket
					coconutsInBasket++;
				}
			}
		}

		// do we have hut manager
		if (l_hutManager)
		{
			// drop coconuts
			while (coconutsInBasket > 0)
			{
				// place to drop coconut
				Vector3 l_position = other.transform.position + Random.insideUnitSphere;

				// the coconut in the hut
				Transform l_coconut = Instantiate (theCoconutInTheHut, l_position, Quaternion.identity) as Transform;

				// parent it to drop zone
				l_coconut.parent = other.gameObject.transform;

				// subtract from basket
				coconutsInBasket--;
				score++;
			}
		}
	}

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 200, 20), "Coconuts in basket: " + coconutsInBasket);
		GUI.Label (new Rect (10, 30, 100, 20), "Score: " + score);
	}
}
