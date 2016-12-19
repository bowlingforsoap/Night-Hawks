using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float rotationSpeed;
	public float movementSpeed;
	public Transform cameraTransform;

	private Vector2 prevMousePosition;
	private Vector2 prevMouseDelta;


	// Use this for initialization
	void Start () {
		prevMousePosition.x = Screen.width / 2;
		prevMousePosition.y = Screen.height / 2;
		prevMouseDelta = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
        cameraTransform.Translate(cameraTransform.forward * Input.GetAxis("Vertical") * movementSpeed);
        cameraTransform.Translate(cameraTransform.right * Input.GetAxis("Horizontal") * movementSpeed);

        cameraTransform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);
        cameraTransform.Rotate(cameraTransform.right, Input.GetAxis("Mouse Y") * rotationSpeed);
    }
}
