using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    public void Start()
    {
        //Scene scene  = SceneManager.GetActiveScene();
    }

    
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name); 

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1 || scene.name == "Level1" || scene.name == "Level2" || scene.name == "Level3" || scene.name == "Level4")
        {
            Destroy(this.gameObject);
        }
        

        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1 || scene.name == "Level1" || scene.name == "Level2" || scene.name == "Level3" || scene.name == "Level4")
        {
            Destroy(this.gameObject);
        }
    }
}
