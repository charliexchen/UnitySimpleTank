using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class scoreCount : MonoBehaviour {
	int score=0;
	public GameObject ind;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score = Mathf.RoundToInt (ind.GetComponent<Score> ().score);
		GetComponent<Text> ().text = "Score: " + score.ToString();
	}
}
