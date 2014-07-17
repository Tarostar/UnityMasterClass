using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public GameObject theSplashImage;

	public GameObject theMainCharacter;

	public GameObject theMainCamera;

	public GameObject theStartCamera;

	// all of the trees reference
	public GameObject allTrees;

	private bool gameIsRunning = false;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameIsRunning)
		{
			//if (Input.GetMouseButton(0))
			{
				StartTheGame();
			}
		}
	}

	void StartTheGame()
	{
		gameIsRunning = true;

		//theSplashImage.SetActive(false);
		theMainCharacter.SetActive(true);
		theStartCamera.SetActive(true);
		theMainCamera.SetActive(true);

		// send message to all children
		allTrees.BroadcastMessage(Literals.DestroyAllCoconuts);
	}


}
