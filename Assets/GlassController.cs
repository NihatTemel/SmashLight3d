using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassController : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 directionpos;
    public float MoveSpeed;

    [SerializeField] bool Side = false;
    [SerializeField] bool spin = false;
    public float xx;
    public float yy;
    public float zz;

    void Start()
    {
        if (Side) 
        {
            StartPos = transform.position;
            Newpos();
        }
        
    }


    void Newpos()
    {
        float zz = Random.Range(-2.5f, 2.5f);
        directionpos = StartPos;
        var newpos = directionpos;
        newpos.z = zz;
        directionpos = newpos;
    }


    void FixedUpdate()
    {

        if (Side) 
        {
            transform.position = Vector3.MoveTowards(transform.position, directionpos, MoveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, directionpos) < 0.2f)
            {
                Newpos();
            }
        }
        if (spin) 
        {
            transform.Rotate(xx, yy, zz);
        }
        
    }
}
