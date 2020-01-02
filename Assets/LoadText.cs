using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadText: MonoBehaviour {
	public GameObject stats;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (stats) {
			GetComponent<Text> ().text  = stats.GetComponent<PlayerStats> ().Ammo.ToString();



		} else {
			GetComponent<Text> ().text = "N/a";

		}
	}
}
