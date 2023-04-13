using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausepanel;
    PauseGame pausegame;
    // Update is called once per frame
    private void Awake()
    {
        pausegame = GetComponent<PauseGame>();
        pausepanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausepanel.activeInHierarchy == false)
            {
                pausegame.Pause();
                openPausepanel();
            }
            else
            {
                pausegame.unPause();
                closePausepanel();  
            }
        }
    }

    public void closePausepanel()
    {
        pausepanel.SetActive(false);
    }
    public void openPausepanel()
    {
        pausepanel.SetActive(true);
    }
}
