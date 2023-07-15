using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeSkills : MonoBehaviour
{
    [HideInInspector] public bool OnAction;
    [SerializeField] private int RootsPunchDamage;
    [SerializeField] private GameObject Spike;
    [SerializeField] private GameObject Minion;

    private bool IsAttacking = false;

    private Action<TreeSkills>[] Skills = new Action<TreeSkills>[] {
        (z) => z.RootsPunch(),
        (z) => z.ThrowPlayer(),
        (z) => z.ShootSpikes()
    };

    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(!IsAttacking)
            StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        var randomValue = UnityEngine.Random.Range(0, Skills.Length);

        IsAttacking = true;

        if(randomValue == 1)
            StartCoroutine(ThrowPlayer());
        else
            Skills[randomValue](this);

        yield return new WaitForSeconds(4);
        IsAttacking = false;
    }

    private void RootsPunch()
    {
        var playerScript = Player.GetComponent<Player>();
        playerScript.TakeDamage(RootsPunchDamage);
    }

    private IEnumerator ThrowPlayer()
    {
        var playerStartPosition = Player.transform.position;
        var playerEndPosition = transform.position + transform.position - Player.transform.position;

        for(int i = 0; i < 50; i++)
        {
            Player.transform.position = Vector3.Lerp(playerStartPosition, playerEndPosition, i * 0.02f);
            yield return null;
        }
    }

    private void ShootSpikes()
    {
        var numberOfSpiked = 16;

        for(int i = 0; i < numberOfSpiked; i++)
        {
            var angleInRadians = Mathf.PI / (numberOfSpiked / 2) * i;

            var angleInDegrees = angleInRadians * (180 / Mathf.PI);

            Instantiate(Spike, transform.position, Quaternion.Euler(new Vector3(0, 0, angleInDegrees-90)));
        }
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
