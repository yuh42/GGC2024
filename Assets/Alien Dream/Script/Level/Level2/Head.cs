using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : Item
{
    // Start is called before the first frame update
    public Sprite[] pointers;
    private int index = 0;
    public int Answer;
    public override void OnClick()
    {
        index = index == 7 ? 0 : index + 1;
        GetComponent<SpriteRenderer>().sprite = pointers[index];
        if(index == Answer ){
            GetComponent<Collider2D>().enabled = false;
            BackpackManager.Instance.Add(23);
        }
    }
}
