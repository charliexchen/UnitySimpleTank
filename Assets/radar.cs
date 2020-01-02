using UnityEngine;
using System.Collections;

public class radar : MonoBehaviour {
	ArrayList pointers=new ArrayList();
	public GameObject point;
	public string tag="Enemy";
	// Use this for initialization
	void Start () {
		reset();
		//pointers = new ArrayList[0];
	}
	public void reset() {

		int counter = transform.childCount;
		for (int j = counter - 1; j >= 0; j--) {
			var child = transform.GetChild (j);
			Destroy (child.gameObject);
		}
		pointers.Clear();
		GameObject[] radarlist=GameObject.FindGameObjectsWithTag (tag);	
		//Debug.Log ("enemy no"+transform.childCount);
		for (int i = 0;  i <radarlist.Length;i++) {
			GameObject newpoint=Instantiate(point);
			newpoint.transform.SetParent (transform);
			newpoint.GetComponent<Pointer>().target = radarlist [i];
			pointers.Add(newpoint);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
