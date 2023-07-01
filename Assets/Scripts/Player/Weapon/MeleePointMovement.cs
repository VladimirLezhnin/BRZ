using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleePointMovement : MonoBehaviour
{
    private Transform PlayerMovement;
    private float Radius = 1;
    void Start()
    {
        PlayerMovement = transform.parent.parent.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetAttackDirection();
    }

    private void GetAttackDirection()
    {
        float x = (PlayerMovement.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        float y = (PlayerMovement.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        float angle = Mathf.Atan2(y, x);

        float newX = Mathf.Cos(angle);
        float newY = Mathf.Sin(angle);

        transform.localPosition = new Vector2(newX, -newY);
    }
}
