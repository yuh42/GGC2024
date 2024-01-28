using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dad : MonoBehaviour
{
    // Start is called before the first frame update
    int targets=0;
    void Start(){
        Level1Manager.Instance.OnEyesDestroyEvent += TaskFinish;
        Level1Manager.Instance.OnFishGetEvent += TaskFinish;
    }

    public void TaskFinish(){
        targets++;
        if(targets==2){
            GetComponent<Animator>().Play("Happy");
            Level1Manager.Instance.OnTargetFinish();
        }
    }

}
