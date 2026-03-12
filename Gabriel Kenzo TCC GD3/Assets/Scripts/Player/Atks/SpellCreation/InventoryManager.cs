using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<SpellItem> Items = new List<SpellItem>();
    public Image[] btnImg;
    public int manaSum;
    public float cdwnSum;

    public TextMeshProUGUI manaText, cooldownText;

    public Sprite blankSprite;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Add(SpellItem item)
    {
        if (Items.Count < 8) Items.Add(item);
    }

    public void Remove(int itemNumber)
    {
        Items.Remove(Items[itemNumber]);
    }

    public void UpdateInventory()
    {
        manaSum = 5;
        cdwnSum = .5f;
        for(int i = 0; i < btnImg.Length; i++)
        {
            if(i < Items.Count)
            {
                btnImg[i].sprite = Items[i].icon;
                manaSum += Items[i].addedMana;
                cdwnSum += Items[i].addedCooldown;
            }
            else btnImg[i].sprite = blankSprite;
        }
        manaText.text = manaSum.ToString() + " / 100";
        cooldownText.text = cdwnSum.ToString() + "s";
    }
}