using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : Item
{
    public override void OnClick()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
