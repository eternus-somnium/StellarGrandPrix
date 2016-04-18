using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public int damage;
	private float life = 1000000000;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * 50;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().AddForce(transform.forward * 50);
		life -= Time.deltaTime;
		if(life <= 0) Destroy (gameObject);
	}

	void OnTriggerEnter(Collider target)
	{
		if (!target.gameObject.GetComponent<Projectile> ()) {
			print ("Baf");
			if (target.gameObject.GetComponent<MainBody> ())
				target.gameObject.GetComponent<MainBody> ().Damage (damage);

			Destroy (gameObject);
		}
	}
}
