using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;

    bool isPaused = false;
    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!isPaused)
            {
                PauseGame();
            } else if (isPaused)
            {
                ContinueGame();
            }
        }
    }

    public void ContinueGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void PauseGame()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
