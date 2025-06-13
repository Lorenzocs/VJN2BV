using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy2 : MonoBehaviour
{

    public float speed;
    public float speedRotation;
    public int life = 3;
    public Transform jugador;
    public SpawnEnemy mySpawn;

    public float visionRange;
    public GameObject bullet;
    public float fireRate;//1
    private float countDown;//0

    void Start()
    {
        jugador = FindObjectOfType<Shooter>().transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, jugador.position);
        if (distanceToPlayer <= visionRange)
        {
            if (countDown >= fireRate)
            {

                Vector3 direccion = (jugador.position - transform.position).normalized;
                MirarHacia(direccion);
                GameObject bala = Instantiate(bullet, transform.position, transform.rotation);
                countDown = 0;
            }
            else
            {
                countDown += Time.deltaTime;
            }
        }
        else
        {

            PerseguirJugador();
        }
    }


    public void PerseguirJugador()
    {
        MoverHacia(jugador.position);
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
        Shooter player = collision.GetComponent<Shooter>();
        if (player != null)
        {
            player.TakeDamage();
            Destroy(gameObject);
        }

        BulletPlayer bulletPlayer = collision.GetComponent<BulletPlayer>();
        if (bulletPlayer != null)
        {
            life--;
            Destroy(bulletPlayer.gameObject);
            if (life <= 0)
            {
                FindObjectOfType<GameManager>().EnemyKill();
                Destroy(gameObject);

            }
        }

        if (collision.gameObject.tag == "Hit")
        {
            FindObjectOfType<GameManager>().EnemyKill();
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        mySpawn.enemyCount--;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);


    }

}
