using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject Target;
    private int StopRadius;

    public float Speed;

    void Start()
    {
        StopRadius = GetComponent<MeleeAttack>().Radius;
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var distance = Vector2.Distance(Target.transform.position, transform.position);

        if (distance > StopRadius)
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }
}
