using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public float speed = 10f;

	// Use this for initialization
	void Start () {
        // Turn off the cursor, so you don't see it on the screen.
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0f, translation);
        
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }	
	}
}
