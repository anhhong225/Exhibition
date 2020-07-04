using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour
{
    public GameObject HingePoint;
    public float grappleThrowForce = 5000f;
    public float grappleLockTime = 0.5f;
    GameObject activeJoint;
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        
	}

    public void FireGrapple()
    {
        ReleaseGrapple();
        activeJoint = Instantiate(HingePoint, gameObject.transform.position, Quaternion.identity) as GameObject;
        JointController jointController = activeJoint.GetComponent<JointController>();
        jointController.SetLastJointAnchor(rb);
        jointController.LaunchFirstJoint(grappleThrowForce, gameObject.transform.right, grappleLockTime);
    }

    public void ReleaseGrapple()
    {
        if (activeJoint != null)
        {
            JointController jointController = activeJoint.GetComponent<JointController>();
            jointController.ReleaseLastJointAnchor();
        }
    }

}
