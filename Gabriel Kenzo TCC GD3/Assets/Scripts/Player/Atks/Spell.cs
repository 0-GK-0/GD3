using UnityEngine;

public class Spell : MonoBehaviour
{
    public enum spellType
    {
        ranged,
        melee,
        rune,
        cone,
        self,
        orbit,
        laser
    }
    [Header("Spell Type")]
    public spellType sp;

    [Header("Spell Values")]
    public GameObject spell;
    public ActualSpell actualSpell;
    public PlayerMana playerMana;
    public int manaCost = 5, pierce = 1, dmg = 3, poisonDmg = 0, slowFactor = 0, ammount;
    public float speed = 7, knockback, atkCdwn, currentAtkCdwn;

    [Header("Ailments Applied")]
    public bool appliesSpeed = false, appliesSlowness = false, appliesPoison = false, explodes = false;

    [Header("Keys")]
    public KeyCode atkKey;

    [Header("References")]
    public GameObject aim;
    public SpellItem spellItem;
    SpellItem itemOne, itemTwo, itemThree, itemFour, itemFive, itemSix, itemSeven, itemEight;

    private void Start()
    {
        if (InventoryManager.Instance.Items.Count >= 1) itemOne = InventoryManager.Instance.Items[0];
        else
        {
            InventoryManager.Instance.Items.Add(spellItem);
            itemOne = InventoryManager.Instance.Items[0];
        }
        if (InventoryManager.Instance.Items.Count >= 2) itemTwo = InventoryManager.Instance.Items[1];
        else
        {
            InventoryManager.Instance.Items.Add(spellItem);
            itemTwo = InventoryManager.Instance.Items[1];
        }
        if (InventoryManager.Instance.Items.Count >= 3) itemThree = InventoryManager.Instance.Items[2];
        else
        {
            InventoryManager.Instance.Items.Add(spellItem);
            itemThree = InventoryManager.Instance.Items[2];
        }
        if (InventoryManager.Instance.Items.Count >= 4) itemFour = InventoryManager.Instance.Items[3];
        else
        {
            InventoryManager.Instance.Items.Add(spellItem);
            itemFour = InventoryManager.Instance.Items[3];
        }
        if (InventoryManager.Instance.Items.Count >= 5) itemFive = InventoryManager.Instance.Items[4];
        else
        {
            InventoryManager.Instance.Items.Add(spellItem);
            itemFive = InventoryManager.Instance.Items[4];
        }
        if (InventoryManager.Instance.Items.Count >= 6) itemSix = InventoryManager.Instance.Items[5];
        else
        {
            InventoryManager.Instance.Items.Add(spellItem);
            itemSix = InventoryManager.Instance.Items[5];
        }
        if (InventoryManager.Instance.Items.Count >= 7) itemSeven = InventoryManager.Instance.Items[6];
        else{
            InventoryManager.Instance.Items.Add(spellItem);
            itemSeven = InventoryManager.Instance.Items[6];
        }
        if (InventoryManager.Instance.Items.Count >= 8) itemEight = InventoryManager.Instance.Items[7];
        else
        {
            InventoryManager.Instance.Items.Add(spellItem);
            itemEight = InventoryManager.Instance.Items[7];
        }

        manaCost = InventoryManager.Instance.manaSum;
        atkCdwn = InventoryManager.Instance.cdwnSum;
        if (itemOne.id == 4 || itemTwo.id == 4 || itemThree.id == 4 || itemFour.id == 4 || itemFive.id == 4 || itemSix.id == 4 || itemSeven.id == 4 || itemEight.id == 4) explodes = true;
        if (itemOne.id == 2 || itemTwo.id == 2 || itemThree.id == 2 || itemFour.id == 2 || itemFive.id == 2 || itemSix.id == 2 || itemSeven.id == 2 || itemEight.id == 2) appliesSlowness = true;
        if (itemOne.id == 3 || itemTwo.id == 3 || itemThree.id == 3 || itemFour.id == 3 || itemFive.id == 3 || itemSix.id == 3 || itemSeven.id == 3 || itemEight.id == 3) appliesPoison = true;

        if (itemOne.id == 1) dmg += itemOne.value;
        if (itemTwo.id == 1) dmg += itemTwo.value;
        if (itemThree.id == 1) dmg += itemThree.value;
        if (itemFour.id == 1) dmg += itemFour.value;
        if (itemFive.id == 1) dmg += itemFive.value;
        if (itemSix.id == 1) dmg += itemSix.value;
        if (itemSeven.id == 1) dmg += itemSeven.value;
        if (itemEight.id == 1) dmg += itemEight.value;

        if (itemOne.id == 2) slowFactor += itemOne.value;
        if (itemTwo.id == 2) slowFactor += itemTwo.value;
        if (itemThree.id == 2) slowFactor += itemThree.value;
        if (itemFour.id == 2) slowFactor += itemFour.value;
        if (itemFive.id == 2) slowFactor += itemFive.value;
        if (itemSix.id == 2) slowFactor += itemSix.value;
        if (itemSeven.id == 2) slowFactor += itemSeven.value;
        if (itemEight.id == 2) slowFactor += itemEight.value;

        if (itemOne.id == 3) poisonDmg += itemOne.value;
        if (itemTwo.id == 3) poisonDmg += itemTwo.value;
        if (itemThree.id == 3) poisonDmg += itemThree.value;
        if (itemFour.id == 3) poisonDmg += itemFour.value;
        if (itemFive.id == 3) poisonDmg += itemFive.value;
        if (itemSix.id == 3) poisonDmg += itemSix.value;
        if (itemSeven.id == 3) poisonDmg += itemSeven.value;
        if (itemEight.id == 3) poisonDmg += itemEight.value;

        if (itemOne.id == 5) pierce += itemOne.value;
        if (itemTwo.id == 5) pierce += itemTwo.value;
        if (itemThree.id == 5) pierce += itemThree.value;
        if (itemFour.id == 5) pierce += itemFour.value;
        if (itemFive.id == 5) pierce += itemFive.value;
        if (itemSix.id == 5) pierce += itemSix.value;
        if (itemSeven.id == 5) pierce += itemSeven.value;
        if (itemEight.id == 5) pierce += itemEight.value;

        if (itemOne.id == 6) speed += itemOne.value;
        if (itemTwo.id == 6) speed += itemTwo.value;
        if (itemThree.id == 6) speed += itemThree.value;
        if (itemFour.id == 6) speed += itemFour.value;
        if (itemFive.id == 6) speed += itemFive.value;
        if (itemSix.id == 6) speed += itemSix.value;
        if (itemSeven.id == 6) speed += itemSeven.value;
        if (itemEight.id == 6) speed += itemEight.value;

        actualSpell = spell.GetComponent<ActualSpell>();
        actualSpell.pierce = pierce;
        actualSpell.damage = dmg;
        actualSpell.speed = speed;
        actualSpell.knockBack = knockback;
        actualSpell.appliesSpeed = appliesSpeed;
        actualSpell.appliesPoison = appliesPoison;
        actualSpell.appliesSlowness = appliesSlowness;
        actualSpell.explodes = explodes;
        actualSpell.poisonDmg = poisonDmg;
        actualSpell.slowFactor = slowFactor;
    }
    private void Update()
    {
        if (currentAtkCdwn > 0) currentAtkCdwn -= Time.deltaTime;

        if (Input.GetKeyDown(atkKey) && currentAtkCdwn <= 0 && playerMana.mana >= manaCost)
        {
            playerMana.ManaLose(manaCost);
            
            if (sp == spellType.self)
            {

            }
            else if (sp == spellType.rune)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Instantiate(spell, mousePosition, Quaternion.Euler(0, 0, 0));
            }
            else Instantiate(spell, aim.transform.position, aim.transform.rotation);
            currentAtkCdwn = atkCdwn;
        }
    }
}