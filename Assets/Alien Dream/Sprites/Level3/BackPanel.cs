using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPanel : Item
{
    public override void OnClick()
    {
        gameObject.SetActive(false);
    }
}
