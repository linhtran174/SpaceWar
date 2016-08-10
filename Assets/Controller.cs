using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float speed;
	public float fireRate;
	public float tilt;

	
	public GameObject shot;
	public Transform shotSpawn;

	private float moveHorizontal=0;
	private float moveVertical=0;

	
	private float nextFire;

	void FixedUpdate ()
	{
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}
	}
}
