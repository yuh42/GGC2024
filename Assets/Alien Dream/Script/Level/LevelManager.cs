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
    // public AudioRes AudioRes;

    public GameObject SelectLevelCanva;
    public GameObject ChangeAnimation;
    public String[] Scene;

    public int StartBGM = 1;

    private int power = 0;

    void Start()
    {
        if (StartBGM == 1)
        {
            SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_主界面);
        }
        else if (StartBGM == 2)
        {
            SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_漫画1);
        }
        else if (StartBGM == 3)
        {
            SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_漫画2);
        }
        else if (StartBGM == 4)
        {
            SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_漫画3);
        }

    }

    public int nowLevel = 0;
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
        Camera.main.transform.position = Level[levelID].position + new Vector3(0, 0, -20);
        if (levelID == 0)
        {
            SelectLevelCanva.SetActive(true);
            SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_主界面);
        }
        else
        {
            SelectLevelCanva.SetActive(false);
            switch (levelID)
            {
                case 1:
                    SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_野外丛林);
                    break;
                case 2:
                    SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_咖啡馆);
                    break;
                case 3:
                    SFX.Instance.SwitchBGM(SFX.Instance.AudioRes.bgm_宇宙);
                    break;
                default:
                    break;
            }
        }
        nowLevel = levelID;
        // PlayAnimation();
    }

    public void End(){
        if(MouseInputManager.Instance.ChooseItem == 4){
            Jump(3);
        }
        else if(Battery.Instance.Powers<3){
            Jump(4);
        }
        else
        {
            Jump(3);
        }
    }

}
