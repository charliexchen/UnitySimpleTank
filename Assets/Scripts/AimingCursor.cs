using UnityEngine;
using System.Collections;

public class AimingCursor : MonoBehaviour {
	public float dampening=0.01f;
	public Vector3 target=Vector3.up;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -=dampening*(transform.position - target)*Time.deltaTime;
	}
}
