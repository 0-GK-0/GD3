using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreBtn : MonoBehaviour
{
    public Image buttonImg;
    public GameObject descriptionPanel;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemAmount;
    public TextMeshProUGUI itemPrice;
    public TextMeshProUGUI shipDescription;
    public Image itemImage;
    public BuyBtn buyButton;
    public KeyCode closeKey = KeyCode.Escape;

    public string namee, amount, price, description;
    private Sprite itemIcon;
    private GameItem itemData;
    [SerializeField] private OpenInterface openInterface;

    private bool isOpen;

    private void Start()
    {
        descriptionPanel = GameObject.FindWithTag("DescriptionPanel").transform.GetChild(0).GetChild(3).gameObject;
        itemName = descriptionPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        itemPrice = descriptionPanel.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        shipDescription = descriptionPanel.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        itemAmount = descriptionPanel.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        itemImage = descriptionPanel.transform.GetChild(1).gameObject.GetComponent<Image>();
        buyButton = descriptionPanel.transform.GetChild(2).gameObject.GetComponent<BuyBtn>();

        openInterface = GameObject.FindWithTag("ShopOwner").gameObject.GetComponent<OpenInterface>();

        Debug.Log(descriptionPanel + ", " + itemName + ", " + itemPrice + ", " + shipDescription);
        Debug.Log("This worked");
        //descriptionPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(closeKey) && isOpen) 
        {
            CloseDescription();
            openInterface.canClose = true;
        }
    }

    public void ChangeButton(GameItem item)
    {
        itemIcon = item.icon;
        buttonImg.sprite = item.icon;
        namee = item.itemName;
        amount = item.amount.ToString();
        price = item.itemPrice.ToString();
        description = item.description;
        itemData = item;
    }
    public void OpenDescription()
    {
        itemName.text = namee;
        itemPrice.text = $"${price}";
        itemAmount.text = amount;
        shipDescription.text = description;
        itemImage.sprite = itemIcon;
        buyButton.SetButton(itemData, gameObject);
        descriptionPanel.SetActive(true);
        openInterface.canClose = false;
        isOpen = true;
    }
    public void CloseDescription()
    {
        descriptionPanel.SetActive(false);
        isOpen = false;
    }
}
