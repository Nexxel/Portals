using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public GameObject player;
    public Transform groundChecker;
	public LayerMask ground;

    [Range(1,10)]
	public float speed = 10;
    [Range(0, 360)]
    public float rotationSpeed = 90;
    [Range(1, 8)]
    public float jumpForce = 10;
	// Update is called once per frame
	void Update ()
	{
        // Rotate up or down with the mouse
		player.transform.Rotate (new Vector3(-Input.GetAxis ("Mouse Y"),0,0)*rotationSpeed*Time.deltaTime);
        // Go left
		if (Input.GetKey (KeyCode.A)) {
			player.transform.Rotate (Vector3.down* rotationSpeed * Time.deltaTime);
		}
        // Go right
        if (Input.GetKey (KeyCode.D)) {
			player.transform.Rotate (Vector3.up*rotationSpeed*Time.deltaTime);
		}
        // Go back
        if (Input.GetKey (KeyCode.S)) {
			player.transform.Translate (Vector3.back*speed*Time.deltaTime);
		}
        // Go forward
        if (Input.GetKey (KeyCode.W)) {
			player.transform.Translate (Vector3.forward*speed*Time.deltaTime);
		}
        // Jump if my player is in the floor
        if (Input.GetKey (KeyCode.Space) && CheckGround()) {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce (new Vector3(0,jumpForce*rb.mass,0),ForceMode.Impulse);
		}
	}

    // We check if we have in the floor in order to jump
    public bool CheckGround()
    {
        bool checker = false;
        if (Physics.OverlapSphere(groundChecker.position, 0.01f, ground).Length > 0)
        {
            checker = true;
        }
        print("Checker: " + checker);
        return checker;
    }
}
