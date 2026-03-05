using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int hp;
    [SerializeField] private Animator anim;
    [SerializeField] private string baseAnim;
    [SerializeField] private const string hitAnim = "Hit";
    
    public bool reset;

    private void Update()
    {
        if (hp <= 0) Destroy(gameObject);
    }
    public void Dmg(int damage)
    {
        hp -= damage;
        reset = true;
        anim.Play(hitAnim);
    }

    public void Poison(int damage)
    {
        StartCoroutine(Poisoned(damage));
    }

    IEnumerator Poisoned(int damage)
    {
        Dmg(damage);
        yield return new WaitForSeconds(1.5f);
        Dmg(damage);
        yield return new WaitForSeconds(1.5f);
        Dmg(damage);
        yield return new WaitForSeconds(1.5f);
        Dmg(damage);
        yield return new WaitForSeconds(1.5f);
        Dmg(damage);
    }
}
