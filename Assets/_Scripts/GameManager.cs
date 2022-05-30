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
    public GameObject characterSelectionScreen;
    public Image backgroundImage;
    public TMP_Text dialogueText;
    public GameObject mantisScreen;

    private bool intro = true;
    
    public void Start()
    {
        parser = GetComponent<parser>();
        parser.GetConversationText();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].name == "Beatrice")
                characters[i].lines = parser.beatrice;
            else if(characters[i].name == "Lynus")
                characters[i].lines = parser.lynus;
            else if(characters[i].name == "Brad")
                characters[i].lines = parser.brad;
            else if(characters[i].name == "Sally Star")
                characters[i].lines = parser.sally;
            else if(characters[i].name == "Introductions")
                characters[i].lines = parser.introductions;
        }

        currentCharacter = characters[0];
        UpdateText();
        //characterSelectionScreen.SetActive(false);
        backgroundImage.sprite = characters[0].background;
        mantisScreen.SetActive(true);
    }

    public void Yes()
    {
        currentCharacter.lineNum += 1;
        currentCharacter.attractiveness += 1;
        currentCharacter.screen.GetComponentInChildren<Image>().sprite = currentCharacter.lovie;
        UpdateText();
    }
    public void No()
    {
        currentCharacter.lineNum += 2;
        currentCharacter.attractiveness -= 1f;
        currentCharacter.screen.GetComponentInChildren<Image>().sprite = currentCharacter.sad;
        UpdateText();
    }

    public void NextLine()
    {
        currentCharacter.lineNum += 1;
        if (intro)
        {
            
            
            if (currentCharacter.lineNum == 5)
            {
                characters[0].screen.SetActive(true);
                characters[currentCharacter.lineNum - 1].screen.SetActive(false);
            }
            else if (currentCharacter.lineNum == 6)
            {
                characters[0].screen.SetActive(false);
                characterSelectionScreen.SetActive(true);
            }
            else
            {
                characters[currentCharacter.lineNum].screen.SetActive(true);
                characters[currentCharacter.lineNum - 1].screen.SetActive(false);
            }
        }
        UpdateText();
    }

    public void SelectCharacter(int i)
    {
        backgroundImage.sprite = characters[0].background;
        currentCharacter = characters[i];
        characterSelectionScreen.SetActive(false);
        StartInteraction();
    }

    public void StartInteraction()
    {
        currentCharacter.screen.SetActive(true);
        backgroundImage.sprite = currentCharacter.background;
        UpdateText();
    }

    public void UpdateText()
    {
        textScrolling.displayText(dialogueText, currentCharacter.lines[currentCharacter.interactionNum][currentCharacter.lineNum]);
    }
}

[Serializable]
public class Character
{
    public string name;
    public float attractiveness = 0;
    public int lineNum = 0;
    public int interactionNum = 0;
    public List<List<string>> lines;
    public Sprite background;
    public Sprite neutral;
    public Sprite lovie;
    public Sprite sad;
    public GameObject screen;
}
