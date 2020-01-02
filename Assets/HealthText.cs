using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthText: MonoBehaviour {
	public GameObject stats;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (stats) {
			float totalhealth = stats.GetComponent<PlayerStats> ().maxhp;
			float currenthealth = stats.GetComponent<PlayerStats> ().hp;
			GetComponent<Text> ().text = "HP: "+Mathf.RoundToInt (currenthealth).ToString () + "/" + Mathf.RoundToInt (totalhealth).ToString();


		} else {
			GetComponent<Text> ().text = "HP: N/a";

		}
	}
}
