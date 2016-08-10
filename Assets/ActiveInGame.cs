using UnityEngine;
using System.Collections;

public class ActiveInGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//StartCoroutine (Activate ());
	}
	IEnumerator Activate()
	{
		while (GameController.isGameStarted!=1)
						yield return new WaitForSeconds (0.5f);
		gameObject.guiText.text = "SCORE: ";

	}
	// Update is called once per frame
	void Update () {
	
	}
}
