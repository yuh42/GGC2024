using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemID;
    public virtual void OnClick(){

    }
    // public void OnDragDown()
    // {
    //     bDragged = true;
    //     transform.GetComponent<Collider2D>().enabled = false;
    //     // MouseInputManager.Instance.OnLeftButtonUp += OnDragUp;
    //     OnDragStart();
    // }

    // public void OnDragUp()
    // {
    //     bDragged = false;
    //     transform.GetComponent<Collider2D>().enabled = true;
    //     // MouseInputManager.Instance.OnLeftButtonUp -= OnDragUp;
    //     OnDragEnd();
    // }

    // public virtual void OnClickDown()
    // {

    // }

    // public virtual void OnClickUp()
    // {

    // }
    // public virtual void OnDragStart() { }
    // public virtual void OnDragEnd() { }

    // Update is called once per frame
    // protected void Update()
    // {
    //     if (bDragged)
    //     {
    //         Vector2 target = MouseInputManager.Instance.WorldMousePos;
    //         transform.position = new Vector3(target.x, target.y, transform.position.z);
    //     }
    // }
}
