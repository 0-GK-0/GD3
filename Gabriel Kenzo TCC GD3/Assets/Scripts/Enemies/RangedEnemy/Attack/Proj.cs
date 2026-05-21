using UnityEngine;

public class Proj : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDespawn;
    [SerializeField] private int dmg;
    [SerializeField] private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        timeToDespawn -= Time.deltaTime;
        if(timeToDespawn <= 0) Destroy(gameObject);

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.Dmg(dmg);
            Destroy(gameObject);
        }
    }
}
