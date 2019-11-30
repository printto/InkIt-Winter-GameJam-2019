using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkShooting : MonoBehaviour
{

    [SerializeField] InkProjetile inkProjectile;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(inkProjectile.gameObject, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        }
    }

}
