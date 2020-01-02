using UnityEngine;
using System.Collections;

public class MuzzleScript : MonoBehaviour {
	private Quaternion dir;
	private bool init;
	// Use this for initialization
	float lifetime=1.5f;
	public Light lit;
	float count=0;
	public bool flash=false;
	void Start () {
		Destroy (gameObject, lifetime);
		if (flash == true) {
			lit = GetComponent<Light> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (flash == true) {
			lit.intensity = 4*8 * (count / 1.5F) * (1 -count/ 1.5F);
			//Debug.Log (lit.intensity);
		}
		transform.rotation = dir;
	//	transform.Rotate (0, 180, 0);
	}
	public void fire(Quaternion rot){
		if (init == false) {
			dir = rot;
			init = true;
		}
	}
}
