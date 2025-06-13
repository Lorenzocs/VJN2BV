using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Shooter : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed;
    public Transform sprite;
    public Transform firePoint;
    public int life;
    public GameObject bullet;
    public float fireRate;//1
    private float countDown;//0

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) return;


        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float distanceToMouse = Vector2.Distance(mousePos, transform.position);
        if (distanceToMouse > 1)
        {
            Vector2 lookDir = (mousePos - transform.position).normalized;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;// la x mira al punto
            sprite.rotation = Quaternion.Euler(0, 0, angle);
        }


        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);
        transform.position += movement * moveSpeed * Time.deltaTime;



        if (Input.GetMouseButton(0))
        {
            if (countDown >= fireRate)
            {
                countDown = 0;
                GameObject myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                Destroy(myBullet, 3f);
            }
            else
            {
                countDown += Time.deltaTime;
            }
        }

    }

    public void TakeDamage()
    {
        life--;

        if (life <= 0)
        {
            print("Se murio");
        }
    }

}
