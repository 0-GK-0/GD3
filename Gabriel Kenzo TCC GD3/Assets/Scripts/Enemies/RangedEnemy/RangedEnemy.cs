using System.Collections;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float speed;
    
    [Header("Attack")]
    [SerializeField] private GameObject atk;
    [SerializeField] private float atkCdwn;
    [SerializeField] private float currentAtkCdwn;
    private bool attacking;
    private bool canAtk;

    [Header("Movement")]
    public float pursuitRange, runRange;
    private float distance;
    Vector2 direction;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerHealth pHealth;
    [SerializeField] private Transform projInstPoint;
    private GameObject player;
    [SerializeField] private EnemyHealth eHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private string atkAnim, idleAnim;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if(eHealth.hp <= 0) return;

        //Attack
        if(currentAtkCdwn > 0) currentAtkCdwn -= Time.deltaTime;
        else if (!attacking && canAtk) StartCoroutine(AtkCoroutine());
        ResetAtk();

        //Movement
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();

        if(distance <= pursuitRange)
        {
            canAtk = true;
            if (distance <= pursuitRange && distance >= runRange + 2f) rb.linearVelocity = direction * speed;
            else if (distance <= runRange) rb.linearVelocity = direction * (-speed);
            else
            {
                rb.linearVelocity = Vector2.zero;
                if(!attacking) anim.Play(idleAnim);
            }
        }
        else
        {
            canAtk = false;
            rb.linearVelocity = Vector2.zero;
            if(!attacking) anim.Play(idleAnim);
        }
    }

    public void ResetAtk()
    {
        if (eHealth.reset)
        {
            StopAllCoroutines();
            attacking = false;
            currentAtkCdwn = atkCdwn;
        }
    }

    public IEnumerator AtkCoroutine()
    {
        attacking = true;
        anim.Play(atkAnim);
        yield return new WaitForSeconds(1.1f);
        Instantiate(atk, projInstPoint.position, projInstPoint.rotation);
        attacking = false;
        currentAtkCdwn = atkCdwn;
    }
}