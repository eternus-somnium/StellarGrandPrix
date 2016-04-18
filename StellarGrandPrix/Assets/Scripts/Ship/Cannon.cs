using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Fire ()
	{
		Instantiate (bullet, transform.position, transform.rotation);
	}
}
