using UnityEngine;
using System.Collections;
using System;

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
		//Since the player can die, we need to cathc errors when the player object no longer exists
		try
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
		}
		catch(Exception e)
		{
			transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * speed);
		}
	}
}
