using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public int coins;
    public int lifes;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = -1 * Input.GetAxis("Horizontal");

        transform.position += transform.up * (speed * Time.deltaTime * vertical);
        transform.Rotate(0, 0, horizontal * speedRotation * Time.deltaTime);

    }

    public void RecolectarMoneda()
    {
        coins++;
    }

    public void PerderMonedas()
    {
        coins = 0;
    }
}
