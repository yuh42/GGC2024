using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // Start is called before the first frame update
    ItemsDatabase ItemData;
    Item clickedItem;
    void Start()
    {
        MouseInputManager.Instance.OnLeftButtonDown += OnClickDown;
        MouseInputManager.Instance.OnLeftButtonUp += Action;
        ItemData = ItemsDatabase.Instance;
    }

    void Action(Item item)
    {
        if (item == null || item != clickedItem )
        {
            return;
        }

        if (ItemData.Items[item.ItemID].type == 0)
        {
            item.OnClick();
        }
        else if (ItemData.Items[item.ItemID].type == 1)
        {
            BackpackManager.Instance.Add(item.ItemID);
            Destroy(item.gameObject);
        }
        else if (ItemData.Items[item.ItemID].type == 2)
        {
            HandleCombin(item);
        }
        
    }

    void OnClickDown(Item item)
    {
        clickedItem = item;
    }

    void HandleCombin(Item item)
    {
        if (MouseInputManager.Instance.ChooseItem == 0)
        {
            return;
        }

        if (ItemData.Items[item.ItemID].input.Contains(MouseInputManager.Instance.ChooseItem))
        {
            

            BackpackManager.Instance.Drop();
            foreach (var output in ItemData.Items[item.ItemID].output)
            {
                BackpackManager.Instance.Add(output);
            }

            Destroy(item.gameObject);

        }
        else
        {
            BackpackManager.Instance.NotUse();
            MouseInputManager.Instance.ChooseItem = 0;
        }

    }
}