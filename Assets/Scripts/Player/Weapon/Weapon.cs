using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;

    private void Update()
    {
        GetAction();
    }

    private void Attack()
    {
        //Play attack Animation

        var hittedEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);
        
        foreach(var enemy in hittedEnemies)
        {
            var enemyClass = enemy.GetComponent<Enemy>();

            enemyClass.TakeDamage(Damage);
        }
    }

    private void GetAction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
