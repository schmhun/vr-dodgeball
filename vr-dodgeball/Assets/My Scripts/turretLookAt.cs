using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretLookAt : MonoBehaviour {
    public GameObject target;
    public float turn_speed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotateTowards(target.transform.position);
	}
    protected void rotateTowards(Vector3 to)
    {

        Quaternion _lookRotation = Quaternion.LookRotation((to - transform.position).normalized);

        //over time
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);

    }
}
