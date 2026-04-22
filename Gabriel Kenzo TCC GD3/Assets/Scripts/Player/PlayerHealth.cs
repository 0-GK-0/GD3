using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [field: Header("Health")]
    public int hp;
    public int maxHp = 100;

    [field: Header("Invincibility Frame")]
    public float invFrame;
    public float maxInvFrame;
    [SerializeField] private SpriteRenderer _playerRender;

    [field: Header("Healing")]
    public int healingFactor;
    public float timeToHeal;
    public float timeToHealAfterDmg;
    private float _timeLeftToHeal;

    [field: Header("UI")]
    [field: SerializeField] public Image hpBar {get; private set;}
    [field: SerializeField] public Image hpSpentBar {get; private set;}
    [SerializeField] private float _lerpSpeed = 0.05f;


    [field: Header("Scene Switching")]
    [field:SerializeField] public SwitchScene switchScene {get; private set;}
    private string _currentScene;

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        if(invFrame > 0) invFrame -= Time.deltaTime;

        NaturalHeal();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Dmg(10);
        }

        //HpBar
        if (hpBar.fillAmount != (float)hp / (float)maxHp) hpBar.fillAmount = (float)hp / (float)maxHp;
        if (hpSpentBar.fillAmount != hpBar.fillAmount) hpSpentBar.fillAmount = Mathf.Lerp(hpSpentBar.fillAmount, (float)hp / 100, _lerpSpeed);

        //Death
        if (hp <= 0) switchScene.LoadScene(_currentScene);
    }

    private  void NaturalHeal()
    {
        if (hp < maxHp)
        {
            _timeLeftToHeal -= Time.deltaTime;
            
            if (_timeLeftToHeal <= 0) Heal(healingFactor);
        }
    }

    public void Heal(int heal)
    {
        if (hp + heal < maxHp) hp += heal;
        else hp = maxHp;

        _timeLeftToHeal = timeToHeal;
    }

    public void Dmg(int damage)
    {
        hp -= damage;
        _timeLeftToHeal = timeToHealAfterDmg;

        invFrame = maxInvFrame;
        StartCoroutine(RedFlash());
    }

    //Flash red when hit
    private IEnumerator RedFlash()
    {
        _playerRender.color = Color.red;
        yield return new WaitForSeconds(maxInvFrame);
        _playerRender.color = Color.white;
    }
}
