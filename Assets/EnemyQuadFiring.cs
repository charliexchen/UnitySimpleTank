using UnityEngine;
using System.Collections;

public class EnemyQuadFiring : MonoBehaviour {
	public GameObject shot;
	public GameObject shot2;
	public float muzzle = 30f;
	public Vector3[] pblankcycle;
	Vector3 pblank;
	int cycle=0;
	public GameObject stats;
	Rigidbody rb;
	public float recoil=10000000;
	int count = 0;
	public GameObject bodyObject;
	// Use this for initialization
	public  float gundamage=100000;
	void Start () {
		rb = bodyObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (count + " - stats: = " + ((stats == null) ? "null" : stats.name));
		count++; 
		Quaternion gunpos = transform.rotation;
		//rb.AddExplosionForce (1000, (gunpos * pblank) + transform.position, 5);
		//if (Input.GetKeyDown (KeyCode.Mouse0)) {
		Vector3 offset = GetComponent<GunElevation>().target.transform.position- GetComponent<GunElevation>().aimingTarget2;
		float offset2 = Vector3.Magnitude(GetComponent<GunElevation>().rayposition-transform.position)-Vector3.Magnitude (GetComponent<GunElevation> ().target.transform.position-transform.position);
		//Debug.Log (GetComponent<GunElevation>().rayposition);
		//Debug.Log ("actual pos"+GetComponent<GunElevation>().target.position);
		//Debug.Log (Vector3.Magnitude (offset).ToString());
		if (stats.GetComponent<PlayerStats>().loaded==true&&Vector3.Magnitude(offset)<5&&offset2>-3) {
				//pblankcycle [cycle];	
				stats.GetComponent<PlayerStats>().resetReload();
				GameObject flash = Instantiate (shot2, (gunpos * pblank) + transform.position, Quaternion.identity) as GameObject;
				GameObject newshot = Instantiate (shot, (gunpos * pblank) + transform.position, Quaternion.identity) as GameObject;
				newshot.GetComponent<cannonball> ().fire (transform, muzzle,false,gundamage);
				flash.GetComponent<MuzzleScript> ().fire (transform.rotation);
			rb.AddExplosionForce (recoil, (gunpos * pblank) + transform.position, 10);
		}

	}
}

