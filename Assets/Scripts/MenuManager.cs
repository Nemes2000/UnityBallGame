using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExutClick()
    {
        Application.Quit();
    }
}
