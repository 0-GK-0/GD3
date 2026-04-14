using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject openTxt;
    [SerializeField] private GameObject openChest;
    public KeyCode openKey;
    public int item;
    public List<GameObject> possibleItems;
    //[SerializeField] private Transform itemInstPoint;
    public int minItems;
    public int maxItems;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openTxt.SetActive(true);
            if (Input.GetKeyDown(openKey))
            {
                int nItems = Random.Range(minItems, maxItems + 1);
                for(int i = 0; i < nItems; i++)
                {
                    item = Random.Range(0, possibleItems.Count);
                    //Instantiate(possibleItems[item], itemInstPoint.position, Quaternion.identity);
                    collision.gameObject.GetComponent<PlayerItems>().items.Add(possibleItems[item]);
                }
                
                Instantiate(openChest, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            openTxt.SetActive(false);
        }
    }
}
