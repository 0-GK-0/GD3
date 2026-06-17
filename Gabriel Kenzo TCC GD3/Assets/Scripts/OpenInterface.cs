using UnityEngine;

public class OpenInterface : MonoBehaviour
{
    [SerializeField] private GameObject iText;
    public KeyCode openKey = KeyCode.E;
    public KeyCode closeKey = KeyCode.Escape;
    public GameObject iInterface;
    private bool isInside;
    [SerializeField] private PlayerMov playerMov;
    public bool canClose;
    public bool isOpen;

    private void Start()
    {
        playerMov = GameObject.FindWithTag("Player").GetComponent<PlayerMov>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(openKey) && isInside)
        {
            iInterface.SetActive(true);
            playerMov.canMove = false;
            canClose = true;
            isOpen = true;
        }
        if (Input.GetKeyDown(closeKey) && canClose && isOpen)
        {
            CloseInterface();
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
        playerMov.canMove = true;
        isOpen = false;
    }
}
