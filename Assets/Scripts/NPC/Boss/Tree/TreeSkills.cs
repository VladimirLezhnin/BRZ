using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSkills : MonoBehaviour
{
    [HideInInspector] public bool OnAction;

    [SerializeField] private int RootsPunchDamage;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

    }

    private void RootsPunch()
    {
        var playerScript = player.GetComponent<Player>();

        playerScript.TakeDamage(RootsPunchDamage);
    }

    private IEnumerator ThrowPlayer()
    {
        var playerStartPosition = player.transform.position;
        var playerEndPosition = transform.position + transform.position - player.transform.position;

        for(int i = 0; i < 50; i++)
        {
            player.transform.position = Vector3.Lerp(playerStartPosition, playerEndPosition, i * 0.02f);
            yield return null;
        }
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
