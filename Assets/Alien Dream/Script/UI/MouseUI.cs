using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class MouseUI : MonoBehaviour
{

    public Canvas Canva;
    public Vector2 Offset;

    // void Update()
    // {
    //     UpdatePointer();
    //     UpdatePos();
    // }

    public void SetAct(bool bHasChooseItem)
    {
        if (!bHasChooseItem)
        {
            GetComponent<Animator>().Play("CanAct");
        }
    }

    public void SetNotAct(bool bHasChooseItem)
    {
        if (!bHasChooseItem)
        {
            GetComponent<Animator>().Play("CanNotAct");
        }
    }

    public void SetIcon(int id)
    {
        if (id != 0)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<Image>().sprite = ItemsDatabase.Instance.Items[id].icon;
        }
        else
        {
            GetComponent<Animator>().enabled = true;
        }

    }

    public void UpdatePos(Vector2 ScreenMousePos)
    {
        Vector2 uiPos;
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(Canva.GetComponent<RectTransform>(), ScreenMousePos, null, out uiPos);
        GetComponent<RectTransform>().anchoredPosition = uiPos + Offset;

    }


}
