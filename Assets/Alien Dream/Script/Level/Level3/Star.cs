using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Item
{
    public GameObject BlackHole;
    public override void OnClick(){
        BlackHole.SetActive(true);
    }
}
