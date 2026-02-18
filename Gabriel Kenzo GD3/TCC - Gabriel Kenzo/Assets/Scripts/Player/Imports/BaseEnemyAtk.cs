using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyAtk : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Dmg(damage);
        }
    }
    private void Update()
    {
        Destroy(gameObject);
    }
}
