using UnityEngine;

public class HpPickup : MonoBehaviour
{
    public int hpAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var pHp = collision.gameObject.GetComponent<PlayerHealth>();
            pHp.Heal(hpAdd);

            Destroy(gameObject);
        }
    }
}
