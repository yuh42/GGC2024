using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Timeline;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotateSpeed;
    public float MaxUpAngle;
    public float MaxDownAngle;

    private float lookAngle;
    private float tiltAngle;

    public float LerpSpeed;
    float R_H;
    float R_V;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // R_H = Input.GetAxis("Horizontal") * RotateSpeed;
        // R_V = Input.GetAxis("Vertical") * RotateSpeed;



        // lookAngle += R_H;
        // tiltAngle += R_V;


        float mx = (MouseInputManager.Instance.ScreenMousePos.x - Screen.width / 2) / Screen.width * RotateSpeed;
        float my = (MouseInputManager.Instance.ScreenMousePos.y - Screen.height / 2) / Screen.height * RotateSpeed;

        mx =  Mathf.Clamp(mx, MaxDownAngle, MaxUpAngle);
        my =  Mathf.Clamp(my, MaxDownAngle, MaxUpAngle);

        Debug.Log(mx + " " + my);

        transform.rotation = Quaternion.Euler(-my, mx, 0);

        // Quaternion qx = Quaternion.Euler(0, mx, 0);
        // Quaternion qy = Quaternion.Euler(my, 0, 0);
        // transform.rotation = qx * transform.rotation;
        // transform.rotation = transform.rotation * qy;


    }
}
