using UnityEngine;
using System.Collections;

public class thirdPersonCamera : MonoBehaviour
{
	public GameObject target;
	public Transform tester;
	public float rotatespeed = 5f;
	Vector3 offset;
	// Use this for initialization
	public Vector3 cameraPos = new Vector3 (0, 50, -50);
	public float range = 70;
	public float cam_dampening = 0.8f;
	public double cursor_weight = 0.6F;
	private Vector3 cameraTarget;
	private float cameraAngle = 0;
	public Vector3 objectpoint = new Vector3 (0, 10, 0);
	public Collider ground;
	public float turnspeed = 90;

	void Start ()
	{
		//Screen.showCursor = false;
		cameraTarget = target.transform.position + cameraPos;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//Debug.Log(transform.position.y.ToString());

		Plane playerPlane = new Plane (Vector3.up, new Vector3 (0, 0, 0));
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float hitdist = 0.0f;
		RaycastHit hit;

		if (ground.Raycast (ray, out hit, 1000.0F)) {
			Vector3 targetPoint = hit.point;
			transform.LookAt (0.5F * (target.transform.position) + 0.5F * targetPoint);
			target.transform.LookAt (targetPoint);
			tester.position = (targetPoint);

			float turn = Mathf.Atan2 (2 * Input.mousePosition.x - Screen.width, 2 * Input.mousePosition.y - Screen.height);
			if (Mathf.Abs (turn) > 0.1) {
				float distweight = Mathf.Pow (Vector3.Magnitude (target.transform.position - targetPoint) / 10, 3);
				float offset = Mathf.Pow (Mathf.Atan2 (2 * Input.mousePosition.x - Screen.width, 2 * Input.mousePosition.y - Screen.height), 3);
				offset = Mathf.Clamp (offset, -0.9f, 0.9f);
				distweight = Mathf.Clamp (distweight, -0f, 0.9f);
				cameraAngle += Mathf.Clamp(turnspeed * offset * distweight, -100f, 100f) * Time.deltaTime;
			}
		} else if (playerPlane.Raycast (ray, out hitdist)) {
			Vector3 targetPoint = ray.GetPoint (hitdist);
			transform.LookAt (0.6F * (target.transform.position) + 0.4F * targetPoint);
			target.transform.LookAt (targetPoint);
			tester.position = (targetPoint);
			float turn = Mathf.Atan2 (2 * Input.mousePosition.x - Screen.width, 2 * Input.mousePosition.y - Screen.height);
			if (Mathf.Abs (turn) > 0.1) {
				float distweight = Mathf.Pow (Vector3.Magnitude (target.transform.position - targetPoint) / 10, 3);
				float offset = Mathf.Pow (Mathf.Atan2 (2 * Input.mousePosition.x - Screen.width, 2 * Input.mousePosition.y - Screen.height), 3);
				distweight = Mathf.Clamp (distweight, -0f, 0.9f);
				offset = Mathf.Clamp (offset, -0.9f, 0.9f);
				cameraAngle += turnspeed * offset * Time.deltaTime * distweight;
			}
		}
		cameraTarget = (target.transform.position) + Quaternion.Euler (0, cameraAngle, 0) * cameraPos;
		transform.position = 0.1F * cameraTarget + 0.9F * transform.position;
		
	}

	float closeToSide ()
	{
		float offset = (2 * Input.mousePosition.x - Screen.width) / Screen.width;

		return offset * offset * offset;
	}
}
