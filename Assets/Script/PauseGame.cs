using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void unPause() 
    { 
        Time.timeScale = 1f; 
    }
}
