using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int hp;
    private void Update()
    {
        if (hp <= 0) Destroy(gameObject);
    }
    public void Dmg(int damage)
    {
        hp -= damage;
    }

    public void Poison(int damage)
    {
        StartCoroutine(Poisoned(damage));
    }

    IEnumerator Poisoned(int damage)
    {
        hp -= damage;
        yield return new WaitForSeconds(1.5f);
        hp -= damage;
        yield return new WaitForSeconds(1.5f);
        hp -= damage;
        yield return new WaitForSeconds(1.5f);
        hp -= damage;
        yield return new WaitForSeconds(1.5f);
        hp -= damage;
    }
}
