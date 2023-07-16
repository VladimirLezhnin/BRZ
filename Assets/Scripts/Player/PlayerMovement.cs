using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private float movementSpeed = 5f;
    private float rollSpeed = 50f;

    private float rollCoolDownTimeInSecond = 2;
    public bool IsDashing = false;

    public Vector2 Movement;
    private Animator Animator;

    private Dictionary<string, KeyCode> keyboardBinds = new Dictionary<string, KeyCode>() 
    {
        {"Left", KeyCode.A},
        {"Right", KeyCode.D},
        {"Up", KeyCode.W},
        {"Down", KeyCode.S},
        {"Roll", KeyCode.LeftShift}
    };

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move(keyboardBinds);
    }

    void FixedUpdate()
    {
            playerRigidBody.MovePosition(playerRigidBody.position + Movement * movementSpeed * Time.fixedDeltaTime);
            StartCoroutine(Roll());
    }

    private void Move(Dictionary<string, KeyCode> binds)
    {
        if (Input.GetKey(binds["Up"]))
            Movement.y = 1;
        else if (Input.GetKey(binds["Down"]))
            Movement.y = -1;
        else
            Movement.y = 0;

        if (Input.GetKey(binds["Right"]))
            Movement.x = 1;
        else if (Input.GetKey(binds["Left"]))
            Movement.x = -1;
        else
            Movement.x = 0;

        Animator.SetFloat("Horizontal", Movement.x);
        Animator.SetFloat("Speed", Movement.sqrMagnitude);
    }

    private void MoveByCoordinate(ref float coordinate, Dictionary<String, KeyCode> binds)
    {


        if (Input.GetKey(binds["Right"]))
            coordinate = 1;
        else if (Input.GetKey(binds["Left"]))
            coordinate = -1;
        else
            coordinate = 0;
    }

    private IEnumerator Roll() //я ебал —аню
    {
        if (Input.GetKey(keyboardBinds["Roll"]) && !IsDashing)
        {
            playerRigidBody.MovePosition(playerRigidBody.position + Movement * rollSpeed * Time.fixedDeltaTime);
            IsDashing = true;
            yield return new WaitForSeconds(rollCoolDownTimeInSecond);
            IsDashing = false;
        }
    }
}
