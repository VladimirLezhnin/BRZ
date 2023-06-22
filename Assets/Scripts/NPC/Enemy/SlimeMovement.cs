using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    private GameObject Target;

    [SerializeField] private float JumpDistance;
    [SerializeField] private float JumpSpeed;

    private bool Jumping = false;
    private Vector2 JumpStartPosition;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        JumpStartPosition = transform.position;
    }

    void Update()
    {

    }

    private void JumpMove()
    {
        new NotImplementedException();
    }
}
