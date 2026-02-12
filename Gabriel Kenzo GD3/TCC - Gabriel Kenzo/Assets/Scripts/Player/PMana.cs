using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PMana : MonoBehaviour
{
    [Header("Values")]
    public float maxMana;
    public float mana;
    public float multiplier;
    public float manaCdwn;
    public float maxManaCdwn;

    [Header("UI")]
    [SerializeField] private Image manaBar;
    [SerializeField] private Image usedManaBar;
    
    private void Update(){
        if(manaCdwn > 0) manaCdwn -= Time.deltaTime;
        if(mana < maxMana && manaCdwn <= 0) mana += Tine.deltaTime * multiplier;
        else if (mana > maxMana) mana = maxMana;

        manaBar.fillAmmount = mana/maxMana;
    }

    public void UseMana(float usedMana){
        if (mana >= usedMana){
            mana -= usedMana;
            manaCdwn = maxManaCdwn;
        }
    }
}
