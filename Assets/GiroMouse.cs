using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroMouse : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float movement;

    private void Update()
    {
        movement = Input.GetAxis("Vertical");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle-90);//Miro con eje Y+
       
        Vector2 moveDir = transform.up * movement;
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
}
