using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackpackManager : MonoSingleton<BackpackManager>
{
    // Start is called before the first frame update
    public Transform[] Buttons = new Transform[9];
    public Transform Choose;
    private int[] storeItems = new int[9];
    private Transform icon;
    private int chooseIndex;
    void Start()
    {

    }
    public void Add(int id)
    {
        int index = 0;
        while (storeItems[index] != 0 && index < 9)
        {
            index++;
        }
        icon = Buttons[index].GetChild(0);
        icon.GetComponent<Image>().sprite = ItemsDatabase.Instance.Items[id].icon;
        icon.GetComponent<Image>().color = Color.white;
        storeItems[index] = id;
    }

    public void Use(int index)
    {
	var inst = MonoSingleton<SFX>.Instance; inst.PlaySound(inst.AudioRes.effects[11]);
        if (storeItems[index] == 0)
        {
            return;
        }

        int id_1 = MouseInputManager.Instance.ChooseItem, id_2 = storeItems[index];
        
        if(id_1 != 0 && ItemsDatabase.Instance.Items[id_2].type != 0 )
        {            
            if(ItemsDatabase.Instance.Items[id_2].input.Contains(id_1)){
                Drop();
                Drop(index);
                foreach(var id in ItemsDatabase.Instance.Items[id_2].output){
                    Add(id);
                }
                
            }
            return;
        }

        chooseIndex = index;
        icon = Buttons[index].GetChild(0);
        // icon.GetComponent<Image>().color = Color.grey;
        Choose.position = Buttons[index].position;
        Choose.gameObject.SetActive(true);
        Text name = Choose.GetChild(0).GetChild(0).GetComponent<Text>();
        name.text = ItemsDatabase.Instance.Items[storeItems[index]].name;
        MouseInputManager.Instance.ChooseItem = storeItems[index];
    }

    public void StopUse()
    {
        Choose.gameObject.SetActive(false);
    }

    public void Drop()
    {
        storeItems[chooseIndex] = 0;
        icon.GetComponent<Image>().sprite = null;
        icon.GetComponent<Image>().color = Color.clear;
        MouseInputManager.Instance.ChooseItem = 0;
    }

    public void Drop(int index)
    {
        storeItems[index] = 0;
        Buttons[index].GetChild(0).GetComponent<Image>().sprite = null;
        Buttons[index].GetChild(0).GetComponent<Image>().color = Color.clear;
    }

}
