using UnityEngine;
using System.Collections;

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
        StartCoroutine(DestroyCoroutine());
    }
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
