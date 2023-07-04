using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool attackAction;

    private void Start()
    {
        attackAction = false;

        if(transform.parent.tag == "Hand")
        {
            PickUp(gameObject);
            attackAction = true;
        }
    }
    public static void PickUp(GameObject weapon)
    {
        weapon.transform.parent = GameObject.FindGameObjectsWithTag("Hand")[0].transform;
        weapon.transform.localPosition = Vector2.zero;

        var attackPoint = weapon.transform.GetChild(0).gameObject;
        attackPoint.SetActive(true);
    }
    public static void PickUp(Collider2D weapon)
    {
        var weaponGameObject = weapon.gameObject;
        PickUp(weaponGameObject);
    }
}
