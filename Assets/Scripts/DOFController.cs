using UnityEngine;
using System.Collections;

using UnityEngine.Audio;

public class DOFController : MonoBehaviour {
	public GameObject origin;
	public GameObject target;

	public AudioMixerSnapshot fanSnapshot;
	public AudioMixerSnapshot masterSnapshot;

	private bool soundWasHit = false;
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (origin.transform.position, origin.transform.forward);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit)) {
			Debug.DrawRay (origin.transform.position, origin.transform.forward * 100, Color.cyan);

			// For DOF target
			target.transform.position = hit.point; 

			// Sound atenuation on look at
			if (hit.collider.CompareTag ("Sound")) {
				Debug.Log ("Huston, we have a hit!");
				// TODO: introduce a way to differenciate between objects on Sound layer
				fanSnapshot.TransitionTo (1000f);

				soundWasHit = true;
			} else if (soundWasHit) {
				masterSnapshot.TransitionTo (1000f);

				soundWasHit = false;
			}
		} else {
			Debug.DrawRay (origin.transform.position, origin.transform.forward * 100, Color.red);
		}
	}
}
