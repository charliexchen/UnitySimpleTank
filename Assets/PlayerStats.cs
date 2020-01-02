using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public float maxhp = 1000;
	public float hp;
	public float reload = 1;
	public float timer = 0;
    public bool loaded=false;
	bool dying = false;
	public int Ammo=10;
	public string text="";
	public float score;
	public int adrop;
	public int hdrop;
	public GameObject crate;
	// Use this for initialization
	void Start () {
		hp = maxhp;
		GameObject[] end = GameObject.FindGameObjectsWithTag ("Global");
		end[0].GetComponent<radar>().reset();
	}
	public void damage (float hit){
		hp -= hit;
		if (hp < 0 && dying==false) {
			dying = true;
			GameObject[] end = GameObject.FindGameObjectsWithTag ("Global");

			var child = transform.GetChild(0).GetChild(0);
			child.tag = "Untagged";

			end[0].GetComponent<radar>().reset();
			end[1].GetComponent<radar>().reset();
			if (crate) {
				GameObject obj = Instantiate (crate,transform.GetChild(0).position,Quaternion.identity) as GameObject;
				obj.GetComponent<repair> ().hp = hdrop;
				obj.GetComponent<repair> ().ammo = adrop;
			}
			GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ().newline (text);
			GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ().score +=score;
			Destroy (gameObject);


		}
	}
	public void resetReload(){ 
			timer = 0;
			loaded = false;
		    Ammo -= 1;
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (hp);
		timer += Time.deltaTime;
		if (timer > reload) {
			if (loaded == false && Ammo>0) {
				loaded = true;
			}
		}
	}
}
