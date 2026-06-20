using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage;
    public float knockBack;
    public int poisonDmg;
    public int slowFactor;

    [Header("Ailments Applied")]
    public bool appliesSpeed;
    public bool appliesSlowness;
    public bool appliesPoison;
    public bool explodes;

    public EnemyHealth enemy;
    public BasicEnemy basicEnemy;

    public float timeToDecay = 0.02f;
    private bool doesDamage = true;
    public float timeToDamage = 0.02f;

    void Update()
    {
        timeToDecay -= Time.deltaTime;
        if(timeToDamage > 0) timeToDamage -= Time.deltaTime;
        else doesDamage = false;
        if (timeToDecay <= 0) Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && doesDamage)
        {
            enemy = collision.gameObject.GetComponent<EnemyHealth>();
            basicEnemy = collision.gameObject.GetComponent<BasicEnemy>();
            enemy.Dmg(damage);
            if (appliesSlowness)
            {
                basicEnemy.speed -= slowFactor;
            }
            if (appliesPoison)
            {
                enemy.Poison(poisonDmg);
            }
        }
    }
}