using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public int currentSpell;
    public GameObject spellObject;
    public KeyCode rightSpellKey;
    public KeyCode leftSpellKey;

    void Start()
    {
        SelectWeapon();
    }
    void Update()
    {
        int previousSelectedSpell = currentSpell;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(rightSpellKey))
        {
            if (currentSpell >= transform.childCount - 1) currentSpell = 0;
            else currentSpell++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(leftSpellKey))
        {
            if (currentSpell <= 0) currentSpell = transform.childCount - 1;
            else currentSpell--;
        }

        if (previousSelectedSpell != currentSpell)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform spell in transform)
        {
            if (i == currentSpell)
                spell.gameObject.SetActive(true);
            else
                spell.gameObject.SetActive(false);
            i++;
        }
    }
}
