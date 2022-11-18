using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShattedScript : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(8f, transform.position, 1.5f, 0.05f, ForceMode.Impulse);
            }
        }
    }


}
