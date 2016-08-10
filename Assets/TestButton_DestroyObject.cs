using UnityEngine;
using System.Collections;

public class TestButton_DestroyObject : MonoBehaviour {

	void OnTouchDown()
	{
		Destroy (gameObject);
	}
}
