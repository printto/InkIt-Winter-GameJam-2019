using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkProjetile : MonoBehaviour
{

    [SerializeField] GameObject projectorPrefab;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] float projectorXRotationLimit = 0.2f;
    [SerializeField] List<Material> projectorMaterials;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        Quaternion projectorRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        if (projectorRotation.x >= projectorXRotationLimit) projectorRotation.x = projectorXRotationLimit;
        else if (projectorRotation.x <= -projectorXRotationLimit) projectorRotation.x = -projectorXRotationLimit;
        Debug.Log(projectorRotation);
        if (projectorPrefab != null)
        {
            GameObject temp = Instantiate(projectorPrefab, transform.position, projectorRotation);
            if (projectorMaterials != null)
            {
                if (projectorMaterials.Count > 0)
                {
                    if (temp.GetComponentInChildren<Projector>() != null)
                        temp.GetComponentInChildren<Projector>().material = projectorMaterials[Random.Range(0, projectorMaterials.Count)];
                }
            }
            temp.GetComponentInChildren<Projector>().transform.SetParent(other.transform);
        }
        if(explosionParticle != null)
        {
            Instantiate(explosionParticle, transform.position, new Quaternion());
        }
        Destroy(gameObject);
    }

}
