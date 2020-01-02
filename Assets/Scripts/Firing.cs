using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour {
	public GameObject shot;
	public GameObject shot2;
	public float muzzle = 30f;
	public Vector3 pblank;
	public GameObject stats;
	Rigidbody rb;
	public float gundamage;
	int count = 0;
	public GameObject bodyObject;
	public Transform test;
	// Use this for initialization
	void Start () {
		rb = bodyObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (count + " - stats: = " + ((stats == null) ? "null" : stats.name));
		count++; 
		Quaternion gunpos = transform.rotation;
		//rb.AddExplosionForce (1000, (gunpos * pblank) + transform.position, 5);
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (stats.GetComponent<PlayerStats> ().loaded == true) {
				stats.GetComponent<PlayerStats> ().resetReload ();
				GameObject flash = Instantiate (shot2, (gunpos * pblank) + transform.position, Quaternion.identity) as GameObject;
				GameObject newshot = Instantiate (shot, (gunpos * pblank) + transform.position, Quaternion.identity) as GameObject;
				newshot.GetComponent<cannonball> ().fire (transform, muzzle, newDamage: gundamage);
				flash.GetComponent<MuzzleScript> ().fire (transform.rotation);
				rb.AddExplosionForce (150000, (gunpos * pblank) + transform.position, 10);
			}
		 

		}
		if (test) {
			test.position = (gunpos * pblank) + transform.position;
		}
		//float eleInput = Input.GetAxis ("Mouse ScrollWheel");
		//GetComponent<GunElevation> ().off += eleInput;
	}
}
