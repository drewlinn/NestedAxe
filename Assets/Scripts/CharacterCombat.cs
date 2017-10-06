using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    public float attackspeed = 1f;
    public float attackCooldown = 0f;

    public float attackDelay = .6f;

    CharacterStats myStats;

    void Start ()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update ()
    {
        attackCooldown -= Time.deltaTime;
    }

       public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0f) {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            attackCooldown = 1f / attackspeed;
        }
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }

}
