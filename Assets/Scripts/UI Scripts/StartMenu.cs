using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string LoadSceneName;
    public string EndingScene; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(LoadSceneName); 
    }
    public void StartLevelOne()
    {
        SceneManager.LoadScene(LoadSceneName);
    }
    public void Test()
    {
        SceneManager.LoadScene(EndingScene);
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit. "); 
        Application.Quit();
    }
}
