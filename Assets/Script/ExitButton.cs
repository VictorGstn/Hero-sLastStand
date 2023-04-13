using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
