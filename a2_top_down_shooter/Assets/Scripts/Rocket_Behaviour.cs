using UnityEngine;
using System.Collections;

public class Rocket_Behaviour : MonoBehaviour {
	
	Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Border" || other.tag == "Zombie")
		{
			//On a collision, stop the rocket and play explosion animation
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			anim.SetTrigger("explode");

			Invoke("Destroy_Rocket", 1);
		}

		if (other.tag == "Zombie")
		{
			Destroy(other.gameObject);
		}
	}

	void Destroy_Rocket()
	{
		Destroy(gameObject);
	}

}
