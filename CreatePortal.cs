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
		oldLeft = GameObject.FindGameObjectWithTag ("Left portal");
		oldRight = GameObject.FindGameObjectWithTag ("Right portal");
		if (Input.GetMouseButton (0)) {
			if (oldLeft != null) {
				DestroyImmediate (oldLeft);
			}
			oldLeft = throwPortal(leftPortal);

		} else if(Input.GetMouseButton (1)){
			if (oldRight != null) {
				DestroyImmediate (oldRight);
			}
			oldRight = throwPortal (rightPortal);
		}
	}

	public GameObject throwPortal (GameObject portal)
	{
//		int x = Screen.width/2;
//		int y = Screen.height/2;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast (ray, out hit)){
            if (hit.collider.gameObject.CompareTag("Terrain"))
            {
			    portal = Instantiate (portal,hit.point,Quaternion.LookRotation (-hit.normal));
            }
		}
		return portal;
	}
}
