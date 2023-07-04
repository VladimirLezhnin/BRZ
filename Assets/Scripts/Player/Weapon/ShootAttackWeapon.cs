using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttackWeapon : MonoBehaviour
{
    [SerializeField] private GameObject AttackDirection;
    [SerializeField] private GameObject BulletPrefab;

    private Weapon WeaponScript;

    private void Start()
    {
        WeaponScript = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && WeaponScript.attackAction)
            Shoot();
    }

    private void Shoot()
    {
        var directionScript = AttackDirection.GetComponent<WeaponAttackDirection>();
        var angleInRadians = directionScript.GetAngle();
        var angleInDegrees = angleInRadians * (180 / Mathf.PI);

        Instantiate(BulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angleInDegrees-180)));
        Debug.Log(angleInDegrees);
    }
}
