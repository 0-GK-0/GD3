using UnityEngine;
using System;
using System.Collections;

public class DashingEnemy : MonoBehaviour
{
    public float speed;
    private float distance;
    public int damage;
    public float dashingSpeed;
    public float timeStoppedTillDash;
    public float timeTillDash;
    public float maxTimeTillDash;
    public float dashDistance;
    bool dashing;

    [SerializeField] private Rigidbody2D rb;
    Vector2 direction;
    public GameObject player;

    public float atkCooldown;
    public float currentAtkCooldown;
    public PlayerHealth playerHealth;

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (!dashing) direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance > dashDistance) rb.linearVelocity = direction * speed;
        else
        {
            if (timeTillDash <= 0)
            {
                rb.linearVelocity = Vector2.zero;
                StartCoroutine(Dash());
            }
            else rb.linearVelocity = direction * speed;
        }

        if (currentAtkCooldown > 0) currentAtkCooldown -= Time.deltaTime;
        if (timeTillDash > 0) timeTillDash -= Time.deltaTime;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && currentAtkCooldown <= 0)
        {
            playerHealth.Dmg(damage);
            currentAtkCooldown = atkCooldown;
        }
    }

    IEnumerator Dash()
    {
        dashing = true;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(timeStoppedTillDash);
        rb.AddForce(dashingSpeed * direction, ForceMode2D.Impulse);
        timeTillDash = maxTimeTillDash;
        dashing = false;
    }
}
