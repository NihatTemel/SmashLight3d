using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EngelScript : MonoBehaviour
{

    [SerializeField] bool Spatula;
    [SerializeField] bool Pervane;
    [SerializeField] bool Rotate;
    [SerializeField] bool MoveLoop;
    [SerializeField] bool RotateAround;

    [SerializeField] float RotateSpeed;
    [SerializeField] float MoveSpeed;
    [SerializeField] float SpatulaRotateSpeed;
    [SerializeField] float SpatulaRotateAngle;
    [SerializeField] float RotateAroundSpeed;

    [SerializeField] Material[] mats;

    
    void Start()
    {
        if (!Pervane) 
        {
            int colorno = Random.Range(0, 4);
            GetComponent<MeshRenderer>().material = mats[colorno];
            int Childno = transform.GetChild(0).transform.childCount;
            for (int k = 0; k < Childno; k++)
            {
                transform.GetChild(0).transform.GetChild(k).transform.gameObject.GetComponent<MeshRenderer>().material = mats[colorno];
            }
        }
        
        else 
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(-7.0f, 5.0f));

            int ColorIndex = Random.Range(0, 4);
            for (int i = 0; i < 6; i++)
            {
                transform.GetChild(i).transform.gameObject.GetComponent<MeshRenderer>().material = mats[ColorIndex];
                int Childno = transform.GetChild(i).transform.GetChild(0).transform.childCount;
                for (int k = 0; k < Childno; k++)
                {
                    transform.GetChild(i).transform.GetChild(0).transform.GetChild(k).transform.gameObject.GetComponent<MeshRenderer>().material = mats[ColorIndex];
                }
            }
        }
        if (Spatula) 
        {
            InvokeRepeating("SpatulaMove", 0, 41414);
            //SpatuleMove();
        }
        if (MoveLoop) 
        {
            MoveYoyo();
        }
        if (RotateAround) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(-6.0f, 4.0f));
        }
    }

   
    void PervaneRotate() 
    {
        transform.Rotate(RotateSpeed, 0, 0);
    }

    void SpatulaMove() 
    {
        transform.DORotate(new Vector3(-90, 0, SpatulaRotateAngle), SpatulaRotateSpeed,RotateMode.Fast).SetLoops(999,LoopType.Yoyo);
        //SpatulaRotateSpeed *= -1;
        if (SpatulaRotateAngle > 0) 
        {

            //SpatulaRotateAngle = 0;

        }
        else 
        {
           // SpatulaRotateAngle = 180;
        }
    }


    void MoveYoyo() 
    {
        transform.DOMove(transform.GetChild(1).transform.position, MoveSpeed).SetLoops(999, LoopType.Yoyo);
    }


    void FixedUpdate()
    {
        if (Pervane) 
        {
            PervaneRotate();
        }
        else if (Spatula) 
        {
           
        }
        if (RotateAround) 
        {
            transform.Rotate(0, 0, RotateAroundSpeed);
        }
    }
}
