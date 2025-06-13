using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Ship componenteShip = collision.gameObject.GetComponent<Ship>();
        if (componenteShip != null)
        {
            if (componenteShip.lifes < 3)
            {
                componenteShip.lifes++;
                Destroy(gameObject);
            }
        }

    }
}
