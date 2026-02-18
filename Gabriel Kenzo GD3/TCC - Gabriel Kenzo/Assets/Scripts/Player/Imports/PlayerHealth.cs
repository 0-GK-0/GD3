using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;
    public int healingFactor;
    public float timeToHeal;
    public float timeToHealAfterDmg;
    public float timeLeftToHeal;
    public Image hpBar;
    public Image hpSpentBar;
    public SwitchScene switchScene;
    public string currentScene;
    [SerializeField] private float lerpSpeed = 0.05f;

    void Start()
    {
        hp = maxHp;
        timeLeftToHeal = timeToHeal;
    }

    void Update()
    {
        NaturalHeal();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Dmg(10);
        }

        if (hpBar.fillAmount != (float)hp / (float)maxHp)
        {
            hpBar.fillAmount = (float)hp / (float)maxHp;
        }
        if (hpSpentBar.fillAmount != hpBar.fillAmount)
        {
            hpSpentBar.fillAmount = Mathf.Lerp(hpSpentBar.fillAmount, (float)hp / 100, lerpSpeed);
        }

        if (hp <= 0) switchScene.LoadScene(currentScene);
    }

    public void NaturalHeal()
    {
        if (hp < maxHp)
        {
            timeLeftToHeal -= Time.deltaTime;
            if (timeLeftToHeal <= 0)
            {
                Heal(healingFactor);
            }
        }
    }

    public void Heal(int heal)
    {
        if (hp + heal >= maxHp) hp = maxHp;
        else hp += heal;
        timeLeftToHeal = timeToHeal;
    }

    public void Dmg(int damage)
    {
        hp -= damage;
        timeLeftToHeal = timeToHealAfterDmg;
    }
}
