using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePointMovement : MonoBehaviour
{
    private PlayerMovement PlayerMovement;
    void Start()
    {
        PlayerMovement = transform.parent.parent.parent.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PutAttackPoint();
    }

    private void PutAttackPoint()
    {
        const float distanceX = 0.25f;
        const float distanceY = 0.7f;

        transform.localPosition = new Vector2(distanceX * PlayerMovement.Movement.x, distanceY * PlayerMovement.Movement.y);
    }
}
