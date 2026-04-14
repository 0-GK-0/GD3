using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TerminalButton : MonoBehaviour
{
    public Image buttonImg;
    public GameObject shipMenu;
    public TextMeshProUGUI shipName;
    public TextMeshProUGUI shipLevel;
    public TextMeshProUGUI shipDescription;
    public KeyCode closeKey = KeyCode.Escape;

    private void Update()
    {
        if(Input.GetKeyDown(closeKey)) CloseDescription();
    }

    public void ChangeButton(Ship shipToSpawn)
    {
        buttonImg.sprite = shipToSpawn.shipIcon;
        shipName.text = shipToSpawn.shipName;
        shipLevel.text = shipToSpawn.shipLevel.ToString();
        shipDescription.text = shipToSpawn.shipDescription;
    }
    public void OpenDescription()
    {
        shipMenu.SetActive(true);
    }
    public void CloseDescription()
    {
        shipMenu.SetActive(false);
    }
}
