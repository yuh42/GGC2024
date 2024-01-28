using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebone : Item
{
    // Start is called before the first frame update
    public override void OnClick()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
