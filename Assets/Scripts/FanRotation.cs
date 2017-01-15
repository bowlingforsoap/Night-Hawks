using UnityEngine;
using System.Collections;

public class FanRotation : MonoBehaviour {
	public float rotationSpeed;
	public Transform movingPart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movingPart.transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}
}
