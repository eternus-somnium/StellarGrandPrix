using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit (Collider col) {
		if (col.GetComponent<Rigidbody> ()) {
			if (Vector3.Dot(transform.forward, col.GetComponent<Rigidbody> ().velocity) < 0) print("Passed the right way");
			else if (Vector3.Dot(transform.forward, col.GetComponent<Rigidbody> ().velocity) > 0) print("Passed the wrong way");
		}
	}
}
