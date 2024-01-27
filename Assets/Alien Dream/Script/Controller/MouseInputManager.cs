using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseInputManager : MonoSingleton<MouseInputManager>
{
    public event Action<Item> OnLeftButtonDown;
    public event Action<Item> OnLeftButtonUp;

    public Vector2 WorldMousePos;
    public Vector2 ScreenMousePos;

    public bool bCanAct = false;

    public int ChooseItem = 0;
    public MouseUI MouseUI;

    // public Transform MousePos;
    public RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScreenMousePos = Input.mousePosition;
        WorldMousePos = Camera.main.ScreenToWorldPoint(ScreenMousePos);
        hit = Physics2D.Raycast(WorldMousePos, Vector2.zero);
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            SetType();
            OnClick();
        }
        MouseUI.SetIcon(ChooseItem);
        MouseUI.UpdatePos(ScreenMousePos);
    }

    void SetType()
    {
        if (hit.collider != null && hit.collider.tag == "Item")
        {
            bCanAct = true;
            MouseUI.SetAct(ChooseItem != 0);
        }
        else
        {
            bCanAct = false;
            MouseUI.SetNotAct(ChooseItem != 0);
        }
    }


    void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            OnLeftButtonDown?.Invoke(hit.collider == null ? null : hit.transform.GetComponent<Item>());

        }

        if (Input.GetMouseButtonUp(0))
        {
            OnLeftButtonUp?.Invoke(hit.collider == null ? null : hit.transform.GetComponent<Item>());
            MouseInputManager.Instance.ChooseItem = 0;
        }

    }

}

