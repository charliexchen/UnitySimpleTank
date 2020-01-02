using UnityEngine;
using System.Collections;

public class thirdPerson : MonoBehaviour {
	public GameObject target;
	public float rotatespeed = 5f;
	Vector3 offset;
	// Use this for initialization
	//float roty=0;
	public float range = 70;
	void Start () {
		offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float horizontal = Input.GetAxis ("Mouse X") * rotatespeed;
		//float vertical = -Input.GetAxis ("Mouse Y") * rotatespeed;
		//takes inputs
		target.transform.Rotate (0, horizontal,0);
		Quaternion orientation = target.transform.rotation;
		transform.position = target.transform.position - (orientation * offset);
		transform.LookAt(target.transform.position);

	}
}
