using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurviveObsController : MonoBehaviour
{

    [SerializeField] Transform Player;
    [SerializeField] GameObject ObsNode;

    int limit = 30;

    GameObject child;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

    

    void SpawnObs() 
    {
        


        if (Player.position.x > limit) 
        {
            limit += 30;
            GameObject newnode = Instantiate(ObsNode);
            newnode.transform.parent = this.transform;
            newnode.GetComponent<ObsticleGenerator>().refnode = false;
            var pos = ObsNode.transform.position;
            pos.x = limit + 150;
            newnode.transform.position = pos;

            //StartCoroutine(LateDelete());

            
        }

    }

    IEnumerator LateDelete() 
    {
        child = transform.GetChild(0).gameObject;
        yield return new WaitForSeconds(5);
        Destroy(transform.GetChild(0));
        

    }


    void FixedUpdate()
    {
        SpawnObs();
    }
}
