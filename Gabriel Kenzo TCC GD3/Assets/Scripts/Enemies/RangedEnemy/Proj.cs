using UnityEngine;

public class Proj : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDespawn;
    [SerializeField] private int dmg;

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
            var playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Dmg(dmg);
        }
        Destroy(gameObject);
    }
}
