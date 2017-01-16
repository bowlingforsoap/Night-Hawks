using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class RadioController : MonoBehaviour {
	public AudioClip[] audioClips;
	public AudioSource audioSource;

	private int prevSong;

	// Use this for initialization
	void Start () {
		prevSong = Random.Range (0, audioClips.Length);
		audioSource.clip = audioClips [prevSong];
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeTune() {
		int nextSong = Mathf.Clamp (prevSong + 1, 0, audioClips.Length);
		audioSource.clip = audioClips [nextSong];
		audioSource.Play ();
		prevSong = nextSong;
	}
}
