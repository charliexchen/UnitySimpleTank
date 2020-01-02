using UnityEngine;
using System.Collections;

public class IsHit : MonoBehaviour {
	public GameObject stats;
	// Use this for initialization
	void Start () {
	
	}
	public void hit (float dam){
		stats.GetComponent<PlayerStats> ().damage (dam);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
