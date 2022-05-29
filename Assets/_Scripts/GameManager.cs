using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character currentCharacter;
    public Character[] characters;


    public void Yes()
    {
        currentCharacter.lineNum += 2;
        currentCharacter.attractiveness += 1;
    }
    public void No()
    {
        currentCharacter.lineNum += 4;
        currentCharacter.attractiveness -= 1f;
    }
}

[Serializable]
public class Character
{
    public string name;
    public float attractiveness = 0;
    public int lineNum = 0;
    public string[] lines;
    public Sprite background;
}
