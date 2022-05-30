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
        text.text = string.Empty;
        char[] characters = seperateString(inputText);
        StartCoroutine(displayCharacter(characters, text));
        
    }

    public IEnumerator displayCharacter(char[] characterArray, TMP_Text text)
    {
        for (int i = 2; i < characterArray.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            text.text += characterArray[i];
        }
        
    }

}
