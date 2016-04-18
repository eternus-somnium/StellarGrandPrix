using UnityEngine;
using System.Collections;

public class MainBody : MonoBehaviour {

	public int hull = 100;
	public float speed = 60;
	private Rigidbody rb;
	private Vector3 directionVector;
	public GameObject[] forwardThurusters;
	public GameObject[] leftThrusters;
	public GameObject[] rightThrusters;
	public Cannon[] cannons;
	public float fireRate;
	private float cooldown = 0;

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 0)
			cooldown -= Time.deltaTime;
		foreach (GameObject fwd in forwardThurusters) {
			fwd.GetComponent<Rigidbody> ().AddForce (transform.forward * speed * Input.GetAxis ("Vertical"));
			fwd.GetComponent<Rigidbody> ().AddForce (transform.right * 0.4f * speed * Input.GetAxis ("Horizontal"));
			fwd.GetComponent<Rigidbody> ().AddForce (transform.up * 0.4f * speed * Input.GetAxis ("Pitch"));
		}
		foreach (GameObject rightThruster in rightThrusters) {
			rightThruster.GetComponent<Rigidbody> ().AddForce (rightThruster.transform.forward * speed * 0.5f * -Input.GetAxis ("Horizontal"));
			rightThruster.GetComponent<Rigidbody> ().AddForce (-rightThruster.transform.up * speed * 0.5f * Input.GetAxis ("Roll"));
		}
		foreach (GameObject leftThruster in leftThrusters) {
			leftThruster.GetComponent<Rigidbody> ().AddForce (leftThruster.transform.forward * speed * 0.5f * Input.GetAxis ("Horizontal"));
			leftThruster.GetComponent<Rigidbody> ().AddForce (leftThruster.transform.up * speed * 0.5f * Input.GetAxis ("Roll"));
		}

		rightThrusters[0].GetComponent<Rigidbody> ().AddForce (-transform.right * speed * 0.5f * Input.GetAxis ("Yaw"));
		rightThrusters[0].GetComponent<Rigidbody> ().AddForce (-transform.right * speed * 0.5f * Input.GetAxis ("Yaw"));
		leftThrusters[0].GetComponent<Rigidbody> ().AddForce (transform.right * speed * 0.5f * Input.GetAxis ("Yaw"));
		rightThrusters[1].GetComponent<Rigidbody> ().AddForce (transform.right * speed * 0.5f * Input.GetAxis ("Yaw"));
		rightThrusters[1].GetComponent<Rigidbody> ().AddForce (-transform.up * speed * 0.5f * Input.GetAxis ("Pitch"));
		leftThrusters[1].GetComponent<Rigidbody> ().AddForce (-transform.right * speed * 0.5f * Input.GetAxis ("Yaw"));
		leftThrusters[0].GetComponent<Rigidbody> ().AddForce (-transform.up * speed * 0.5f * Input.GetAxis ("Pitch"));
		forwardThurusters[0].GetComponent<Rigidbody> ().AddForce (transform.up * speed * 0.5f * Input.GetAxis ("Roll"));
		forwardThurusters[1].GetComponent<Rigidbody> ().AddForce (-transform.up * speed * 0.5f * Input.GetAxis ("Roll"));

		if (Input.GetButton ("Fire") && cooldown <= 0) {
			foreach (Cannon cannon in cannons) {
				cannon.Fire ();
				cooldown = fireRate;
			}
		}
	}

	public void Damage(int amount)
	{
		hull -= amount;
	}
}
