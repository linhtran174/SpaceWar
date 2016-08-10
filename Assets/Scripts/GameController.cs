using UnityEngine;
using System.Collections;
//using System;
 
public class GameController : MonoBehaviour {

	public GameObject Ship1;
	public GameObject Ship2;
	public GameObject Ship3;
	public GameObject Ship4;
	public GameObject Ship5;
	public GameObject myStartText;
	public GUIText titleText;
	public GUIText titleText2; 
	public GUIText scoreText;
	public GUIText gameOverText;
	public GameObject restartText;


	public GameObject enemy;
	public GameObject hazard;
	public int hazardCount;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public static int isGameStarted =0;
	public static int isWaveStarted =0;

	public bool restart;
	public bool gameOver;
	public bool finished = false;
	public bool allFinished = false;
	private Vector3 movement = new Vector3(0, 0.0f, 1);
	private Vector3 movement2 = new Vector3(-2, 0.0f, 1);
	private int score =0;

	void Start () {
		myStartText.GetComponent<GUIText> ().fontSize = (myStartText.GetComponent<GUIText> ().fontSize) * ( Screen.width/ 480);

		titleText.fontSize = titleText.fontSize * ( Screen.width/480 );
		titleText2.fontSize = titleText2.fontSize * ( Screen.width/480 );
		scoreText.fontSize = scoreText.fontSize * ( Screen.width/480 );
		gameOverText.fontSize = gameOverText.fontSize * ( Screen.width/480 ); 
		restartText.GetComponent<GUIText> ().fontSize = ((restartText.GetComponent<GUIText> ().fontSize) * ( Screen.width/480 ));


		StartCoroutine (Intro());
		StartCoroutine (Intro2 ());
		StartCoroutine (StartText ());
		StartCoroutine (StartWave ());
		/*
		try{
			StartCoroutine(StartText ());
		}
		catch(Exception e)
		{
			Debug.Log ("Prob: "+ e.ToString() +" ,From: " + e.GetBaseException().Message);
		}*/
	}

	public void AddScore(int scoreValue)
	{
		score += scoreValue;
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "You're Dead...";
		gameOver = true;
	
	}
	public IEnumerator StartWave()
	{
		while (isWaveStarted==0)
			yield return new WaitForSeconds (0.2f);
		myStartText.SetActive (false);
		StartCoroutine (HazardWave ());
	}
	public IEnumerator HazardWave()
	{
		yield return new WaitForSeconds (1);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if (gameOver)
				{
					//yield return new WaitForSeconds(1);
					restartText.SetActive(true);
					restartText.GetComponent<GUIText>().text = "Play Again!";
					break;
				}
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate( hazard, spawnPosition, spawnRotation);
				Instantiate ( enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}
	}

	IEnumerator StartText()
	{
		//Debug.Log ("allFinished"+allFinished);
		//Debug.Log ("finished"+finished);
		while (!allFinished)
			yield return new WaitForSeconds (0.5f);
		//Debug.Log ("allFinished"+allFinished);
		//Debug.Log ("finished"+finished);
		myStartText.SetActive(true);
		yield return new WaitForSeconds (2f);
        //StartGame();
		/*if (!allFinished) {
			yield return new WaitForSeconds (0.5f);
			StartCoroutine(StartText());
		}
		else{
			myStartText.SetActive(true);
			if (Input.touchCount==0)
			{
				StartCoroutine(StartText());
			}
			else{
				if (!(_myStartText.HitTest(new Vector3(Input.GetTouch(0).position.x,0,Input.GetTouch(0).position.y))))
				{
					finished = false;
					//StartGame();
				}
			}
		}*/
	}

	IEnumerator Intro2()
	{
		while (!finished) yield return new WaitForSeconds(0.1f);
		LinhMove (Ship5, 5f, movement2);
		yield return new WaitForSeconds(1f);
		LinhMove (Ship5, 3f, new Vector3(1.5f, 0.0f, 1));
		yield return new WaitForSeconds(0.75f);
		Stop (Ship5);
		allFinished = true;
	}

	IEnumerator Intro () 
	{
		for (int i =1; i<4; i++) {
			LinhMove (Ship1, 11, movement);
			LinhMove (Ship2, 11, movement);
			LinhMove (Ship3, 11, movement);
			LinhMove (Ship4, 11, movement);
			yield return new WaitForSeconds (0.6f);
		}
		Stop (Ship2);
		Stop (Ship1);
		Stop (Ship3);
		Stop (Ship4);
		finished=true;
	}

	public static void LinhMove(GameObject myObject, float speed, Vector3 movement)
	{
		myObject.rigidbody.velocity = movement * speed;
		myObject.rigidbody.rotation = Quaternion.Euler (0, 0, myObject.rigidbody.velocity.x * -1.5f);
	}

	public static void Stop(GameObject myObject)
	{
		myObject.rigidbody.velocity = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		/*if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				isWaveStarted =0;
				isGameStarted = 0;
				finished = false;
				allFinished = false;
				Application.LoadLevel (Application.loadedLevel);
			}
		}	//Debug.Log ("Ok em!!!");*/
	}


}