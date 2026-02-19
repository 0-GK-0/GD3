using UnityEngine;
using System;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
    [Header("Enemy Status")]
    public float speed;
    public int damage;
    public float atkCooldown;
    public float currentAtkCooldown;
    public GameObject atk;
    public bool pursuing = false;

    [Header("Enemy Pursuit Values")]
    public float pursuitRange;
    public float atkRange;

    [Header("Other Values")]
    private float distance;

    [SerializeField] private Rigidbody2D rb;
    Vector2 direction;

    [Header("Player Reference")]
    public GameObject player;

    public PlayerHealth playerHealth;
    private GameObject[] crumb;

    void Update()
    {
        //crumb = GameObject.FindGameObjectsWithTag("Crumbs");
        /*if (distance <= pursuitRange)
        {
            pursuing = true;
            distance = Vector2.Distance(transform.position, player.transform.position);
            direction = player.transform.position - transform.position;
            direction.Normalize();
            //if (distance > atkRange && pursuing) rb.linearVelocity = direction * speed;
            rb.linearVelocity = direction * speed;
        }
        /*else if (distance <= atkRange)
        {
            rb.linearVelocity = Vector2.zero;
            if (currentAtkCooldown <= 0) Attack();
        }*/
        //else rb.linearVelocity = Vector2.zero;

        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < pursuitRange && distance > atkRange) rb.linearVelocity = direction * speed;
        else if (distance < atkRange) rb.linearVelocity = Vector2.zero;

        if (currentAtkCooldown > 0) currentAtkCooldown -= Time.deltaTime;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && currentAtkCooldown <= 0)
        {
            //Attack();
            playerHealth.Dmg(damage);
            currentAtkCooldown = atkCooldown;
        }
    }
    void Attack()
    {
        Instantiate(atk, transform.position, transform.rotation);
        currentAtkCooldown = atkCooldown;
    }
}
