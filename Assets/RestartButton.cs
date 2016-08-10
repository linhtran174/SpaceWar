using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	void OnMouseDown()
	{
		GameController.isWaveStarted =0;
		GameController.isGameStarted = 0;
		Application.LoadLevel (Application.loadedLevel);
	}
}
