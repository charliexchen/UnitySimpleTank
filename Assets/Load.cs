using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
	public GameObject stats;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (stats) {
			float totalhealth = stats.GetComponent<PlayerStats>().reload;
			float currenthealth = stats.GetComponent<PlayerStats> ().timer;
			float scale = currenthealth / totalhealth;
			if (scale > 1) {
				scale = 1;
			}
			transform.localScale = new Vector3(scale,1,1);
		} else {
			transform.localScale=new Vector3 (0,0,0);

		}
	}
}
