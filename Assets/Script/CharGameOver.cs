using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGameOver : MonoBehaviour
{
    public GameObject gameoverpanel;
    PauseGame pausegame;
    private void Awake()
    {
        gameoverpanel.SetActive(false);
    }
    public void GameOver()
    {
        Debug.Log("game");
        pausegame.Pause();
        gameoverpanel.SetActive(true);
    }
}
