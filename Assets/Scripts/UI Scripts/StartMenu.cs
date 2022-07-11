using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string LoadSceneName;
    public string LoadLevel2; 
    public string LoadLevel3;
    public string LoadLevel4;
    public string EndingScene; 

    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.UnlockedLevel == 4)
        {
            levelManager.UnlockedLevel = 0;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(LoadSceneName); 
    }
    public void StartLevelOne()
    {
        SceneManager.LoadScene(LoadSceneName);
        levelManager.UnlockedLevel++;
    }

    public void Test()
    {
        SceneManager.LoadScene(EndingScene);
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(LoadLevel2);
        levelManager.UnlockedLevel++;

    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene(LoadLevel3);
        levelManager.UnlockedLevel++;

    }
    public void LoadLevelFour()
    {
        SceneManager.LoadScene(LoadLevel4);
        levelManager.UnlockedLevel++;

    }
    public void QuitGame()
    {
        Debug.Log("Game Quit. "); 
        Application.Quit();
    }
}
