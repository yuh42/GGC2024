using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Item
{
    // Start is called before the first frame update
    public override void OnClick()
    {
        GetComponent<Animator>().Play("Stand");
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
