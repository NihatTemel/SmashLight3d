using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOrganiser : MonoBehaviour
{

    public int index = 0;
    [SerializeField] GameObject Player;

   public int Limit = 245;
   public float distance;

    private void Start()
    {
        distance = transform.GetChild(1).transform.position.x - transform.GetChild(0).transform.position.x;
    }

    void MapOrganise() 
    {
        
        if (Player.transform.position.x > Limit) 
        {
            PlayerPrefs.SetInt("ball", PlayerPrefs.GetInt("ball") + 10);
            Player.GetComponent<BoyController>().movespeed += 1.5f;
            Limit += 245;
            var pos = transform.GetChild(index).transform.position;
            pos.x += (distance*3);
            transform.GetChild(index).transform.position = pos;
            if (index < 2)
                index++;
            else
                index = 0;
        }
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        MapOrganise();
    }
}
