using UnityEngine;
using System.Collections;

public class FiringEnemy : MonoBehaviour {
	public Vector3 pblank;
	public Collider ground;
	public GameObject shot;
	public float muzzle = 10f;
	//public Transform tilt;
	public float turningspeed=20;
	public Transform target;
	public Transform turret;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update ()
	{
		Quaternion gunpos = transform.rotation;
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			GameObject newshot = Instantiate (shot, (gunpos * pblank) + transform.position, Quaternion.identity) as GameObject;
			newshot.GetComponent<cannonball> ().fire (transform, muzzle);
		}

		Vector3 consVector = turret.rotation * Vector3.left;
		Vector3 consVector1 = transform.rotation * Vector3.up;
		//this is the plane in which the gun is aimed
		Vector3 aimingTarget = target.position - (Vector3.Dot (consVector, target.position) - Vector3.Dot (consVector, transform.position)) * consVector;
		Vector3 aimingTarget2 = aimingTarget - (Vector3.Dot (consVector1, target.position) - Vector3.Dot (consVector1, transform.position)) * consVector1;
		//this is the gun position

		//Transform aimpos = transform;
		//aimpos.LookAt (aimingTarget);
		//aimpos.Rotate(90,0,0);

		float offset = aimingTarget2.y - target.position.y;
	

		if (Mathf.Abs (offset) < 0.005 * Vector3.Magnitude (target.position - transform.position)) {
			if (offset > 0) {

				transform.Rotate (-turningspeed * Time.deltaTime / 50, 0, 0);

			} else if (offset < 0) {

				transform.Rotate (+turningspeed * Time.deltaTime / 50, 0, 0);

			}
		} else {
			if (offset > 0) {

				transform.Rotate (-turningspeed * Time.deltaTime, 0, 0);

			} else if (offset < 0) {

				transform.Rotate (+turningspeed * Time.deltaTime, 0, 0);

			}
		}

	}
}
