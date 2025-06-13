using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speedRotation;
    public Transform coinTransform;
    public Ship componenteShip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinTransform.Rotate(0, speedRotation * Time.deltaTime, 0);
    }


    // que ambos objetos tengan collider , que almenos uno tenga istrigger
    // que almenos uno tenga RB
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);
        }
        */
        /*
        if (collision.gameObject.CompareTag("Player"))
        {
            Ship componenteShip = collision.gameObject.GetComponent<Ship>();
            if (componenteShip != null)
            {
                componenteShip.coins += 1;
                Destroy(gameObject);
            }
        }*/


        componenteShip = collision.gameObject.GetComponent<Ship>();
        if (componenteShip != null)
        {
            componenteShip.RecolectarMoneda();
            Destroy(gameObject);
        }

    }

}
