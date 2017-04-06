using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Material basicMaterial;
	public Material portalMaterial;

	private GameObject[] portals;
	
	// Update is called once per frame
	void Update ()
	{
		if (this.gameObject.tag == "Left portal") {
			portals = GameObject.FindGameObjectsWithTag ("Right portal");
		} else {
			portals = GameObject.FindGameObjectsWithTag ("Left portal");
		}
		if (portals.Length == 0) {
			this.GetComponent <Renderer> ().material = basicMaterial;
		} else {
			this.GetComponent <Renderer> ().material = portalMaterial;
		}
	}
}
