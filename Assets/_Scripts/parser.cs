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
    public List<string> introductions;
    public List<string> beatrice;
    public List<string> sally;
    public List<string> brad;
    public List<string> lynus;
    
    [ContextMenu("Test Parser")]
    public void GetConversationText()
    {
        string path = AssetDatabase.GetAssetPath(conversations);
        
        using (StreamReader sr = new StreamReader(path))
        {
            var output = sr.ReadToEnd();
            conversationText = output.Split(new string[] { "***" }, System.StringSplitOptions.None);
            AddToList(introductions, 0, 5);
            AddToList(beatrice, 6, 19);
            AddToList(lynus, 20, 33);
            AddToList(brad, 34, 50);
            AddToList(sally, 51, 63);
        }
    }

    public void AddToList(List<string> currentList,int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            currentList.Add(conversationText[i]);
        }
    }
}
