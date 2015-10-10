using UnityEngine;
using System.Collections;

public class Rocket_Spawn : MonoBehaviour {

	public GameObject rocket_prefab;
	private GameObject spawned_rocket;

	public bool wait_to_fire;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Fire1") && !wait_to_fire)
		{
			spawned_rocket = Instantiate(rocket_prefab, transform.position, transform.rotation) as GameObject;
			spawned_rocket.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(350, 0));
			//spawned_rocket.transform.forward = spawned_rocket.GetComponent<Rigidbody2D>().velocity;

			//Wait 1 sec until we allow the player to fire again.
			wait_to_fire = true;
			Invoke("Signal_Fire_Available", 1);
		}
	}

	public void Signal_Fire_Available()
	{
		wait_to_fire = false;
	}
}
