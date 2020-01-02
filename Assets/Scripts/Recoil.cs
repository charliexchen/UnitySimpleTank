using UnityEngine;
using System.Collections;

public class Recoil : MonoBehaviour {
	public Transform recoilPosition;
	Rigidbody rb;
	public	GameObject stats;
	//public GameObject test;
	public Vector3 pblank;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		Quaternion gunpos = recoilPosition.rotation;
		//test.transform.position = (gunpos * pblank) + transform.position;

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (stats.GetComponent<PlayerStats> ().loaded == true) {
				rb.AddExplosionForce (50000, (gunpos * pblank) + transform.position, 10);
			}
		}
	}
}
