using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;


    void Start()
    {

    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(0, 0, 0);
        
        if (horizontal != 0)
        {
             direccion = new Vector3(horizontal, 0, 0).normalized;

        }
        else if (vertical != 0)
        {
             direccion = new Vector3(0, vertical, 0).normalized;
        }

        transform.position +=  direccion * (speed * Time.deltaTime);
        /*
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position -= Vector3.right * (speed * Time.deltaTime);
            transform.position -= transform.right * (speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position -= Vector3.right * (speed * Time.deltaTime);
            transform.position += transform.up * (speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position -= Vector3.right * (speed * Time.deltaTime);
            transform.position -= transform.up * (speed * Time.deltaTime);
        }*/
    }
}
