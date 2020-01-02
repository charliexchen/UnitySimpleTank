using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float count=0;
	public float tankcount=0;
	public float quadcounter=60;
	public float tankcounter=70;
	public GameObject tank;
	public GameObject quad;
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tankcount -= Time.deltaTime;
		count -= Time.deltaTime;
		if (tankcount < 0) {
			
			GameObject ene=GameObject.Instantiate (tank,transform.position-10*(transform.rotation*Vector3.left),transform.rotation) as GameObject;
			ene.GetComponent<enemyStat> ().target = target;
			tankcount = tankcounter;
			GameObject[] radar=GameObject.FindGameObjectsWithTag ("Global");
			radar[0].GetComponent<radar>().reset();
			radar[1].GetComponent<radar>().reset ();
		}
		if (count < 0) {

			GameObject ene=GameObject.Instantiate (quad,transform.position+10*(transform.rotation*Vector3.left),transform.rotation) as GameObject;
			ene.GetComponent<enemyStat> ().target = target;
			count = quadcounter;
			GameObject[] radar=GameObject.FindGameObjectsWithTag ("Global");
			radar [0].GetComponent<radar> ().reset();
			radar[1].GetComponent<radar>().reset ();
		}
	}
}
