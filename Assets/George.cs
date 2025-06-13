using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class George : MonoBehaviour
{
    public float speed;
    public Animator myAnimator;
    public Vector2 movement;
    public float life;
    public int lifeHeart;
    bool isAttacking;
    public AudioManager audioManager;
    public UiManager uiManager;


    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        uiManager = FindObjectOfType<UiManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager.inPause == true)
        {
            myAnimator.enabled = false;
            return;
        }


        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;

        myAnimator.SetBool("Walk", movement != Vector2.zero);//x=0,y=0

        if (movement != Vector2.zero)
        {
            myAnimator.SetFloat("Horizontal", movement.x);
            myAnimator.SetFloat("Vertical", movement.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
            myAnimator.SetBool("IsAttacking", true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            life -= 10;
            if (life < 0)
            {
                life = 0;
            }

            lifeHeart--;
            if (lifeHeart < 0)
            {

                lifeHeart = 0;
            }
            uiManager.UpdateHearts(lifeHeart);
            float fillLife = life / 100; //suponiendo que la vida maxima es 100
            uiManager.UpdateLife(life);
            uiManager.UpdateBar(fillLife);
            uiManager.UpdateTargetBar(fillLife);
        }

    }

    public void StopAttack()
    {
        if (isAttacking == true)
        {

            isAttacking = false;
            myAnimator.SetBool("IsAttacking", false);
        }
    }
    public void PlaySoundSword()
    {
        if (audioManager != null)
        {
            audioManager.PlaySound("Hit2");
        }
    }
}
