using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = other.transform.position + new Vector3(0, 10, 0);
    }
}
