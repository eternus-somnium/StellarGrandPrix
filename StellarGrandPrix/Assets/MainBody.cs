using UnityEngine;
using System.Collections;

public class MainBody : MonoBehaviour {

	public float speed = 60;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.forward * speed * Input.GetAxis ("Vertical"));
		rb.AddForce (transform.right * speed * Input.GetAxis ("Horizontal"));
		rb.AddTorque (transform.up * speed * Input.GetAxis ("Yaw"));
		rb.AddTorque (transform.forward * speed * Input.GetAxis ("Roll"));
		rb.AddTorque (transform.right * speed * Input.GetAxis ("Pitch"));
	}
}
