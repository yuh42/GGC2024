using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    // Start is called before the first frame update
    public Transform[] Level;
    public AudioRes AudioRes;

    public GameObject SelectLevelCanva;
    public GameObject ChangeAnimation;
    public String[] Scene;


    private int nowLevel = 0;
    public void Jump(int index)
    {
        SceneManager.LoadScene(Scene[index]);
    }

    public void Exit()
    {

        Application.Quit();

    }

    public void Back()
    {
        if (nowLevel == 0)
        {
            Jump(0);
        }
        else
        {
            ChangeLevel(0);
        }
    }

    public void PlayAnimation()
    {
        ChangeAnimation.SetActive(true);
    }

    public void ChangeLevel(int levelID)
    {
        Camera.main.transform.position = Level[levelID].position+new Vector3(0,0,-20);
        if (levelID == 0)
        {
            SelectLevelCanva.SetActive(true);
        }
        else
        {
            SelectLevelCanva.SetActive(false);
            switch (levelID)
            {
                case 1:
                    SFX.Instance.SwitchBGM(AudioRes.bgm_野外丛林);
                    break;
                case 2:
                    SFX.Instance.SwitchBGM(AudioRes.bgm_咖啡馆);
                    break;
                case 3:
                    SFX.Instance.SwitchBGM(AudioRes.bgm_宇宙);
                    break;
                default:
                    break;
            }
        }
        // PlayAnimation();


    }

}
