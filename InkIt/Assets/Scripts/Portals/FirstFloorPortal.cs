using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorPortal : MonoBehaviour
{

    [SerializeField] CharacterController player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered the first gate");
        player.enabled = false;
        player.transform.position = transform.position + new Vector3(0, 10, 0);
        player.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided the first gate");
        player.enabled = false;
        player.transform.position = transform.position + new Vector3(0, 10, 0);
        player.enabled = true;
    }
}
