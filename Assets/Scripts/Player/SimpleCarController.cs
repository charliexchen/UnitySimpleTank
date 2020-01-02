using UnityEngine;
using System.Collections;

public class SimpleCarController : MonoBehaviour {
	public float brake = 10000f;
	public float maxTorque = 500f;
	public float maxSteerAngle = 45f;
	public WheelCollider[] wheelCollider = new WheelCollider[4];
	private Rigidbody rb;
	public Transform CoM;
	public void Start(){
		rb = GetComponent<Rigidbody> ();
	}
	public void FixedUpdate() {
		
		float steer = Input.GetAxis("Horizontal")*maxSteerAngle;
		float torque = Input.GetAxis("Vertical")*maxTorque;

		wheelCollider[0].steerAngle = steer;
		wheelCollider[1].steerAngle = steer;
		wheelCollider[4].steerAngle = steer;
		wheelCollider[5].steerAngle = steer;

		for (int i=0; i < 6; i++){
			wheelCollider[i].motorTorque = torque;
		}
		rb.centerOfMass = CoM.localPosition;
		if (Input.GetAxis ("Jump") == 1) {
			for (int i=0; i < 6; i++){
				wheelCollider[i].brakeTorque = brake;
			}
		} else {
			for (int i=0; i < 6; i++){
				wheelCollider[i].brakeTorque = 0;
			}
		}
		if (Input.GetAxis ("Vertical") == 0) {
			for (int i = 0; i < 6; i++) {
				wheelCollider [i].brakeTorque = brake;
			}
		} else {
			for (int i=0; i < 6; i++){
				wheelCollider[i].brakeTorque = 0;
			}
		}
	}
}
