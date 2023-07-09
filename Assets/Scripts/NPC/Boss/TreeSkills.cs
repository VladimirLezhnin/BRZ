using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSkills : MonoBehaviour
{
    [SerializeField] private int RootsPunchDamage;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void RootsPunch()
    {
        player.TakeDamage(RootsPunchDamage);
    }

    private void ThrowPlayer()
    {
        new NotImplementedException();
    }

    private void ShootSpikes()
    {
        new NotImplementedException();
    }

    private void RootsFloor()
    {
        new NotImplementedException();
    }

    private void MinionsAttack()
    {
        new NotImplementedException();
    }

    private void LeafTornado()
    {
        new NotImplementedException();
    }
}
