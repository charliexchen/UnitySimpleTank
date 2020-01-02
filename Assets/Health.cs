using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public GameObject stats;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (stats) {
			float totalhealth = stats.GetComponent<PlayerStats> ().maxhp;
			float currenthealth = stats.GetComponent<PlayerStats> ().hp;
			transform.localScale = new Vector3(currenthealth / totalhealth,1,1);
		} else {
			transform.localScale=new Vector3 (0,0,0);

		}
	}
}
