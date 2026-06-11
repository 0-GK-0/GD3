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
    public Image shipImage;
    public goButton goButton;
    public KeyCode closeKey = KeyCode.Escape;

    public string namee, level, description;
    private Sprite shipIcon;
    private Ship btnShipData;

    private void Start()
    {
        shipMenu = GameObject.FindWithTag("DescriptionPanel").transform.Find("DescriptionPanel").gameObject;
        shipName = shipMenu.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        shipLevel = shipMenu.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        shipDescription = shipMenu.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        shipImage = shipMenu.transform.GetChild(1).gameObject.GetComponent<Image>();
        goButton = shipMenu.transform.GetChild(2).gameObject.GetComponent<goButton>();

        Debug.Log(shipMenu + ", " + shipName + ", " + shipLevel + ", " + shipDescription);
        Debug.Log("This worked");
        //shipMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(closeKey)) CloseDescription();
    }

    public void ChangeButton(Ship shipToSpawn)
    {
        shipIcon = shipToSpawn.shipIcon;
        buttonImg.sprite = shipIcon;
        namee = shipToSpawn.shipName;
        level = shipToSpawn.shipLevel.ToString();
        description = shipToSpawn.shipDescription;
        btnShipData = shipToSpawn;
    }
    public void OpenDescription()
    {
        shipName.text = namee;
        shipLevel.text = level;
        shipDescription.text = description;
        shipImage.sprite = shipIcon;
        goButton.SetButton(btnShipData);
        shipMenu.SetActive(true);
    }
    public void CloseDescription()
    {
        shipMenu.SetActive(false);
    }
}
