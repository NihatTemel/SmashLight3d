using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoyController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float movespeed;



    [SerializeField] GameObject myCam;
    [SerializeField] float Shakepower;
    [SerializeField] float Shaketime;

    bool finished = false;

    [SerializeField] GameObject WinPanel;
    [SerializeField] Animator anim;
    void Start()
    {
        
    }


    void Animations() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {

            anim.SetInteger("anim", 1);
            anim.Play("sq", -1, 0f);
            anim.Play("sq", -1, 0f);


        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetInteger("anim", 0);

        }
    }


    void Movement() 
    {
        if (!finished) 
        {
            rb.velocity = new Vector3(movespeed, 0, 0);
        }
    }

    
    void Update()
    {
        Animations();
    }


    private void FixedUpdate()
    {
        Movement();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "engel")
        {
            Debug.Log("engel hit player");
            other.gameObject.GetComponent<Collider>().enabled = false;
            myCam.GetComponent<Camera>().DOShakeRotation(Shaketime, Shakepower, fadeOut: true);
            PlayerPrefs.SetInt("ball", PlayerPrefs.GetInt("ball") - 3);
        }
        if (other.tag == "obs")
        {
            Debug.Log("engel hit player");
            other.gameObject.GetComponent<Collider>().enabled = false;
            myCam.GetComponent<Camera>().DOShakeRotation(Shaketime, Shakepower, fadeOut: true);
            PlayerPrefs.SetInt("ball", PlayerPrefs.GetInt("ball") - 3);
        }
        if (other.tag == "Finish")
        {
            WinPanel.SetActive(true);
            PlayerPrefs.SetInt("finish", 0);
            Time.timeScale = 0;
            
        }
    }

}
