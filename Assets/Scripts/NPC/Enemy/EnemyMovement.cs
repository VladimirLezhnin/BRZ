using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject Target;
    private float StopRadius;

    public float Speed;

    void Start()
    {
        StopRadius = GetComponent<MeleeAttack>().Radius;
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //MoveEvenly();
        if (GetComponent<Enemy>().name.Contains("Slime"))
        {
            MovePeriodically();
        }
    }

    private void MovePeriodically()
    {
        var distance = Vector2.Distance(Target.transform.position, transform.position);

        if (distance > StopRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime * Mathf.Abs((float)System.Math.Sin(Time.timeSinceLevelLoadAsDouble)));
        }
        
    }

    private void MoveEvenly()
    {
        var distance = Vector2.Distance(Target.transform.position, transform.position);

        if (distance > StopRadius)
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }

}
