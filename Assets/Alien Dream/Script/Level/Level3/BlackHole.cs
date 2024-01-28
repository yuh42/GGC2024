using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Item
{
  public override void OnClick()
  {
        GetComponent<Animator>().Play("FixedBlackHole");
  }
}
