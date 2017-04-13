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
        // If we don't find a portal of the other type, we keep it in its normal color (Red or blue in Portal) 
		if (portals.Length == 0) {
			this.GetComponent <Renderer> ().material = basicMaterial;
		}
        // If we find a portal of the other type, we take the camera of the other portal
        else {
			this.GetComponent <Renderer> ().material = portalMaterial;
		}
	}
}
