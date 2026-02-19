using UnityEngine;

public class ActualSpell : MonoBehaviour
{
    [Header("Spell Values")]
    public int pierce;
    public float speed;
    public int damage;
    public float knockBack;
    public int poisonDmg;
    public int slowFactor;


    [Header("Ailments Applied")]
    public bool appliesSpeed;
    public bool appliesSlowness;
    public bool appliesPoison;
    public bool explodes;

    [Header("References")]
    public Rigidbody2D rb;
    public EnemyHealth enemy;
    public BasicEnemy basicEnemy;
    public GameObject explosion;
    public Explosion explosionScr;

    private void Start()
    {
        explosionScr = explosion.GetComponent<Explosion>();
        explosionScr.damage = damage;
        explosionScr.knockBack = knockBack;
        explosionScr.appliesSpeed = appliesSpeed;
        explosionScr.appliesPoison = appliesPoison;
        explosionScr.appliesSlowness = appliesSlowness;
        explosionScr.poisonDmg = poisonDmg;
        explosionScr.slowFactor = slowFactor;
    }

    private void Update()
    {
        //rb.linearVelocity = speed * Vector2.up;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (pierce <= 0) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<EnemyHealth>();
            basicEnemy = collision.gameObject.GetComponent<BasicEnemy>();
            enemy.Dmg(damage);
            pierce--;
            if (explodes)
            {
                Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
            }
            if (appliesSlowness)
            {
                basicEnemy.speed -= slowFactor;
            }
            if (appliesSpeed)
            {
                basicEnemy.speed += 2;
            }
            if (appliesPoison)
            {
                enemy.Poison(poisonDmg);
            }
        }
    }
}
