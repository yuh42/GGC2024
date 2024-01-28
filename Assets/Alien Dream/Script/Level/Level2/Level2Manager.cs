using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoSingleton<Level2Manager>
{
    public GameObject Mom;

    public void OnCoffeeGet(){
        Mom.GetComponent<Animator>().Play("Happy");
        Battery.Instance.AddPower();
    }
}
