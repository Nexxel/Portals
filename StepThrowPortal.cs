using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThrowPortal : MonoBehaviour {

	private Vector3 velocity;
	private Rigidbody rb;

    void OnTriggerEnter (Collider other)
	{
        GameObject left = CreatePortal.oldLeft;
        GameObject right = CreatePortal.oldRight;
        if(left != null && right != null)
        {
		    if (other.CompareTag ("Player")) {
			    rb = other.gameObject.GetComponent<Rigidbody>();
                print("First rb: " + rb + "\tVelocity: " + rb.velocity);
			    velocity = rb.velocity; 
			    if (this.CompareTag ("Left portal")) {
                    if (velocity.y <= (-48))
                    {
                        velocity.y = (-50);
                    }
                    // We reflect the incoming velocity in the portal
                    velocity = Vector3.Reflect(velocity, this.transform.forward);
                    // We transform it in local coordinates
                    velocity = this.transform.InverseTransformDirection(velocity);
                    // We align the velocity vector with the other portal 
                    velocity = CreatePortal.oldRight.transform.TransformDirection(velocity);
                    // Teletransport your player in front of the other portal
                    other.transform.position = right.transform.position - right.transform.forward*1.5f;
                    // If you have to turn around your player, do it
                    if (transform.rotation.y == right.transform.rotation.y)
                    {
                        other.transform.Rotate(new Vector3(0, 180, 0));
                    }
                    // Update velocity
                    rb.velocity = velocity;
			    }
                else {
                    // As we have not the engine of Valve, our player can touch the floor as it falls and lose velocity.
                    // For this reason we limit the velocity if our player is falling down
                    if(velocity.y <= (-48))
                    {
                        velocity.y = (-50);
                    }
                    // We reflect the incoming velocity in the portal
                    velocity = Vector3.Reflect(velocity, this.transform.forward);
                    // We transform it in local coordinates
                    velocity = this.transform.InverseTransformDirection(velocity);
                    // We align the velocity vector with the other portal 
                    velocity = CreatePortal.oldLeft.transform.TransformDirection(velocity);
                    // Teletransport your player in front of the other portal
                    other.transform.position = left.transform.position - left.transform.forward*1.5f;
                    // If you have to turn around your player, do it
                    if (transform.rotation.y == left.transform.rotation.y)
                    {
				        other.transform.Rotate (new Vector3 (0, 180,0));
                    }
                    // Update velocity
                    rb.velocity = velocity;
                }
		    }
        }
	}
}
