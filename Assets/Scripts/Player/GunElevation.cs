using UnityEngine;
using System.Collections;

public class GunElevation: MonoBehaviour {
	
	public Collider ground;
	public bool enemy=false;

	//public Transform tilt;
	public float turningspeed=20;
	public Transform target;
	public Transform turret;
	public Transform test;
	public Vector3 aimingTarget2;
	public Vector3 rayposition;
	public float off=0;
	public GameObject targetsource;
	//static Rigidbody rb;
	// Use this for initialization
	void Start () {
		//rb=recoil_object.GetComponent<Rigidbody> ();
		ground = GameObject.FindGameObjectWithTag("Terrain").GetComponent<Collider>();
	}

	// Update is called once per frame
	void Update ()
	{   
		if (enemy==true){
			target=targetsource.GetComponent<enemyStat>().target.transform;
		}
		Vector3 consVector = turret.rotation * Vector3.left;
		Vector3 consVector1 = transform.rotation * Vector3.up;
		//this is the plane in which the gun is aimed
		Vector3 aimingTarget = target.position - (Vector3.Dot (consVector, target.position) - Vector3.Dot (consVector, transform.position)) * consVector;
		 aimingTarget2 = aimingTarget - (Vector3.Dot (consVector1, target.position) - Vector3.Dot (consVector1, transform.position)) * consVector1;
		//this is the gun position

		float gunPos=transform.localRotation.eulerAngles.x;
		gunPos = gunPos % 360;
		if (gunPos > 180) {
			gunPos -= 360;
		}

		float offset = aimingTarget2.y - (target.position.y+0.7f);

		if (Mathf.Abs (offset) < 0.005 * Vector3.Magnitude (target.position - transform.position)) {
			if (offset > 0) {
				transform.Rotate (+turningspeed * Time.deltaTime / 50, 0, 0);
			} else if (offset < 0) {
				transform.Rotate (-turningspeed * Time.deltaTime / 50, 0, 0);
			}
		} else {
			if (offset > 0) {
				if (gunPos < 15) {
					transform.Rotate(+turningspeed * Time.deltaTime, 0, 0);
				}
			} else if (offset < 0) {
				if (gunPos > -35) {
					transform.Rotate(-turningspeed * Time.deltaTime, 0, 0);
				}
			}
		}
		if (enemy==false){
		Ray ray = new Ray(transform.position,aimingTarget2-transform.position);
		RaycastHit hit;

		if (ground.Raycast (ray, out hit, 100.0F)) {
			rayposition = ray.GetPoint (hit.distance);
		} else {
 			rayposition = 1000*Vector3.down;
		}
			if (test) {
				test.position = rayposition + 0.05F * Vector3.up + 0.2F * (transform.rotation * Vector3.left);
			}
}
	}
}
