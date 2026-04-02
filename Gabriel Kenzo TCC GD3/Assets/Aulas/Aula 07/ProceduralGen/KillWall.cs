using UnityEngine;

public class KillWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DoorWall"))
        {
            Destroy(gameObject);
        }
        else
        {
            enabled = false;
        }
    }
    void Update()
    {
        Debug.Log("A");
    }
}
