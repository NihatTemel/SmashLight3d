using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : MonoBehaviour
{


    [SerializeField] float Movespeed;
    void Update()
    {
        transform.position += new Vector3(-Movespeed, 0, 0);
    }

    public void FixedUpdate()
    {
        if (this.transform.childCount == 0)
            Debug.Log("end");
    }

}
