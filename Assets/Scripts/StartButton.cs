using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	public GameObject Ship1;
	public GameObject Ship2;
	public GameObject Ship3;
	public GameObject Ship4;
	public GameObject Ship5;
	public GameObject titleText;
	public GameObject titleText2;
	public GameObject boundary;

	void OnTouchDown(){
		StartGame ();
	}
	public void StartGame()
	{
		GameController.isGameStarted =1;
		Debug.Log ("isGameStarted: "+ GameController.isGameStarted);
		StartCoroutine (CleanShip ());
		StartCoroutine (CleanText ());
		StartCoroutine (StartWave ());
	}

	public IEnumerator StartWave()
	{
		yield return new WaitForSeconds (2);
		GameController.isWaveStarted = 1;
	}

	public IEnumerator CleanText()
	{
		Destroy (titleText);
		Destroy (titleText2);
		gameObject.guiText.enabled = false;
		yield return new WaitForSeconds (1.3f);
		boundary.SetActive (true);

	}
	public IEnumerator CleanShip()
	{
		LinhMove (Ship1, 10, movement);
		LinhMove (Ship2, 10, movement);
		LinhMove (Ship3, 10, movement);
		LinhMove (Ship4, 10, movement);
		yield return new WaitForSeconds (2f);
		Destroy (Ship1);
		Destroy (Ship2);
		Destroy (Ship3);
		Destroy (Ship4);
	}
	
	public static void LinhMove(GameObject myObject, float speed, Vector3 movement)
	{
		if (myObject == null)
			return;
		myObject.rigidbody.velocity = movement * speed;
		myObject.rigidbody.rotation = Quaternion.Euler (0, 0, myObject.rigidbody.velocity.x * -1.5f);
	}
	
	public static void Stop(GameObject myObject)
	{
		myObject.rigidbody.velocity = Vector3.zero;
	}
	
	private Vector3 movement = new Vector3(0, 0.0f, 1);
	void OnTouchUp(){

		}
	void OnTouchStay(){

		}
	void OnTouchExit(){

		}

}
