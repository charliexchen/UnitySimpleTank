using UnityEngine;
using System.Collections;

public class Missile: MonoBehaviour {
	private Rigidbody rb;
	private bool init;
	private float init_V = 0f;
	private Quaternion dir;
	public GameObject ground;
	public GameObject explosion;
	public GameObject explosionHit;
	public GameObject target;
	float damage;
	float explosionDamage;
	bool affl;
	float corr=0;
	// Use this for initialization
	void Start(){
		//init = false;
		Destroy (gameObject, 2f);
		rb = GetComponent<Rigidbody> ();
	}


	public void fire(Transform rot, float v,bool friendly=true, float newDamage=100, float newExDamage=5){
		if (init == false) {
			damage = newDamage;
			explosionDamage = newExDamage;
			dir = rot.rotation;
			init_V = v;
			init = true;
			affl = friendly;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{	//Debug.Log("v_set"+init.ToString());
		if (init == true) {
			transform.rotation = dir;
			rb.velocity = dir * new Vector3 (0, 0, init_V);
			//	Debug.Log ("v_set" + rb.velocity.ToString ());
			init = false;
		}
		rb.AddForce(Time.deltaTime*corr*(target.transform.position-transform.position));
		//if (transform.position.y < 0) {
			//Destroy(this.gameObject);
		//
		//}

	}
	void OnCollisionEnter(Collision col) {
		//Debug.Log (col.gameObject.tag);
		if (col.gameObject.name == "TerrainMaze") {
			Instantiate (explosion, transform.position,Quaternion.identity);
			//Destroy (gameObject);
		}
		else if (col.gameObject.tag == "hitBox") {
			//Debug.Log ("hit");
			Instantiate (explosionHit, transform.position,Quaternion.identity);
			col.gameObject.GetComponent<IsHit>().hit(damage);
			//Destroy (gameObject);
		}
	}

}
