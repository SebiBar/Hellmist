using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
In the future we will not start a run from the main menu.
 */
public class SceneTransitioner : Singleton<SceneTransitioner>
{
    public void LoadSceneNormalRun()
    {
        SceneManager.LoadScene("LevelNormal");
    }

    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
