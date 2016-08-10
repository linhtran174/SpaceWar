using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	private float moveHorizontal=0;
	private float moveVertical=0;
	private float deltaX;
	private float deltaY;

	void Update ()
	{
		if(GameController.isGameStarted==1)
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}
	}

	void FixedUpdate ()
	{
#if UNITY_EDITOR
		if (GameController.isGameStarted == 1) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rigidbody.velocity = movement * speed;
			
			rigidbody.position = new Vector3
				(
					Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
					2, 
					Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
					);
			
			rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

		}

#else
		if (GameController.isGameStarted == 1)
		{
			deltaX = Input.acceleration.x - moveHorizontal;
			deltaY = Input.acceleration.y - moveVertical;
			if( deltaX >0.1 || deltaX < -0.1||deltaY>0.1 || deltaY < -0.1)
			{
				if( deltaY > 0.02 || deltaY < -0.02)
				{
					moveVertical = Input.acceleration.y*5;
				}
				if(deltaX >0.02 || deltaX < -0.02)
				{
					moveHorizontal = Input.acceleration.x*5;
				}
					Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
					rigidbody.velocity = movement * speed;

					rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
			
			}
			rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				2, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
			);
		}
#endif
	}
}
