using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class parser : MonoBehaviour
{
    public TextAsset conversations;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string> GetConversationText(int conversationNumber)
    {
        string path = AssetDatabase.GetAssetPath(conversations);
        string[] conversationText;
        using (StreamReader sr = new StreamReader(path))
        {
            var output = sr.ReadToEnd();
            conversationText = output.Split(new string[] {"***"}, System.StringSplitOptions.None);
            string currentCharacter = conversationText[conversationNumber].Substring(0,1);
            string currentConversationText = conversationText[conversationNumber].Substring(2);
            Debug.Log(currentConversationText + currentCharacter);
            List<string> results = new List<string>();
            results.Add(currentCharacter);
            results.Add(currentConversationText);
            return (results);
        }
    }
}
