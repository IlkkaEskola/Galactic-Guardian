using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 5;

    private void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));  
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if(Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if(hit.collider.tag == "Environment")
            {
                print("It's the environment");
            }
            else if(hit.collider.tag == "Enemy")
            {
                print("It's the enemy");
            }
        }

    }
}
