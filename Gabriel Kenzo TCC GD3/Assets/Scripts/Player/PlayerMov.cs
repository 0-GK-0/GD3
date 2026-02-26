using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMov : MonoBehaviour
{

    [Header("Values")]
    public float movSpeed;
    public float maxSpeed;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    Vector2 direction;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    /*[Header("Breadcrumbs")]
    public float timeBetweenCrumbs;
    public float maxTimeBetweenCrumbs;
    public GameObject crumb;*/

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        rb.linearVelocity = direction * movSpeed;

        GetAnimation();
        SpriteFlip();

        /*timeBetweenCrumbs -= Time.deltaTime;
        if (timeBetweenCrumbs <= 0) Instantiate(crumb, transform.position, transform.rotation);*/
    }
    void SpriteFlip()
    {
        if (!spriteRenderer.flipX && direction.x < 0) spriteRenderer.flipX = true;
        else if (spriteRenderer.flipX && direction.x > 0) spriteRenderer.flipX = false;
    }

    void GetAnimation()
    {
        if (rb.linearVelocity.magnitude != 0)
        {
            anim.SetBool("idle", false);
            if (direction.y > 0)
            {
                if (direction.x == 0) anim.Play("PlayerWalkB");
                else anim.Play("PlayerWalkBS");
            }
            else if (direction.y < 0)
            {
                if (direction.x == 0) anim.Play("PlayerWalkF");
                else anim.Play("PlayerWalkFS");
            }
            else anim.Play("PlayerWalkS");
        }
        else anim.SetBool("idle", true);
    }
}
