using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {
	public GameObject target;
	Vector2 screenPos;
	Vector2 screenPosCentred;
	public float offset=0.1f;

	// Use this for initialization
	void Start () {
		offset = offset * Screen.width;
	}

	// Update is called once per frame
	void Update ()
	{	
		if (target) {
			screenPos = Camera.main.WorldToScreenPoint (target.transform.position);
			if (screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y <= Screen.height && screenPos.y >= 0) {
				GetComponent<RectTransform> ().rotation = Quaternion.EulerAngles (180, 0, 0);
				GetComponent<RectTransform> ().position = new Vector2 ((screenPos.x), (screenPos.y) + Screen.height / 20);
			} else {
				screenPosCentred = new Vector2 ((2 * screenPos.x - Screen.width), (2 * screenPos.y - Screen.height));
				GetComponent<RectTransform> ().rotation = Quaternion.EulerAngles (0, 0, Mathf.Atan2 (screenPosCentred.y, screenPosCentred.x) - 90);
				GetComponent<RectTransform> ().position = new Vector2 ((Mathf.Clamp (screenPos.x, offset, Screen.width - offset)), (Mathf.Clamp (screenPos.y, offset, Screen.height - offset)));

			}
		}
	}
}
