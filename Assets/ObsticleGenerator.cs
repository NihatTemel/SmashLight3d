using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleGenerator : MonoBehaviour
{

    [SerializeField] bool survive;


    public bool refnode;

    void Start()
    {
        int n = transform.childCount;

        for (int i = 0; i < n; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (!survive) 
        {
            if (PlayerPrefs.GetInt("finish") == 0 )
            {
                int pos = Random.Range(0, n);
                PlayerPrefs.SetInt(this.gameObject.name, pos);
                Invoke("finishtozero", 1);
            }


            transform.GetChild(PlayerPrefs.GetInt(this.gameObject.name)).gameObject.SetActive(true);
        }
        else 
        {
            int pos = Random.Range(0, n);
            transform.GetChild(pos).gameObject.SetActive(true);

           

        }
        if(!refnode)
        Invoke("DisableThis", 20);
        
    }

    void DisableThis() 
    {
       // this.gameObject.SetActive(false);
    
    }

    

    void finishtozero() 
    {
        PlayerPrefs.SetInt("finish", 1);
    }
}
