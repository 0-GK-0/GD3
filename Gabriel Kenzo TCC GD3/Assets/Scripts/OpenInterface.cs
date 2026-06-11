using UnityEngine;

public class OpenInterface : MonoBehaviour
{
    [SerializeField] private GameObject iText;
    public KeyCode openKey;
    public GameObject iInterface;
    private bool isInside;

    private void Update()
    {
        if (Input.GetKeyDown(openKey) && isInside)
        {
            iInterface.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInside = true;
            iText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            isInside = false;
            iText.SetActive(false);
        }
    }

    public void CloseInterface()
    {
        iInterface.SetActive(false);
    }
}
