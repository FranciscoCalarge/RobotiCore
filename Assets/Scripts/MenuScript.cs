using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
