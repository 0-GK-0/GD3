using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject openTxt;
    [SerializeField] private GameObject openChest;
    public KeyCode openKey;
    public int item;
    public List<GameObject> possibleItems;
    [SerializeField] private Transform itemInstPoint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openTxt.SetActive(true);
            if (Input.GetKeyDown(openKey))
            {
                item = Random.Range(0, possibleItems.Count);
                Instantiate(possibleItems[item], itemInstPoint.position, Quaternion.identity);

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
