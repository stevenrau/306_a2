using UnityEngine;
using System.Collections;

public class Zombie_Bahaviour : MonoBehaviour {

	//public GameObject player;

	Transform target;

	public float speed;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
	}
}
