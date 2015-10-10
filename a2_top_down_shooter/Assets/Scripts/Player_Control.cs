using UnityEngine;
using System.Collections;

public class Player_Control : MonoBehaviour {

	public float speed;
	public float rotation_speed;
	
	Transform trans;
	Vector3 pos;
	Vector3 rot;
	float angle;
	Rigidbody2D r_body;

	//The player's feet. Are a child object.
	Animator feet_animator;
	public GameObject feet;

	// Use this for initialization
	void Start ()
	{
		trans = transform;
		pos = trans.position;
		rot = trans.rotation.eulerAngles;
		feet_animator = feet.GetComponent<Animator>();
		r_body = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
	{
		//grab the current angle
		angle = trans.eulerAngles.magnitude * Mathf.Deg2Rad;
		
		//rotate
		if (Input.GetKey (KeyCode.RightArrow)) {
			rot.z -= rotation_speed;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rot.z += rotation_speed;
		}
		
		//move forward and backward
		if (Input.GetKey (KeyCode.UpArrow))
		{
			r_body.AddForce(new Vector2(Mathf.Cos (angle) * speed, 0));
			r_body.AddForce(new Vector2(0, Mathf.Sin (angle) * speed));
			//pos.x += (Mathf.Cos (angle) * speed) * Time.deltaTime;
			//pos.y += (Mathf.Sin (angle) * speed) * Time.deltaTime;
			feet_animator.SetBool("walking", true);
		}
		else if (Input.GetKey (KeyCode.DownArrow))
		{
			r_body.AddForce(new Vector2(-1f * (Mathf.Cos (angle) * speed), 0));
			r_body.AddForce(new Vector2(0, -1f * (Mathf.Sin (angle) * speed)));
			//pos.x -= (Mathf.Cos (angle) * speed) * Time.deltaTime;
			//pos.y -= (Mathf.Sin (angle) * speed) * Time.deltaTime;
			feet_animator.SetBool("walking", true);
		}
		else
		{
			feet_animator.SetBool("walking", false);
		}
		
		//update
		trans.rotation = Quaternion.Euler (rot);
	}
}
