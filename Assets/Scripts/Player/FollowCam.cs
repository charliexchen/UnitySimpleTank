using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public Transform trans;
	public float turningspeed=0.2f;
	// Use this for initialization
	public Transform test;
	void Start () {
	}

	// Update is called once per frame
	void Update ()
	{
		float rot = transform.eulerAngles.y;	

		float tar = trans.eulerAngles.y;
		float diff = rot - tar;
		if (diff > 180) {
			diff = diff - 360;}
		else if (diff < -180) {
			diff = diff+360;
		}
		if (Mathf.Abs(diff)<1) {
			transform.Rotate (0, -diff, 0);
		}
		
		else if (diff > 0) {
			transform.Rotate (0, -turningspeed*Time.fixedDeltaTime, 0);
		}
		else if (diff < 0 ) {
			transform.Rotate (0, turningspeed*Time.fixedDeltaTime, 0);
		}
		//}
		if (test) {
			Vector3 consVector = (transform.rotation * Vector3.left)+transform.position;
			test.position = consVector;
		}
	}
}
