using UnityEngine;
using System.Collections;

public class SimpleTankController : MonoBehaviour {
		public float maxTorque = 5000f;
		public float maxSteerAngle = 45f;
		public WheelCollider[] wheelCollider = new WheelCollider[4];

		public void FixedUpdate ()
	{
		float torqueLeft = Input.GetAxis ("leftTrack") * maxTorque;
		float torqueRight = Input.GetAxis ("rightTrack") * maxTorque;

		wheelCollider [1].motorTorque = torqueRight * Time.deltaTime;
		wheelCollider [0].motorTorque = torqueRight * Time.deltaTime;

		wheelCollider [2].motorTorque =torqueLeft * Time.deltaTime;
		wheelCollider [3].motorTorque =torqueLeft * Time.deltaTime;

			
		if ((Input.GetKey (KeyCode.E) && Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.Q) && Input.GetKey (KeyCode.D))) {
			wheelCollider [0].steerAngle = -maxSteerAngle;
			wheelCollider [1].steerAngle = maxSteerAngle;
			wheelCollider [2].steerAngle = maxSteerAngle;
			wheelCollider [3].steerAngle = -maxSteerAngle;
		} else {
			wheelCollider [0].steerAngle = 0;
			wheelCollider [1].steerAngle = 0;
			wheelCollider [2].steerAngle = 0;
			wheelCollider [3].steerAngle = 0;
		}
	}
}

