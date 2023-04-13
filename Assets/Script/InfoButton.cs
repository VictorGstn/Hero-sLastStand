using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    [SerializeField] GameObject infopanel;
    private void Awake()
    {
        infopanel.SetActive(false);
    }
    public void ShowInfoPanel()
    {
        infopanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            infopanel.SetActive(false);
        }
    }
}
