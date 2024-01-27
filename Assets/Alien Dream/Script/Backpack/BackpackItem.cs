// using System.Collections;
// using System.Collections.Generic;
// using Fungus;
// using UnityEngine;

// public class BackpackItem : Item
// {
//     // Start is called before the first frame update
//     private Flowchart flowchart;
//     public override void OnDragEnd()
//     {
//         if (MouseInputManager.Instance.hit.collider.tag == "Test")
//         {
//             flowchart.SetIntegerVariable("Var", 1);
//         }
//         else if (MouseInputManager.Instance.hit.collider.tag == "BackGround")
//         {
//             flowchart.SetIntegerVariable("Var", -1);
//         }
//         else
//         {
//             flowchart.SetIntegerVariable("Var", 0);
//         }

//         if (flowchart.HasBlock("钥匙"))
//         {
//             flowchart.ExecuteBlock("钥匙");
//         }
//     }

//     void Start()
//     {
//         flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         base.Update();
//     }
// }
