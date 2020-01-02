using UnityEngine;
using System.Collections;

public class repair : MonoBehaviour {
	public float hp=1000;
	public int ammo=10;
	//GameObject Com;
	//public GameObject explosion;
	// Use this for initialization
	public Transform CoM;
	bool dying=false;
	Rigidbody rb;
	void Start () {
		GameObject[] radars = GameObject.FindGameObjectsWithTag ("Global");
		radars[1].GetComponent<radar> ().reset ();
		radars[0].GetComponent<radar> ().reset ();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		if (dying == false) {
			rb.centerOfMass = CoM.localPosition;
			if (col.gameObject.name == "HullPlayer") {
				//Debug.Log ("collision");
				GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ().newline ("Supply crate: hp+ " + hp.ToString () + ", Ammo+ " + ammo.ToString ());
				col.transform.parent.GetComponent<PlayerStats> ().hp += hp;
				if (col.transform.parent.GetComponent<PlayerStats> ().hp > col.transform.parent.GetComponent<PlayerStats> ().maxhp) {
					col.transform.parent.GetComponent<PlayerStats> ().hp = col.transform.parent.GetComponent<PlayerStats> ().maxhp;
				}
				col.transform.parent.GetComponent<PlayerStats> ().Ammo += ammo;
				if (col.transform.parent.GetComponent<PlayerStats> ().Ammo > 50) {
					col.transform.parent.GetComponent<PlayerStats> ().Ammo = 50;
				}
				gameObject.tag = "Untagged";
				GameObject[] radars = GameObject.FindGameObjectsWithTag ("Global");
				radars [1].GetComponent<radar> ().reset ();
				radars [0].GetComponent<radar> ().reset ();
				dying = true;
				Destroy (gameObject);
			}
		}
	}
}
