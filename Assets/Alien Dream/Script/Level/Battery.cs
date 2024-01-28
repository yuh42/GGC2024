using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battery : MonoSingleton<Battery>
{
    int Powers = 0;
    public void AddPower(){
        Powers++;
        GetComponent<Animator>().Play(Powers);
    }
}
