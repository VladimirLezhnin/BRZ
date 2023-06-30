using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public bool attackAction;

    private void Start()
    {
        attackAction = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackAction)
            Attack();
    }

    private void Attack()
    {
        //Play attack Animation

        var hittedEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange);
        
        foreach(var enemy in hittedEnemies)
        {
            if (enemy.tag != "Enemy")
                continue;

            var enemyClass = enemy.GetComponent<Enemy>();

            enemyClass.TakeDamage(Damage);
        }
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
