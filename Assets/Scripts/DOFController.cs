using UnityEngine;
using System.Collections;

public class DOFController : MonoBehaviour {
	public GameObject origin;
	public GameObject target;
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (origin.transform.position, origin.transform.forward);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit, 1000f)) {
			Debug.DrawRay (origin.transform.position, origin.transform.forward * 100, Color.cyan);

			target.transform.position = hit.point;
		} else {
			Debug.DrawRay (origin.transform.position, origin.transform.forward * 100, Color.red);
		}
	}
}
