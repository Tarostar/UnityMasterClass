using UnityEngine;
using System.Collections;

public class SpawnCoconuts : MonoBehaviour {

	// reference to coconut prefab
	public Transform theCoconut;

	// minimum spawn rate
	public float spawnRate = 5.0f;

	// additional random maximum
	public float spawnRandomFactor = 5.0f;

	// random distance
	public float spawnDistanceFactor = 3.0f;

	// max coconuts for tree
	public int maxCoconuts = 5;

	// array to keep track of coconuts
	private ArrayList thisTreesCoconuts;

	// Use this for initialization
	void Start () {
	
		thisTreesCoconuts = new ArrayList();

		StartCoroutine(SpawnMyCoconuts());
	}

	// coroutines must return IEnumerator
	IEnumerator SpawnMyCoconuts()
	{
		while (true)
		{
			// do nothing
			yield return new WaitForSeconds(spawnRate + Random.Range(0, spawnRandomFactor));

			// sawn coconut only if max not reached
			if (thisTreesCoconuts.Count < maxCoconuts)
			{
				// create random position
				Vector3 l_position = transform.position + Random.insideUnitSphere * spawnDistanceFactor;
				l_position.y = transform.position.y;

				// spawn coconut
				// Quaternion.identity means no rotation
				// "as Transform" because object as default.
				Transform l_coconut = Instantiate(theCoconut, transform.position, Quaternion.identity) as Transform;
				
				// parent cocount
				l_coconut.parent = transform;

				// add to array
				thisTreesCoconuts.Add (l_coconut.gameObject);
			}
		}
	}

	void PickedUp(GameObject coconutGameObject)
	{
		// remove coconut from array
		thisTreesCoconuts.Remove(coconutGameObject);

		// destroy
		Destroy(coconutGameObject);
	}

	void DestroyAllCoconuts()
	{
		foreach (GameObject l_coconut in thisTreesCoconuts)
		{
			Destroy(l_coconut);
		}

		thisTreesCoconuts.Clear ();
	}
}
