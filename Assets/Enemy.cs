using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3[] puntosDePatrulla;
    public int indiceActual;

    public float speed;
    public float speedRotation;

    public Transform jugador;
    public float rangoVision;

    public float tiempoEsperaInicial;
    private float tiempoEsperaRestante;


    void Start()
    {
        tiempoEsperaRestante = tiempoEsperaInicial;
    }

    void Update()
    {
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);
        if (distanciaAlJugador < rangoVision)//distancia a player < rango de vision 
        {
            //muevo hacia player
            PerseguirJugador();
        }
        else
        {
            //patrullar
            Patrullar();
        }



    }


    public void Patrullar()
    {
        float distanciaAPunto = Vector2.Distance(transform.position, puntosDePatrulla[indiceActual]);
        if (distanciaAPunto <= 1)// a menos de 1 de distancia
        {
            EsperarEnPunto();

            print("Llegue y no se que hacer");
        }
        else
        {
            //movernos
            MoverHacia(puntosDePatrulla[indiceActual]);
        }

    }
    public void PerseguirJugador()
    {
        MoverHacia(jugador.position);
    }

    public void EsperarEnPunto()
    {
        if (tiempoEsperaRestante >= 0)
        {
            tiempoEsperaRestante -= Time.deltaTime;
        }
        else
        {
            tiempoEsperaRestante = tiempoEsperaInicial;
            indiceActual += 1;
            if (indiceActual >= puntosDePatrulla.Length)
            {
                indiceActual = 0;
            }

        }
    }

    public void MoverHacia(Vector3 destino)
    {
        Vector3 direccion = (destino - transform.position).normalized;
        transform.position += direccion * Time.deltaTime * speed;
        //  transform.position += transform.right * Time.deltaTime * speed;
        MirarHacia(direccion);
    }

    public void MirarHacia(Vector3 destino)
    {
        if (destino != Vector3.zero)
        {
            float angle = Mathf.Atan2(destino.y, destino.x) * Mathf.Rad2Deg;//Miro con eje X
            Quaternion rotacionDeseada = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, speedRotation * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Ship componenteShip = collision.gameObject.GetComponent<Ship>();
        if (componenteShip != null)
        {
            componenteShip.PerderMonedas();
            componenteShip.lifes--;
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoVision);

        Gizmos.color = Color.blue;
        if (puntosDePatrulla.Length > 0)
        {
            foreach (var punto in puntosDePatrulla)
            {
                Gizmos.DrawSphere(punto, 0.2f);
            }

        }
    }
}
