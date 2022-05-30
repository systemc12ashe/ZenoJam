using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextScrolling : MonoBehaviour
{
    public char[] seperateString(string inputText)
    {
        char[] characters = inputText.ToCharArray();
        return(characters);
    }

    public void displayText(TMP_Text text, string inputText)
    {
        StopAllCoroutines();
        text.text = string.Empty;
        char[] characters = seperateString(inputText);
        StartCoroutine(displayCharacter(characters, text));
        
    }

    public IEnumerator displayCharacter(char[] characterArray, TMP_Text text)
    {
        foreach (var character in characterArray)
        {
            yield return new WaitForSeconds(0.015f);
            text.text += character;
        }

    }

}
