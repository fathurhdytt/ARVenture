using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropNew : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectPlaceHolder;

    public float DropDistance;
    public bool isLocked;

    Vector2 objectInitPos;

    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float distance = Vector3.Distance(objectToDrag.transform.position, objectPlaceHolder.transform.position);

        if (distance < DropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectPlaceHolder.transform.position;
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
        }
    }
}
