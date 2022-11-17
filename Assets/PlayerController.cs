using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ThrowBall;
    Rigidbody rb;
    Vector3 dir;

    
    public GameObject Cam;

    public int TotalBall = 10;
    public float MoveSpeed;

    public bool finished = false;

    [SerializeField] GameObject Golem;

    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject WinPanel;



    [SerializeField] GameObject myCam;
    [SerializeField] float Shakepower;
    [SerializeField] float Shaketime;


    void Start()
    {
        dir = transform.position;
        rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetInt("score", 0);
        TotalBall = PlayerPrefs.GetInt("ball");
    }


 


    void ThrowingBall()
    {
        if (Input.GetMouseButtonDown(0) && TotalBall>0)
        {
            TotalBall--;
            PlayerPrefs.SetInt("ball", PlayerPrefs.GetInt("ball") - 1);
            //transform.localScale = transform.localScale * 9 / 10;
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(myCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
              
                dir = hitInfo.point;
                Instantiate(ThrowBall, transform.position, Quaternion.LookRotation(hitInfo.point)).GetComponent<ThrowBallScript>().direction = (hitInfo.point - transform.position);
                ThrowBall.transform.LookAt(hitInfo.point);
                ThrowBall.GetComponent<ThrowBallScript>().direction = (hitInfo.point - transform.position);
                

            }
        }

    }
    void Update()
    {
        ThrowingBall();
        


    }

  
    private void FixedUpdate()
    {
        TotalBall = PlayerPrefs.GetInt("ball");
        LoseGame();
    }
    void LoseGame()
    {
        int n = PlayerPrefs.GetInt("ball");
        if (n < 1)
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "end") 
        {
            Debug.Log("xx");
            finished = true;
            TotalBall += 20;
            collision.gameObject.SetActive(false);
            Golem.SetActive(true);

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end") 
        {
            Golem.SetActive(true);
            Debug.Log("xx");
            finished = true;
            TotalBall += 20;
            other.gameObject.SetActive(false);
        }
        /*
        if (other.tag == "engel") 
        {
            Debug.Log("engel hit player");
            other.gameObject.GetComponent<Collider>().enabled = false;
            myCam.GetComponent<Camera>().DOShakeRotation(Shaketime, Shakepower, fadeOut : true); 
        }
        */
    }

}
