using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public float ItemPickUpRadius;

    private Camera Camera;
    void Start()
    {
        Camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ActiveObjects = Physics2D.OverlapCircleAll(Camera.ScreenToWorldPoint(Input.mousePosition), 3);
            var findActiveObjects = false;
            foreach (var obj in ActiveObjects)
            {
                var objDataScript = obj.GetComponent<ObjData>();

                if (objDataScript == null)
                    continue;

                if (objDataScript.IsInteractionObject)
                {
                    findActiveObjects = true;
                    objDataScript.ActivateByPlayer = true;
                }

                if (objDataScript.IsWeapon)
                    Weapon.PickUp(obj);
            }
            if (!findActiveObjects)
            {
                if (GameObject.FindGameObjectWithTag("Hand").GetComponentInChildren<Weapon>() != null)
                {
                    GameObject.FindGameObjectWithTag("Hand").GetComponentInChildren<Weapon>().attackAction = true;
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            var ActiveObjects = Physics2D.OverlapCircleAll(transform.position, ItemPickUpRadius);

            foreach(var obj in ActiveObjects)
            {
                if(obj.tag == "Item")
                    obj.GetComponent<Item>().Collected();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ItemPickUpRadius);
    }
}
