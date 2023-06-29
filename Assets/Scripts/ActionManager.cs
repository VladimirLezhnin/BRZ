using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
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
                if (obj.GetComponent<ObjData>().IsInteractionObject)
                {
                    findActiveObjects = true;
                    obj.GetComponent<ObjData>().ActivateByPlayer = true;
                }
            }
            if (!findActiveObjects)
            {
                if (GameObject.FindGameObjectWithTag("Hand").GetComponentInChildren<Weapon>() != null)
                {
                    GameObject.FindGameObjectWithTag("Hand").GetComponentInChildren<Weapon>().attackAction = true;
                }
            }
        }
    }
}
