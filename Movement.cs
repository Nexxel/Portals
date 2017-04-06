using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public GameObject player;
	public GameObject ground;

	private float speed = 10;
	// Update is called once per frame
	void Update ()
	{
		player.transform.Rotate (new Vector3(-Input.GetAxis ("Mouse Y"),Input.GetAxis ("Mouse X"),0)*Time.deltaTime*speed);
		if (Input.GetKey (KeyCode.A)) {
			player.transform.Translate (Vector3.left*Time.deltaTime);
		} if (Input.GetKey (KeyCode.D)) {
			player.transform.Translate (Vector3.right*Time.deltaTime);
		} if (Input.GetKey (KeyCode.S)) {
			player.transform.Translate (Vector3.back*Time.deltaTime);
		} if (Input.GetKey (KeyCode.W)) {
			player.transform.Translate (Vector3.forward*Time.deltaTime);
		} if (Input.GetKey (KeyCode.Space)) {
			player.transform.Translate (Vector3.up*Time.deltaTime*5);
		}
	}
}
