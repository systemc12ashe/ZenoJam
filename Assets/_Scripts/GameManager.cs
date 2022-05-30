using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character currentCharacter;
    public Character[] characters;
    public parser parser;
    public TextScrolling textScrolling;
    public GameObject yesNoButtons;
    public GameObject nextLineButton;
    public GameObject characterSelectionScreen;
    public Image backgroundImage;
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public GameObject mantisScreen;
    public GameObject endingScreen;

    public int dayNum = 1;

    private bool intro = true;
    private bool firstLine = true;
    private bool ending = false;
    
    public void Start()
    {
         parser = GetComponent<parser>();
         parser.ConversationTextAgain();
         for (int i = 0; i < characters.Length; i++)
         {
             if (characters[i].name == "Beatrice")
                 characters[i].lines = parser.beatrice;
             else if(characters[i].name == "Lynus the Tick")
                 characters[i].lines = parser.lynus;
             else if(characters[i].name == "Brad")
                 characters[i].lines = parser.brad;
             else if(characters[i].name == "Sally Star")
                characters[i].lines = parser.sally;
             else if(characters[i].name == "Mantis")
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
        if (currentCharacter.lineNum + 2 > currentCharacter.lines[currentCharacter.interactionNum].Count - 1)
        {
            EndInteraction();
            return;
        }
        if (firstLine)
        {
            currentCharacter.lineNum += 1;
            firstLine = false;
        }
        else
        {
            currentCharacter.lineNum += 2;
        }
        currentCharacter.attractiveness += 1;
        currentCharacter.screen.GetComponentInChildren<Image>().sprite = currentCharacter.lovie;
        UpdateText();
    }
    public void No()
    {
        if (currentCharacter.lineNum + 2 > currentCharacter.lines[currentCharacter.interactionNum].Count - 1)
        {
            EndInteraction();
            return;
        }
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
                nameText.text = characters[0].name;
                characters[currentCharacter.lineNum - 1].screen.SetActive(false);
            }
            else if (currentCharacter.lineNum == 6)
            {
                characters[0].screen.SetActive(false);
                characterSelectionScreen.SetActive(true);
                nextLineButton.SetActive(false);
                intro = false;
            }
            else
            {
                characters[currentCharacter.lineNum].screen.SetActive(true);
                nameText.text = characters[currentCharacter.lineNum].name;
                characters[currentCharacter.lineNum - 1].screen.SetActive(false);
            }
        }
        UpdateText();
    }

    public void SelectCharacter(int i)
    {
        if (ending)
        {
            endingScreen.SetActive(true);
            characterSelectionScreen.SetActive(false);
            currentCharacter = characters[i];
            endingScreen.GetComponentInChildren<Image>().sprite = currentCharacter.ending;
            textScrolling.displayText(endingScreen.GetComponentInChildren<TMP_Text>(), currentCharacter.endingText);
            return;
        }
        firstLine = true;
        backgroundImage.sprite = characters[0].background;
        currentCharacter = characters[i];
        characterSelectionScreen.SetActive(false);
        currentCharacter.interactionNum += 1;
        if (characters[i].interactionNum == 2)
        {
            characterSelectionScreen.transform.GetChild(i - 1).gameObject.SetActive(false);
        }
        yesNoButtons.SetActive(true);
        StartInteraction();
    }

    public void StartInteraction()
    {
        currentCharacter.screen.SetActive(true);
        nameText.text = currentCharacter.name;
        backgroundImage.sprite = currentCharacter.background;
        UpdateText();
    }

    public void EndInteraction()
    {
        currentCharacter.screen.SetActive(false);
        nameText.text = String.Empty;
        foreach (var character in characters)
        {
            if (currentCharacter.name == character.name)
            {
                character.attractiveness = currentCharacter.attractiveness;
                character.interactionNum = currentCharacter.interactionNum;
                character.lineNum = 0;
                currentCharacter.screen.GetComponentInChildren<Image>().sprite = currentCharacter.neutral;
                break;
            }
        }
        yesNoButtons.SetActive(false);
        textScrolling.displayText(dialogueText,"Who should I talk to today?");
        backgroundImage.sprite = characters[0].background;
        characterSelectionScreen.SetActive(true);
        
        if (dayNum == 5)
        {
            List<Character> SortedList = characters.OrderByDescending(o=>o.attractiveness).ToList();
            for (int i = 1; i < characters.Length; i++)
            {
                characterSelectionScreen.transform.GetChild(i - 1).gameObject.SetActive(false);
                if ((characters[i].name == SortedList[0].name) || (characters[i].name == SortedList[1].name)) 
                {
                    characterSelectionScreen.transform.GetChild(i - 1).gameObject.SetActive(true);
                }
            }

            ending = true;
            textScrolling.displayText(dialogueText,"Wow, it's already the end of the week... Who do you want to pick?");
        }

        if (dayNum < 5)
        {
            dayNum++;
        }
    }
    
    public void UpdateText()
    {
        textScrolling.displayText(dialogueText, currentCharacter.lines[currentCharacter.interactionNum][currentCharacter.lineNum]);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}

[Serializable]
public class Character
{
    public string name;
    public float attractiveness = 0;
    public int lineNum = 0;
    public int interactionNum = -1;
    public List<List<string>> lines;
    public Sprite background;
    public Sprite neutral;
    public Sprite lovie;
    public Sprite sad;
    public Sprite ending;
    public string endingText;
    public GameObject screen;
}
