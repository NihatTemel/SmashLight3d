using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallScript : MonoBehaviour
{
    Rigidbody rb;
    public int StartForce;
    public Vector3 direction;
    GameObject Player;
    [SerializeField] GameObject FracturedBall;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
        rb.AddForce(direction.normalized * StartForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obs") 
        {
            Debug.Log("hit "+ collision.gameObject.GetComponent<AddBallValue>().Value);
            
            GameObject Fractured = Instantiate(FracturedBall, transform.position, Quaternion.identity);
            Fractured.transform.localScale = transform.localScale;
            rb.AddExplosionForce(3, transform.position, 2, 3.0F);
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            PlayerPrefs.SetInt("ball", PlayerPrefs.GetInt("ball") + collision.gameObject.GetComponent<AddBallValue>().Value);

            this.gameObject.SetActive(false);
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject, 2.2f);




        }
        if (collision.collider.tag == "engel")
        {


            collision.gameObject.tag = "Untagged";
            //Player.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<MeshRenderer>().material;

            GameObject Fractured = Instantiate(FracturedBall, transform.position, Quaternion.identity);
            Fractured.transform.localScale = transform.localScale;
            rb.AddExplosionForce(3, transform.position, 2, 3.0F);
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(collision.gameObject, 2.2f);
            //PlayerPrefs.SetInt("ball", PlayerPrefs.GetInt("ball") + collision.gameObject.GetComponent<AddBallValue>().Value);
            this.gameObject.SetActive(false);
        }
    }


}
