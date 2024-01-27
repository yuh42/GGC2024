using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class ItemsDatabase : MonoSingleton<ItemsDatabase>
{

    // Start is called before the first frame update
    public Dictionary<int, Item> Items;
    public Sprite[] ItemIcon;
    void Awake()
    {
        string[] file = File.ReadAllLines(@"Assets/Alien Dream/DataBase/Items.csv");
        Items = new Dictionary<int, Item>();
        foreach (var item in file)
        {
            string[] s = item.Split(",");
            Item it = new Item();
            it.id = int.Parse(s[0]);
            it.name = s[1];
            it.type = int.Parse(s[2]);
            it.actnum = int.Parse(s[3]);

            string[] num = s[4].Split("|");
            it.input = new List<int>();
            foreach (var n in num)
            {
                it.input.Add(int.Parse(n));
            }

            num = s[5].Split("|");
            it.output = new List<int>();
            foreach (var n in num)
            {
                it.output.Add(int.Parse(n));
            }

            if (s[6] != "-1")
            {
                it.icon = ItemIcon[int.Parse(s[6])];
            }


            Items[it.id] = it;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public class Item
    {
        public int id;
        public string name;
        public int type;
        public int actnum;
        public List<int> input;
        public List<int> output;
        public Sprite icon;
    }
}
