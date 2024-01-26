using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoSingleton<MouseInputManager>
{
    public event Action OnLeftButtonDown, OnRightButtonDown;
    public event Action OnLeftButtonUp, OnRightButtonUp;

    Vector2 mousePos;

    private bool bCanAct=false;
    private Animator m_animator;
    public Transform MousePos;
    // Start is called before the first frame update
    void Start()
    {
        m_animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SetType();
        Broadcast();

    }

    void SetType()
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if(hit.collider.tag == "Button" ){
            bCanAct = true;
            // Cursor.SetCursor()
        }else{
            bCanAct = false;
            m_animator.SetInteger("ActID",0);
        }
    }



    void Broadcast(){
        if (Input.GetMouseButtonDown(0)) { OnLeftButtonDown?.Invoke(); }
        if (Input.GetMouseButtonDown(1)) { OnRightButtonDown?.Invoke(); }
        if (Input.GetMouseButtonUp(0)) {  OnLeftButtonUp?.Invoke(); }
        if(Input.GetMouseButtonUp(1)) { OnRightButtonUp?.Invoke(); }
    }
}
