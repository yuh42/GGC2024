using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Item
{
    public GameObject ControlPanel;
    public override void OnClick()
    {
        ControlPanel.SetActive(true);
    }
}
