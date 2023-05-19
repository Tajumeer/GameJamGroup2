using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticked : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // creates joint
        FixedJoint2D joint = gameObject.GetComponent<FixedJoint2D>();
        // sets joint position to point of contact
        joint.anchor = col.contacts[0].point;
        // conects the joint to the other object
        joint.connectedBody = col.contacts[0].collider.transform.GetComponentInParent<Rigidbody2D>();
        //joint.connectedBody = col.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody2D>();
        // Stops objects from continuing to collide and creating more joints
        joint.enableCollision = false;
    }
}
