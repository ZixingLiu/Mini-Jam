using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText; 
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialog dialog)
    {
        //Debug.Log("Start Conversation");
        nameText.text = dialog.name; 
        sentences.Clear(); 
        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(); 
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return; 
        }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence; 
    }
    void EndDialog()
    {
        Debug.Log("End og the conversation"); 
    }
}
