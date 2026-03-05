using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float speed;
    
    [Header("Attack")]
    [SerializeField] private GameObject atk;
    [SerializeField] private float atkCdwn;
    [SerializeField] private float currentAtkCdwn;

    [Header("Movement")]
    public float pursuitRange;
    public float startRunRange;
    public float maxRunRange;
    private float distance;
    Vector2 direction;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerHealth pHealth;
    [SerializeField] private Transform projInstPoint;
    private GameObject player;
    [SerializeField] private EnemyHealth eHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private string atkAnim;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if(currentAtkCdwn > 0)
        {
            currentAtkCdwn -= Time.deltaTime;
            ResetAtk();
        }
        else
        {
            currentAtkCdwn = atkCdwn;
            Instantiate(atk, projInstPoint.position, projInstPoint.rotation);
        }

        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance <= pursuitRange) rb.linearVelocity = direction * speed;
        else if (distance >= startRunRange && distance <= maxRunRange) rb.linearVelocity = direction * (-speed);
        else rb.linearVelocity = Vector2.zero;
    }

    public void ResetAtk()
    {
        if (eHealth.reset)
        {
            currentAtkCdwn = atkCdwn;
            anim.Play(atkAnim);
        }
    }
}
