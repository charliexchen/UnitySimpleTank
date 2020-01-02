using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public float score = 0; 
	float count=0;
	public float totaltime=2;
	public GameObject player;
	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "";
	}
	public void newline(string line){
		count = 0;
		GetComponent<Text> ().text = GetComponent<Text> ().text +line + "\n";
	}
	
	// Update is called once per frame
	void Update () {
		if (player) {
			score += Time.deltaTime;
		}
		count += Time.deltaTime;
		if (count > 2) {
			GetComponent<Text> ().text = "";
		}
	}
}
