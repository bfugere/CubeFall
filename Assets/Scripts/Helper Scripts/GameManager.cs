using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void RestartGame()
    {
        TimerController.instance.EndTimer();
        Invoke("RestartAfterTime", 6f);
    }

    void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
