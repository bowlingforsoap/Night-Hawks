using UnityEngine;
using System.Collections;

public class RecalculateNormals : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
