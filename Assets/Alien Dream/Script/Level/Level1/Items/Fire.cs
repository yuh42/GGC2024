using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Item
{
    public override void OnClick()
    {
        Level1Manager.Instance.GetFish();
    }
}
