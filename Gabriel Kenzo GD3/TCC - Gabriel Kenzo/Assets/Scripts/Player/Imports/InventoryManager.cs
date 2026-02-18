using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.IO.LowLevel.Unsafe;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<SpellItem> Items = new List<SpellItem>();

    public Button zerothSpace;
    public Button firstSpace;
    public Button secondSpace;
    public Button thirdSpace;
    public Button fourthSpace;
    public Button fifthSpace;
    public Button sixthSpace;
    public Button seventhSpace;

    public Image zerothImage;
    public Image firstImage;
    public Image secondImage;
    public Image thirdImage;
    public Image fourthImage;
    public Image fifthImage;
    public Image sixthImage;
    public Image seventhImage;

    public TextMeshProUGUI manaText;
    public TextMeshProUGUI cooldownText;

    /*public Sprite zerothSprite;
    public Sprite firstSprite;
    public Sprite secondSprite;
    public Sprite thirdSprite;
    public Sprite fourthSprite;
    public Sprite fifthSprite;
    public Sprite sixthSprite;
    public Sprite seventhSprite;*/

    public Sprite blankSprite;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(SpellItem item)
    {
        if (Items.Count < 8) Items.Add(item);
    }

    public void Remove(int itemNumber)
    {
        Items.Remove(Items[itemNumber]);
    }

    private void Start()
    {
        zerothImage = zerothSpace.GetComponent<Image>();
        firstImage = firstSpace.GetComponent<Image>();
        secondImage = secondSpace.GetComponent<Image>();
        thirdImage = thirdSpace.GetComponent<Image>();
        fourthImage = fourthSpace.GetComponent<Image>();
        fifthImage = fifthSpace.GetComponent<Image>();
        sixthImage = sixthSpace.GetComponent<Image>();
        seventhImage = seventhSpace.GetComponent<Image>();
    }
    private void Update()
    {
        if (Items.Count == 0)
        {
            zerothImage.sprite = blankSprite;
            firstImage.sprite = blankSprite;
            secondImage.sprite = blankSprite;
            thirdImage.sprite = blankSprite;
            fourthImage.sprite = blankSprite;
            fifthImage.sprite = blankSprite;
            sixthImage.sprite = blankSprite;
            seventhImage.sprite = blankSprite;
            manaText.text = "5 / 100";
            cooldownText.text = "0.5s";
        }
        if (Items.Count == 1)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = blankSprite;
            secondImage.sprite = blankSprite;
            thirdImage.sprite = blankSprite;
            fourthImage.sprite = blankSprite;
            fifthImage.sprite = blankSprite;
            sixthImage.sprite = blankSprite;
            seventhImage.sprite = blankSprite;
            int manaSum = Items[0].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
        if (Items.Count == 2)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = Items[1].icon;
            secondImage.sprite = blankSprite;
            thirdImage.sprite = blankSprite;
            fourthImage.sprite = blankSprite;
            fifthImage.sprite = blankSprite;
            sixthImage.sprite = blankSprite;
            seventhImage.sprite = blankSprite;
            int manaSum = Items[0].addedMana + Items[1].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + Items[1].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
        if (Items.Count == 3)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = Items[1].icon;
            secondImage.sprite = Items[2].icon;
            thirdImage.sprite = blankSprite;
            fourthImage.sprite = blankSprite;
            fifthImage.sprite = blankSprite;
            sixthImage.sprite = blankSprite;
            seventhImage.sprite = blankSprite;
            int manaSum = Items[0].addedMana + Items[1].addedMana + Items[2].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + Items[1].addedCooldown + Items[2].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
        if (Items.Count == 4)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = Items[1].icon;
            secondImage.sprite = Items[2].icon;
            thirdImage.sprite = Items[3].icon;
            fourthImage.sprite = blankSprite;
            fifthImage.sprite = blankSprite;
            sixthImage.sprite = blankSprite;
            seventhImage.sprite = blankSprite;
            int manaSum = Items[0].addedMana + Items[1].addedMana + Items[2].addedMana + Items[3].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + Items[1].addedCooldown + Items[2].addedCooldown + Items[3].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
        if (Items.Count == 5)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = Items[1].icon;
            secondImage.sprite = Items[2].icon;
            thirdImage.sprite = Items[3].icon;
            fourthImage.sprite = Items[4].icon;
            fifthImage.sprite = blankSprite;
            sixthImage.sprite = blankSprite;
            seventhImage.sprite = blankSprite;
            int manaSum = Items[0].addedMana + Items[1].addedMana + Items[2].addedMana + Items[3].addedMana + Items[4].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + Items[1].addedCooldown + Items[2].addedCooldown + Items[3].addedCooldown + Items[4].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
        if (Items.Count == 6)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = Items[1].icon;
            secondImage.sprite = Items[2].icon;
            thirdImage.sprite = Items[3].icon;
            fourthImage.sprite = Items[4].icon;
            fifthImage.sprite = Items[5].icon;
            sixthImage.sprite = blankSprite;
            seventhImage.sprite = blankSprite;
            int manaSum = Items[0].addedMana + Items[1].addedMana + Items[2].addedMana + Items[3].addedMana + Items[4].addedMana + Items[5].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + Items[1].addedCooldown + Items[2].addedCooldown + Items[3].addedCooldown + Items[4].addedCooldown + Items[5].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
        if (Items.Count == 7)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = Items[1].icon;
            secondImage.sprite = Items[2].icon;
            thirdImage.sprite = Items[3].icon;
            fourthImage.sprite = Items[4].icon;
            fifthImage.sprite = Items[5].icon;
            sixthImage.sprite = Items[6].icon;
            seventhImage.sprite = blankSprite;
            int manaSum = Items[0].addedMana + Items[1].addedMana + Items[2].addedMana + Items[3].addedMana + Items[4].addedMana + Items[5].addedMana + Items[6].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + Items[1].addedCooldown + Items[2].addedCooldown + Items[3].addedCooldown + Items[4].addedCooldown + Items[5].addedCooldown + Items[6].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
        if (Items.Count == 8)
        {
            zerothImage.sprite = Items[0].icon;
            firstImage.sprite = Items[1].icon;
            secondImage.sprite = Items[2].icon;
            thirdImage.sprite = Items[3].icon;
            fourthImage.sprite = Items[4].icon;
            fifthImage.sprite = Items[5].icon;
            sixthImage.sprite = Items[6].icon;
            seventhImage.sprite = Items[7].icon; int manaSum = Items[0].addedMana + Items[1].addedMana + Items[2].addedMana + Items[3].addedMana + Items[4].addedMana + Items[5].addedMana + Items[6].addedMana + Items[7].addedMana + 5;
            manaText.text = manaSum.ToString() + " / 100";
            float cooldownSum = Items[0].addedCooldown + Items[1].addedCooldown + Items[2].addedCooldown + Items[3].addedCooldown + Items[4].addedCooldown + Items[5].addedCooldown + Items[6].addedCooldown + Items[7].addedCooldown + 0.5f;
            cooldownText.text = cooldownSum.ToString() + "s";
        }
    }
}
