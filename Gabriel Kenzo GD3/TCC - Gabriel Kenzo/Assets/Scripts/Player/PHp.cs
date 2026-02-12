using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHp : MonoBehaviour
{
    //Values
    [Header("Values")]
    public int hp;
    public int maxHp;
    public float invFrame;
    public float maxInvFrame;

    [Header("Bools")]
    public bool isDead = false;

    [Header("UI")]
    [SerializeField] private Image hpBar;

    [Header("References")]
    [SerializeField] private PMove pMove;

    private void Start(){
        hp = maxHp;
    }

    private void Update(){
        if(invFrame > 0) invFrame -= Time.deltaTime;
    }

    public void Heal(int heal){
        if(maxHp <= hp + heal) hp += heal;
        else hp = maxHp;

        hpBar.fillAmmount = hp/maxHp;
    }

    public void Dmg(int dmg){
	    if(ivFrame <= 0){
		    if(hp > dmg){
			    hp -= dmg;
                invFrame = maxInvFrame;
		    }
		    else{
			    Die();
		    }
	    }

        hpBar.fillAmmount = hp/maxHp;
    }

    public void Die(){
        isDead = true;
    }
}
