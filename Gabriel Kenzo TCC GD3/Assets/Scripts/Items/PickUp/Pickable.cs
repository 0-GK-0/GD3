using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private GameObject pickText;
    public KeyCode pickKey = KeyCode.E;
    public GameObject item;
    private bool isInside;

    private void Update()
    {
        if (Input.GetKeyDown(pickKey) && isInside)
        {
            var pItems = GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerItems>();
            pItems.items.Add(item);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInside = true;
            pickText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            isInside = false;
            pickText.SetActive(false);
        }
    }
}