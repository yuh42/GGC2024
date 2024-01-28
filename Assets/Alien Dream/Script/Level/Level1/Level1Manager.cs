using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Level1Manager : MonoSingleton<Level1Manager>
{
    int EyesCount = 7;
    public event Action OnEyesDestroyEvent;
    public event Action OnFishGetEvent;
    public Battery Battery;
    // public bool bHappy=false;
    // public bool bStand=false;
    // public bool bNude=false;
    public bool DestroyEye()
    {
        EyesCount--;
        if (EyesCount == 0)
        {
            OnEyesDestroyEvent.Invoke();
            return true;
        }
        return false;
    }

    public void OnTargetFinish(){
        Battery.AddPower();
    }

    public void Back(){
        LevelManager.Instance.ChangeLevel(0);
    }
}
