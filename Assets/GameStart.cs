using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToLevel (string Level) {
		Application.LoadLevel (Level);
		Debug.Log ("clicked");
	}
}
