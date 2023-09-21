using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "GameInfoController/PlayerInfo", order = 0)]
public class PlayerSO : ScriptableObject
{
    [Header("Player Info")]
    public string playerName;
    public int atk;
    public int def;
    public int con;
    public int gold;
}
