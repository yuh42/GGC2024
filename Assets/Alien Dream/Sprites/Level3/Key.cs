using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    private int KeyCount = 0;
    public override void OnClick()
    {
        if (MouseInputManager.Instance.ChooseItem == 23)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            BackpackManager.Instance.Drop();
        }
        else if (MouseInputManager.Instance.ChooseItem == 22)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            BackpackManager.Instance.Drop();
        }
        else if (MouseInputManager.Instance.ChooseItem == 24)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            BackpackManager.Instance.Drop();
        }
        KeyCount++;
        if (KeyCount == 3)
        {
            Battery.Instance.AddPower();
        }
    }
}
