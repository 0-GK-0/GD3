using UnityEngine;

public class TreasurePickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickText;
    [SerializeField] private GameObject emptyObj;
    public KeyCode pickKey = KeyCode.E;
    public GameObject item;
    private bool isInside;

    private void Update()
    {
        if (Input.GetKeyDown(pickKey) && isInside)
        {
            var pItems = GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerItems>();
            pItems.money += 100;

            emptyObj.SetActive(true);
            gameObject.SetActive(false);
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
