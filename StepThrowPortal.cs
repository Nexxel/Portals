using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThrowPortal : MonoBehaviour {

	private Vector3 velocity;
	private Rigidbody rb;

    void OnTriggerEnter (Collider other)
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
//                print("Velocity without reflect: " + velocity);
                velocity = Vector3.Reflect(velocity, this.transform.forward);
//                print("Velocity with reflect: " + velocity);
                velocity = this.transform.InverseTransformDirection(velocity);
//                print("this.transform.InverseTransformDirection(velocity): " + velocity);
                velocity = CreatePortal.oldRight.transform.TransformDirection(velocity);
//                print("CreatePortal.oldRight.transform.TransformDirection(velocity): " + velocity);
                other.transform.position = CreatePortal.oldRight.transform.position - CreatePortal.oldRight.transform.forward*1.5f;
                if (transform.rotation.y == CreatePortal.oldRight.transform.rotation.y)
                {
                    other.transform.Rotate(new Vector3(0, 180, 0));
                }
                rb.velocity = velocity;
			} else {
                if(velocity.y <= (-48))
                {
                    velocity.y = (-50);
                }
//                print("Velocity without reflect: " + velocity);
                velocity = Vector3.Reflect(velocity, this.transform.forward);
//                print("Velocity with reflect: " + velocity);
                velocity = this.transform.InverseTransformDirection(velocity);
//                print("this.transform.InverseTransformDirection(velocity): " + velocity);
                velocity = CreatePortal.oldLeft.transform.TransformDirection(velocity);
                //                print("CreatePortal.oldRight.transform.TransformDirection(velocity): " + velocity);
                other.transform.position = CreatePortal.oldLeft.transform.position - CreatePortal.oldLeft.transform.forward*1.5f;
                if (transform.rotation.y == CreatePortal.oldLeft.transform.rotation.y)
                {
				    other.transform.Rotate (new Vector3 (0, 180,0));
                }
                rb.velocity = velocity;
            }
//               EnableCollider(other, false);
//                Wait(1f);
//                EnableCollider(other, true);
            print("Velocity: " + rb.velocity);
		}
	}

    private void EnableCollider(Collider other,bool enable)
    {
        other.enabled = enable;
        print("Collider: " + enable);
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
