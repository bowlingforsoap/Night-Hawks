using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour {
	public GameObject origin;
	public AudioMixerSnapshot fanSnapshot;
	public AudioMixerSnapshot masterSnapshot;

	// Use this for initialization
	void Start () {
		Ray ray = new Ray (origin.transform.position, origin.transform.forward);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("Sound"))) {
			Debug.Log ("Huston, we have a hit!");
			// TODO: introduce a way to differenciate between objects on Sound layer
			fanSnapshot.TransitionTo(1);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
