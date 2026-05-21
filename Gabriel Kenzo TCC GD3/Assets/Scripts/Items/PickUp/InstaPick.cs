using UnityEngine;

public class InstaPick : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var pMoney = collision.gameObject.GetComponent<PlayerItems>();
            pMoney.money += value;

            Destroy(gameObject);
        }
    }
}
