using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour {

	public GameObject leftPortal;
	public GameObject rightPortal;

	public static GameObject oldLeft;
	public static GameObject oldRight;
	public static RaycastHit hit;
	
	// Update is called once per frame
	void Update ()
	{
        // We have theportals with the tag Left portal and Right portal and we look for those portals 
		oldLeft = GameObject.FindGameObjectWithTag ("Left portal");
		oldRight = GameObject.FindGameObjectWithTag ("Right portal");
        // As in Portal, with the left click we generate a kind of portal.
        // And with the right click, another one.
		if (Input.GetMouseButton (0)) {
			oldLeft = throwPortal(leftPortal, oldLeft);
		} else if(Input.GetMouseButton (1)){
			oldRight = throwPortal (rightPortal, oldRight);
		}
	}

	public GameObject throwPortal (GameObject portal, GameObject destroyedPortal)
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast (ray, out hit)){
            if (hit.collider.gameObject.CompareTag("Terrain"))
            {
                // If there is another portal, of the same type, destroy it and them instantiate another
                // where the raycast impact.
                if (destroyedPortal != null)
                {
                    DestroyImmediate(destroyedPortal);
                }
                portal = Instantiate (portal,hit.point,Quaternion.LookRotation (-hit.normal));
            }
		}
		return portal;
	}
}
