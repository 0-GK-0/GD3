using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public List<GameObject> possibleDrops;

    public void Death(GameObject objToDie, string deathAnim)
    {
        int dropN = Random.Range(0, possibleDrops.Count);

        GameObject drop = possibleDrops[dropN];

        Animator anim = objToDie.GetComponent<Animator>();
        StartCoroutine(DeathCoroutine(drop, objToDie, anim, deathAnim));
    }

    private IEnumerator DeathCoroutine(GameObject drop, GameObject objToDie, Animator anim, string deathAnim)
    {
        anim.Play(deathAnim);
        
        yield return new WaitForSeconds(0.5f);

        Instantiate(drop, transform.position, Quaternion.identity);
        Destroy(objToDie);
    }
}