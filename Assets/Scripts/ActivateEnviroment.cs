using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnviroment : MonoBehaviour
{
   
    void Start()
    {
        Activate();
    }


    void Activate() 
    {
        int n = transform.childCount;

        for (int i = 0; i < n; i++)
        {
            if (Random.Range(0, 100) < 50) 
            {
                transform.GetChild(i).transform.GetChild(Random.Range(0, 6)).gameObject.SetActive(true);
            }
        }

    }


}
