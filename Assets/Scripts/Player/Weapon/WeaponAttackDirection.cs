using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponAttackDirection : MonoBehaviour
{
    private Transform PlayerMovement;
    void Start()
    {
        PlayerMovement = transform.parent.parent.parent;
    }

    void FixedUpdate()
    {
        GetAttackDirection();
    }

    private void GetAttackDirection()
    {
        var angle = GetAngle();

        float newX = Mathf.Cos(angle);
        float newY = Mathf.Sin(angle);

        transform.localPosition = new Vector2(-newX, -newY);
    }

    public float GetAngle()
    {
        float x = (PlayerMovement.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        float y = (PlayerMovement.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        float angle = Mathf.Atan2(y, x);

        return angle;
    }
}
