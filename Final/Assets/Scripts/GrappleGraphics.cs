using UnityEngine;
using System.Collections;

public class GrappleGraphics : MonoBehaviour
{
    public Transform target;
    LineRenderer lr;
	void Start ()
    {
        lr = GetComponent<LineRenderer>();
	}
	
	void Update ()
    {
        if(target != null)
        {
            lr.SetPosition(0, gameObject.transform.position);
            lr.SetPosition(1, target.transform.position);
        }
	}
}
