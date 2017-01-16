using UnityEngine;
using System.Collections;

using UnityEngine.Audio;

using UnityEngine.UI;

public class LookAtController : MonoBehaviour {
	public GameObject origin;
	public GameObject target;

	public AudioMixerSnapshot fanSnapshot;
	public AudioMixerSnapshot masterSnapshot;

	public Image radioProgressCirle;
	public float loadSpeed;
	public RadioController radioController;

	private bool soundWasHit = false;

	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (origin.transform.position, origin.transform.forward);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit)) {
			Debug.DrawRay (origin.transform.position, origin.transform.forward * 100, Color.cyan);

			// DOF target
			target.transform.position = hit.point; 

			// Sound atenuation on look at
			if (hit.collider.CompareTag ("Sound")) {
				//Debug.Log ("Huston, we have a hit!");
				// TODO: introduce a way to differenciate between objects on Sound layer
				fanSnapshot.TransitionTo (1);

				soundWasHit = true;
			} else if (soundWasHit) {
				masterSnapshot.TransitionTo (1);

				soundWasHit = false;
			}

			// Change song by looking at Radio
			if (hit.collider.CompareTag ("Radio")) {
				radioProgressCirle.enabled = true;
				radioProgressCirle.fillAmount = Mathf.Lerp (radioProgressCirle.fillAmount, 1f, loadSpeed);
				//Debug.Log ("fill amount: " + radioProgressCirle.fillAmount);
				if (radioProgressCirle.fillAmount >= (1f - loadSpeed)) {
					radioProgressCirle.fillAmount = 0f;

					Debug.Log ("New Song!");

					radioController.ChangeTune ();
				}
			}
		} else {
			Debug.DrawRay (origin.transform.position, origin.transform.forward * 100, Color.red);
		}
	}
}
