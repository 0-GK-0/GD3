using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryInterface;
    public KeyCode inventoryKey = KeyCode.O;
    public KeyCode closeKey = KeyCode.Escape;
    public bool opened = false;

    private void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            if(!opened)
            {
                inventoryInterface.SetActive(true);
                opened = true;
            }
            else
            {
                inventoryInterface.SetActive(false);
                opened = false;
            }
        }
        else if (Input.GetKeyDown(closeKey) && opened){
            inventoryInterface.SetActive(false);
            opened = false;
        }
    }

}
