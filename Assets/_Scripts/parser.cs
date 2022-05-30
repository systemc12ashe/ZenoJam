using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class parser : MonoBehaviour
{
    public TextAsset conversations;

    public string[] conversationText;
    public List<List<string>> introductions = new List<List<string>>();
    public List<List<string>> beatrice = new List<List<string>>();
    public List<List<string>> sally = new List<List<string>>();
    public List<List<string>> brad = new List<List<string>>();
    public List<List<string>> lynus = new List<List<string>>();

    private void Start()
    {
        //Directory.CreateDirectory(Application.streamingAssetsPath + "/Files/");
        
    }

    private UnityWebRequest uwr = new UnityWebRequest();
    public IEnumerator Thing()
    {
        string path = "StreamingAssets/Files/Conversations.txt"; //This works because index.html is in the same folder as StreamingAssets ?
        uwr = UnityWebRequest.Get(path);
        yield return uwr.SendWebRequest();
        //ConversationTextAgain();
    }

    [ContextMenu("Test Parser")]
    
    /*public void GetConversationText()
    {
        introductions = [[conversationText[0]], [], []];
        beatrice = [[], [], []];
        brad = [[], [], []];
        sally = [[], [], []];
        lynus = [[], [], []];

    }*/

    public void ConversationTextAgain(){
        AddToList(beatrice, 6);
        AddToList(lynus, 19);
        AddToList(brad, 35);
        AddToList(sally, 52);
        AddToList(introductions, 0);
        /*using (StreamReader sr = new StreamReader(path))
        {
            var output = sr.ReadToEnd();
            conversationText = output.Split(new string[] { "\n***\n" }, System.StringSplitOptions.None);
            
        }*/
    }

    public void AddToList(List<List<string>> currentList, int start)
    {
        List<string> interactionOne = new List<string>();
        List<string> interactionTwo = new List<string>();
        List<string> interactionThree = new List<string>();
        for (int i = start; i <= 64; i++)
        {
            if (currentList == introductions)
            {
                if (i <= 5)
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
                if (i <= 56)
                {
                    interactionOne.Add(conversationText[i]);
                } else if (i <= 61)
                {
                    interactionTwo.Add(conversationText[i]);
                } else if (i <= 64)
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
                if (i <= 41)
                {
                    interactionOne.Add(conversationText[i]);
                } else if (i <= 46)
                {
                    interactionTwo.Add(conversationText[i]);
                } else if (i <= 51)
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
                if (i is >= 6 and <= 10)
                {
                    interactionOne.Add(conversationText[i]);
                } else if (i is > 10 and <= 13)
                {
                    interactionTwo.Add(conversationText[i]);
                } else if (i is > 13 and <= 18)
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
                if (i <= 23)
                {
                    interactionOne.Add(conversationText[i]);
                }
                else if (i <= 29)
                {
                    interactionTwo.Add(conversationText[i]);
                }
                else if (i <= 34)
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
