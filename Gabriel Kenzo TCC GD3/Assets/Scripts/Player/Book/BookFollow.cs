using UnityEngine;

public class BookFollow : MonoBehaviour
{
    public float speed;

    private float distance;

    [SerializeField] private Rigidbody2D rb;
    Vector2 direction;
    public GameObject player;

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance > 0.1) rb.linearVelocity = direction * speed;
        else rb.linearVelocity = Vector2.zero;
    }
}
