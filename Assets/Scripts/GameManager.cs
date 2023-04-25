using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject restartPanel;
    [SerializeField]
    private TextMeshProUGUI scoreNumber;
    [SerializeField]
    private TextMeshProUGUI abilityText;
    [SerializeField]
    private GameObject pausePanel;
    private bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        restartPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void SetPlayPanel(int wave)
    {
        scoreNumber.text = wave.ToString();
    }

    public void EnableAbilityText(string text)
    {
        abilityText.text = text;
    }

    public void DisableAbilityText()
    {
        abilityText.text = "";
    }
}
