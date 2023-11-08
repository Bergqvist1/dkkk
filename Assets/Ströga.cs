using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Ströga : MonoBehaviour
{
    public float speed = 1f;

    public Rigidbody rb;

    public bool SpelarePåMark = true;
    private Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,0, speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(0,0, -speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.position += new Vector3(-speed * Time.deltaTime,0,0);
        }

        if(Input.GetButtonDown("Jump") && SpelarePåMark)
        {
            rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
            SpelarePåMark = false;
        }

       
        

    }
      void OnCollisionEnter(Collision collision) 
        {
            if(collision.gameObject.tag == "Mark")
            {
                SpelarePåMark = true;
            }
        }
}