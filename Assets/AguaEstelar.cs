using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaEstelar : MonoBehaviour
{
    public float shipSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Ship componenteShip = collision.gameObject.GetComponent<Ship>();
        if (componenteShip != null)
        {
            shipSpeed = componenteShip.speed;
            componenteShip.speed = 1;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Ship componenteShip = collision.gameObject.GetComponent<Ship>();
        if (componenteShip != null)
        {
            componenteShip.speed = shipSpeed;
        }
    }
}
