using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int Damage;
    public int Radius;
    [SerializeField] private float CooldownInSeconds;
    private float coolDownInSecondValue;

    private GameObject Target;

    void Start()
    {
        coolDownInSecondValue = CooldownInSeconds;
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        AttackCooldown();
    }

    private void Attack()
    {
        float distance = Vector2.Distance(transform.position, Target.transform.position);

        if (distance < Radius && CooldownInSeconds <= 0)
        {
            var targetClass = Target.GetComponent<Player>();
            targetClass.TakeDamage(Damage);

            CooldownInSeconds = coolDownInSecondValue;
        }
    }

    private void AttackCooldown()
    {
        if (CooldownInSeconds > 0)
            CooldownInSeconds -= Time.deltaTime;
    }
}
