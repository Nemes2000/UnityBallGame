using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void OnRestartClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene(1);
    }
}
