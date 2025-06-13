using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloAsesino : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.up * Time.deltaTime * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("colisiono");
        Ship componenteShip = collision.gameObject.GetComponent<Ship>();
        if (componenteShip != null)
        {
        }
        componenteShip.PerderMonedas();
        componenteShip.lifes--;
        Destroy(gameObject, 10);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("Deje de colisionar");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        print("colisionando");

    }
}
