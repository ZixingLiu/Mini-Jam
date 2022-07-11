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
        levelManager = GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager != null)
        {
            if (levelManager.UnlockedLevel == 5)
            {
                levelManager.UnlockedLevel = 1;

            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(LoadSceneName); 
    }
    public void StartLevelOne()
    {
        levelManager.UnlockedLevel++;
        SceneManager.LoadScene(LoadSceneName);
        
    }

    public void Test()
    {
        SceneManager.LoadScene(EndingScene);
    }
    public void LoadLevelTwo()
    {
        levelManager.UnlockedLevel++;

        SceneManager.LoadScene(LoadLevel2);

    }
    public void LoadLevelThree()
    {
        levelManager.UnlockedLevel++;

        SceneManager.LoadScene(LoadLevel3);

    }
    public void LoadLevelFour()
    {
        levelManager.UnlockedLevel++;

        SceneManager.LoadScene(LoadLevel4);
        levelManager.UnlockedLevel++;

    }
    public void QuitGame()
    {
        Debug.Log("Game Quit. "); 
        Application.Quit();
    }
}
