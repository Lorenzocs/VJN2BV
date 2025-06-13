using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool porArriba;
    public GameObject puertaGameobject;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)//Player
        {
            if (porArriba == true)
            {
                if (transform.position.y < collision.transform.position.y)
                {
                    puertaGameobject.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                if (transform.position.y > collision.transform.position.y)
                {
                    puertaGameobject.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
