using UnityEngine;
using System.Collections;

public class GunElevate : MonoBehaviour {
	public Transform tilt;
	public float turningspeed=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (0,0,0);
		float rot = transform.eulerAngles.x;	
		float tar = tilt.eulerAngles.x;
		float diff = rot - tar;
		diff = ((diff -180)% 360);

		if (Mathf.Abs(diff)<1) {
			transform.Rotate ( -diff,0, 0);
		}
		else if (diff > 0) {
			transform.Rotate (-turningspeed*Time.fixedDeltaTime, 0,0);
		}
		else if (diff < 0 ) {
			transform.Rotate ( turningspeed*Time.fixedDeltaTime,0, 0);
		}
	}
}
