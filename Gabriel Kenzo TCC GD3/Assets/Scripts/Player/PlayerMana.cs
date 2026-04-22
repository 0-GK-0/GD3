using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    [field: Header("Mana")]
    public int mana;
    public int maxMana = 100;

    [field: Header("Mana Recovery")]
    public int manaRecovery;
    public float timeToMana;
    [field: SerializeField] private float _timeLeftToMana;

    [field: Header("UI")]
    [SerializeField] private Image _manaBar;
    [SerializeField] private Image _manaSpentBar;
    [SerializeField] private float lerpSpeed = 0.05f;
    [SerializeField] private TMP_Text noManaText;

    void Start()
    {
        mana = maxMana;
    }

    void Update()
    {
        NaturalRecovery();
        if (Input.GetKeyDown(KeyCode.F))
        {
            ManaLose(10);
        }

        //Mana bar
        if (_manaBar.fillAmount != (float)mana / (float)maxMana) _manaBar.fillAmount = (float)mana / (float)maxMana;
        if (_manaSpentBar.fillAmount != _manaBar.fillAmount) _manaSpentBar.fillAmount = Mathf.Lerp(_manaSpentBar.fillAmount, (float)mana / 100, lerpSpeed);
    }

    public void NaturalRecovery()
    {
        if (mana < maxMana)
        {
            _timeLeftToMana -= Time.deltaTime;
            
            if (_timeLeftToMana <= 0) RecoverMana(manaRecovery);
        }
    }

    public void RecoverMana(int recover)
    {
        if (mana + recover < maxMana) mana += recover;
        else mana = maxMana;

        _timeLeftToMana = timeToMana;
    }

    public void ManaLose(int manaLost)
    {
        if (mana < manaLost) StartCoroutine(NoManaText());
        mana -= manaLost;

        _timeLeftToMana = timeToMana;
    }

    IEnumerator NoManaText()
    {
        noManaText.color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(1);
        noManaText.color = new Color32(255, 255, 255, (byte)Mathf.Lerp(255, 0, 1f));
        Debug.Log("NoMana");
    }

}
