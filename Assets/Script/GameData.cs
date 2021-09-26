using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int healthAmount;
    public bool hasSyringe;
    public int levelNum;

    public GameData(LevelManager data)
    {
        healthAmount = data.healthAmount;
        hasSyringe = data.hasSyringe;
        levelNum = data.levelNum;
    }
}
