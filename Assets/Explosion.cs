using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public float damage =3;
	public float radius = 5;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] hitboxes = GameObject.FindGameObjectsWithTag ("hitBox");
		for (int i = 0; i < hitboxes.Length; i++) {
			//Debug.Log(hitboxes[i].transform.parent.transform.parent.transform.parent.name);
			if (Vector3.Magnitude(hitboxes [i].transform.position - transform.position)<radius) {
				try{
					hitboxes [i].GetComponent<IsHit>().hit (damage * Time.deltaTime);
				}catch{
					Debug.Log ("error"+hitboxes [i].name.ToString());
				}
			}
		}

	}
	void FixUpdate() {

	}
}
