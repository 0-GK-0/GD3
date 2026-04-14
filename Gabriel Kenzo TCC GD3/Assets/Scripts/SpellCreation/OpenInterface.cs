using UnityEngine;

public class OpenInterface : MonoBehaviour
{
    [SerializeField] private GameObject cText;
    public KeyCode openKey;
    public GameObject cInterface;
    private bool isInside;

    private void Update()
    {
        if (Input.GetKeyDown(openKey) && isInside)
        {
            cInterface.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInside = true;
            cText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            isInside = false;
            cText.SetActive(false);
        }
    }
}
