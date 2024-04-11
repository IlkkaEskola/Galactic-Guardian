using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        transform.rotation = target.rotation;
    }
}
