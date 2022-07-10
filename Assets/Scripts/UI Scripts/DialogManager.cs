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

    public GameObject dialogBar;
    public GameObject continueButton;
    public GameObject triggerButton; 
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
    public void EndDialog()
    {
        Debug.Log("End og the conversation"); 
    }

    public void TurnOnDialogBar()
    {
        dialogBar.SetActive(true); 
        continueButton.SetActive(true);
        triggerButton.SetActive(false);
    }
}
