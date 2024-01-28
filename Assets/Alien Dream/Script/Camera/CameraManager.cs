using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Timeline;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotateSpeed;
    public float MaxUp;
    public float MaxDown;
    public float MaxRight;
    public float MaxLeft;
    

    public Transform FarPanel;
    public Transform MidPanel;
    public Transform ClosePanel;

    // private float lookAngle;
    // private float tiltAngle;


    public float FarRate;
    public float MidRate;

    public float CloseRate;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float mx = -(MouseInputManager.Instance.ScreenMousePos.x - Screen.width / 2) / Screen.width * RotateSpeed;
        float my = -(MouseInputManager.Instance.ScreenMousePos.y - Screen.height / 2) / Screen.height * RotateSpeed;

        mx = Mathf.Clamp(mx, MaxLeft, MaxRight);
        my = Mathf.Clamp(my, MaxDown, MaxUp);

        FarPanel.position = new Vector3(mx * FarRate, my * FarRate, 0);
        MidPanel.position = new Vector3(mx * MidRate, my * MidRate, 0);
        ClosePanel.position = new Vector3(mx * CloseRate, my * CloseRate, 0);

        // Debug.Log(mx + " " + my);

        // transform.rotation = Quaternion.Euler(-my, mx, 0);

        // Quaternion qx = Quaternion.Euler(0, mx, 0);
        // Quaternion qy = Quaternion.Euler(my, 0, 0);
        // transform.rotation = qx * transform.rotation;
        // transform.rotation = transform.rotation * qy;


    }
}
