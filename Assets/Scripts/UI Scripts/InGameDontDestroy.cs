using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameDontDestroy : MonoBehaviour
{


    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");

        if (objs.Length > 1 || scene.name == "Fail")
        {
            Destroy(this.gameObject);
        }
    }
}
