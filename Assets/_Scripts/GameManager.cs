using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character currentCharacter;
    public Character[] characters;
    public Parser parser;

    public void Start()
    {
        parser = GetComponent<Parser>();
        parser
    }

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
