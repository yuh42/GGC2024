using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    // Start is called before the first frame update
    public enum LType{
        MainEnum,
        LevelChoose,
        Sublevel,
    }

    public String[] Scene;

    public LType LevelType;
    void Start()
    {
        
    }
    
    public void Jump(int index){
        SceneManager.LoadScene(Scene[index]);
    }

    public void Exit(){
        if(LevelType == LType.MainEnum){
            Application.Quit();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
