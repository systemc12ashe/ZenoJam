using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character currentCharacter;
    public Character[] characters;
    public parser parser;
    public TextScrolling textScrolling;
    public GameObject yesNoButtons;
    public Image backgroundImage;
    public TMP_Text dialogueText;

    public void Start()
    {
        parser = GetComponent<parser>();
        parser.GetConversationText();
        textScrolling.displayText();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].name == "Beatrice")
                characters[i].lines = parser.beatrice.ToArray();
            else if(characters[i].name == "Lynus")
                characters[i].lines = parser.lynus.ToArray();
            else if(characters[i].name == "Brad")
                characters[i].lines = parser.brad.ToArray();
            else if(characters[i].name == "Sally Star")
                characters[i].lines = parser.sally.ToArray();
            else if(characters[i].name == "Introdutions")
                characters[i].lines = parser.sally.ToArray();
        }
    }

    public void Yes()
    {
        currentCharacter.lineNum += 1;
        currentCharacter.attractiveness += 1;
    }
    public void No()
    {
        currentCharacter.lineNum += 2;
        currentCharacter.attractiveness -= 1f;
    }

    public void NextLine()
    {
        currentCharacter.lineNum += 1;
        
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
