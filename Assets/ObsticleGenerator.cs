using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleGenerator : MonoBehaviour
{
    
    void Start()
    {
        int n = transform.childCount;

        if (PlayerPrefs.GetInt("finish") == 0) 
        {
            int pos = Random.Range(0, n);
            PlayerPrefs.SetInt(this.gameObject.name, pos);
            Invoke("finishtozero", 1);
        }
        

        transform.GetChild(PlayerPrefs.GetInt(this.gameObject.name)).gameObject.SetActive(true);
    }

    void finishtozero() 
    {
        PlayerPrefs.SetInt("finish", 1);
    }
}
