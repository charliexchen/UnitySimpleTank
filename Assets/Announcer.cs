using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Announcer : MonoBehaviour {
	public GameObject player;
	int size=50;
	float time = 3;
	float count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (player) {
			if (count > time && count < time + 1) {
				GetComponent<Text> ().text = "";
				count = 3.5f;
			}
		} else {
			if (count > 4) {
				GetComponent<Text> ().text = "YOU HAVE DIED";
			} 
			if (count > 7) {
				Application.LoadLevel (0);
			}
		}
		//Debug.Log (count);
		if (Input.GetKey("escape")){
			Debug.Log ("exit");
			Application.LoadLevel (0);
		}
	}
}
