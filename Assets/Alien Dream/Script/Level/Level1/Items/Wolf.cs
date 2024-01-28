using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Wolf : MonoBehaviour
{

    public GameObject NomalWolf;
    public GameObject RedWolf;

    public GameObject RedEye;
    void Start()
    {
        Level1Manager.Instance.OnEyesDestroyEvent += Change;
    }


    void Change()
    {
        GetComponent<Animator>().Play("Nude");
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
