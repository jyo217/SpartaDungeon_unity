using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "GameInfoController/ItemInfo", order = 1)]
public class ItemSO : ScriptableObject
{
    [Header("Item Info")]
    public int atk;
    public int def;
    public int con;
}
