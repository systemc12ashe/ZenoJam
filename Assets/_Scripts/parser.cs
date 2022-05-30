using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class parser : MonoBehaviour
{
    public TextAsset conversations;

    public string[] conversationText;
    public List<List<string>> introductions = new List<List<string>>();
    public List<List<string>> beatrice = new List<List<string>>();
    public List<List<string>> sally = new List<List<string>>();
    public List<List<string>> brad = new List<List<string>>();
    public List<List<string>> lynus = new List<List<string>>();
    
    [ContextMenu("Test Parser")]
    public void GetConversationText()
    {
        string path = AssetDatabase.GetAssetPath(conversations);
        
        using (StreamReader sr = new StreamReader(path))
        {
            var output = sr.ReadToEnd();
            conversationText = output.Split(new string[] { "***" }, System.StringSplitOptions.None);
            AddToList(beatrice, 6);
            AddToList(lynus, 20);
            AddToList(brad, 36);
            AddToList(sally, 53);
            AddToList(introductions, 0);
        }
    }

    public void AddToList(List<List<string>> currentList, int start)
    {
        List<string> interactionOne = new List<string>();
        List<string> interactionTwo = new List<string>();
        List<string> interactionThree = new List<string>();
        for (int i = start; i <= 65; i++)
        {
            if (currentList == introductions)
            {
                if (i<= 5)
                {
                    interactionOne.Add(conversationText[i]);
                }
                else
                {
                    break;
                }
            }
            if (currentList == sally)
            {
                if (i <= 57)
                {
                    interactionOne.Add(conversationText[i]);
                } else if (i <= 62)
                {
                    interactionTwo.Add(conversationText[i]);
                } else if (i <= 65)
                {
                    interactionThree.Add(conversationText[i]);
                }
                else
                {
                    break;
                }
            }
            if (currentList == brad)
            {
                if (i <= 42)
                {
                    interactionOne.Add(conversationText[i]);
                } else if (i <= 47)
                {
                    interactionTwo.Add(conversationText[i]);
                } else if (i <= 52)
                {
                    interactionThree.Add(conversationText[i]);
                }
                else
                {
                    break;
                }
            }
            if (currentList == beatrice)
            {
                if (i is >= 6 and <= 11)
                {
                    interactionOne.Add(conversationText[i]);
                } else if (i is > 11 and <= 14)
                {
                    interactionTwo.Add(conversationText[i]);
                } else if (i is > 14 and <= 19)
                {
                    interactionThree.Add(conversationText[i]);
                }
                else
                {
                    break;
                }
            }
            if (currentList == lynus)
            {
                if (i <= 24)
                {
                    interactionOne.Add(conversationText[i]);
                }
                else if (i <= 30)
                {
                    interactionTwo.Add(conversationText[i]);
                }
                else if (i <= 35)
                {
                    interactionThree.Add(conversationText[i]);
                }
                else
                {
                    break;
                }
            }
        }

        if (currentList == beatrice)
        {
            beatrice.Add(interactionOne);
            beatrice.Add(interactionTwo);
            beatrice.Add(interactionThree);
        }
        if (currentList == sally)
        {
            sally.Add(interactionOne);
            sally.Add(interactionTwo);
            sally.Add(interactionThree);
        }
        if (currentList == brad)
        {
            brad.Add(interactionOne);
            brad.Add(interactionTwo);
            brad.Add(interactionThree);
        }
        if (currentList == lynus)
        {
            lynus.Add(interactionOne);
            lynus.Add(interactionTwo);
            lynus.Add(interactionThree);
        }
        if (currentList == introductions)
        {
            introductions.Add(interactionOne);
        }
    }
}
