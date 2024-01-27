using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/物品数据", order = 0)]
public class ItemDatabase : ScriptableObject
{
    public GameItem[] items;
}

[System.Serializable]
public class GameItem
{
    public int ItemID;
    public string ItemName;
    public Sprite ItemIcon;
    public GameObject ItemPrefab;
}
