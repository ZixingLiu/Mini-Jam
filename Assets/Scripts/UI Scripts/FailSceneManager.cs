using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class FailSceneManager : MonoBehaviour
{
    public string Restart;
    public string MapScene;
    

    public void LoadRestart()
    {
        SceneManager.LoadScene(Restart);
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(MapScene);
    }
    
}
