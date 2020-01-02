using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {
	public WheelCollider[] wheels;
	// Use this for initialization
	public float distmax=100;
	public float distmin=15;
	public float thrust = 10000;
	public float steer=45;
	public GameObject target;
	public GameObject guide;
	public bool Behaviour=false;
	float aim;
	private float targetangle = 0;
	Rigidbody rb;
	public Transform CoM;
	public GameObject turret;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.centerOfMass = CoM.position;
		target=transform.parent.GetComponent<enemyStat>().target;
		distmin = Random.value * 20 + 5;
		distmax = distmin + Random.value * 70;
		if (Random.value > 0.5) {
			Behaviour = true;
		} else {
			Behaviour = false;
		}
	}
	
	// Update is called once per frame
	void Update(){

	}
	void FixedUpdate () {
		rb.centerOfMass = CoM.localPosition;
		if (target) {
			
			float dist = (target.transform.position - transform.position).magnitude;
			if (dist > distmax) {
				targetangle = 0;
			} else if (dist < distmin) {
				targetangle = 180;
			} else {
				if (Behaviour == true) {
					targetangle = 90;
				} else {
					targetangle = 270;
				}
			}
			//guide.transform.position = transform.position;
			Vector3 TurretOffset = new Vector3 (0, -0.4F, 0);
			//turret.transform.position = transform.position+TurretOffset;
			guide.transform.LookAt(target.transform.position);
			aim = guide.transform.eulerAngles.y;

			float offset = (aim - transform.eulerAngles.y) + targetangle;
			offset = offset % 360;
			if (offset > 180) {

				offset -= 360;
			}
			if (offset > 0) {
				wheels [0].steerAngle = steer;
				wheels [1].steerAngle = steer;
			}
			if (offset < 0) {
				wheels [0].steerAngle = -steer;
				wheels [1].steerAngle = -steer;
			}


			wheels [0].motorTorque = thrust * Time.deltaTime;
			wheels [1].motorTorque = thrust * Time.deltaTime;
			wheels [2].motorTorque = thrust * Time.deltaTime;
			wheels [3].motorTorque = thrust * Time.deltaTime;
		}
	}
}
