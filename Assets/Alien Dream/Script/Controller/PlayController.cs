using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // Start is called before the first frame update
    ItemsDatabase ItemData;
    Item clickedItem;
    public GameObject NewItem;
    void Start()
    {
        MouseInputManager.Instance.OnLeftButtonDown += OnClickDown;
        MouseInputManager.Instance.OnLeftButtonUp += Action;
        ItemData = ItemsDatabase.Instance;
    }

    void Action(Item item)
    {
        if (item == null || item != clickedItem)
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
        else if (ItemData.Items[item.ItemID].type == 2 || ItemData.Items[item.ItemID].type == 4)
        {
            HandleCombin(item);
        }
        else if (ItemData.Items[item.ItemID].type == 3)
        {
            if (MouseInputManager.Instance.ChooseItem != 0 && ItemData.Items[item.ItemID].input.Contains(MouseInputManager.Instance.ChooseItem))
            {
                item.OnClick();
                BackpackManager.Instance.Drop();
            }
        }


    }

    void OnClickDown(Item item)
    {
        clickedItem = item;
    }

    void HandleCombin(Item item)
    {

        if (MouseInputManager.Instance.ChooseItem != 0 && ItemData.Items[item.ItemID].input.Contains(MouseInputManager.Instance.ChooseItem))
        {


            BackpackManager.Instance.Drop();
            foreach (var output in ItemData.Items[item.ItemID].output)
            {
                if (ItemData.Items[output].type == 1)
                {
                    BackpackManager.Instance.Add(output);
                }
                else
                {
                    Instantiate(NewItem, item.transform.position, item.transform.rotation);
                    NewItem.GetComponent<Item>().ItemID = output;
                    NewItem.GetComponent<SpriteRenderer>().sprite = ItemData.Items[output].icon;
                }


            }
            item.OnClick();
            if (ItemData.Items[item.ItemID].type == 2)
            {
                Destroy(item.gameObject);
            }


        }
    }
}
