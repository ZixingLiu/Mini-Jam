using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int UnlockedLevel = 1;
    public Button[] Buttons;

    void Start()
    {
        UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        //unlocked level cannot be clicked
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].interactable = false;

        //clickable unlocked buttons
        for (int i = 0; i < UnlockedLevel; i++)
            Buttons[i].interactable = true;
    }

    private void Update()
    {
        if (UnlockedLevel == 5)
        {
            UnlockedLevel = 1;

        }
    }

    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }

    public void Hook()
    {
        Destroy(GameObject.Find("Hook"));
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("UnlockedLevel", UnlockedLevel);
    }
}
