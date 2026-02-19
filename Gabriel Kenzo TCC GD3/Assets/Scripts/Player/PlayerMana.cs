using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public int mana;
    public int maxMana = 100;
    public int manaRecovery;
    public float timeToMana;
    public float timeLeftToMana;
    public Image manaBar;
    public Image manaSpentBar;
    [SerializeField] private float lerpSpeed = 0.05f;
    public TMP_Text noManaText;

    void Start()
    {
        mana = maxMana;
        timeLeftToMana = timeToMana;
    }

    void Update()
    {
        NaturalRecovery();
        if (Input.GetKeyDown(KeyCode.F))
        {
            ManaLose(10);
        }

        if (manaBar.fillAmount != (float)mana / (float)maxMana)
        {
            manaBar.fillAmount = (float)mana / (float)maxMana;
        }
        if (manaSpentBar.fillAmount != manaBar.fillAmount)
        {
            manaSpentBar.fillAmount = Mathf.Lerp(manaSpentBar.fillAmount, (float)mana / 100, lerpSpeed);
        }
    }

    public void NaturalRecovery()
    {
        if (mana < maxMana)
        {
            timeLeftToMana -= Time.deltaTime;
            if (timeLeftToMana <= 0)
            {
                RecoverMana(manaRecovery);
            }
        }
    }

    public void RecoverMana(int recover)
    {
        if (mana + recover >= maxMana) mana = maxMana;
        else mana += recover;
        timeLeftToMana = timeToMana;
    }

    public void ManaLose(int manaLost)
    {
        if (mana < manaLost)
        {
            StartCoroutine(NoManaText());
        }
        mana -= manaLost;
        timeLeftToMana = timeToMana;
    }

    IEnumerator NoManaText()
    {
        noManaText.color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(1);
        noManaText.color = new Color32(255, 255, 255, (byte)Mathf.Lerp(255, 0, 1f));
    }

}
