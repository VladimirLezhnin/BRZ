using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public float Speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            var enemyScript = collision.GetComponent<Enemy>();
            enemyScript.TakeDamage(Damage);
        }
    }
}
