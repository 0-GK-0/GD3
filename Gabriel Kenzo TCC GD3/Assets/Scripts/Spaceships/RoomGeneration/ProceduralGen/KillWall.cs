using UnityEngine;

public class KillWall : MonoBehaviour
{
    [SerializeField] private string tagToDie;
    [SerializeField] private string tagToDie2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagToDie) || collision.gameObject.CompareTag(tagToDie2))
        {
            Destroy(gameObject);
        }
        else
        {
            //enabled = false;
        }
    }
    void Update()
    {
        //Debug.Log("A");
    }
}
