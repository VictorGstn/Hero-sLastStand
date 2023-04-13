using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float level=1f;
    public float experience=0;
    [SerializeField] Experiencebar experiencebar;
    [SerializeField] GameObject leveluppanel;
    PauseGame pausegame;
    AudioSource audioSource;
    float TO_LEVEL_UP
    {
        get { return level*1000; }
    }
    private void Awake()
    {
        pausegame = gameObject.GetComponent<PauseGame>();
        leveluppanel.SetActive(false);
        audioSource = leveluppanel.GetComponent<AudioSource>();
    }
    void Start()
    {
        experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experiencebar.SetLevelText (level);
    }

    public void AddExperience(float amount)
    {
        experience += amount;
        CheckLevelUp();
        experiencebar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experiencebar.SetLevelText(level);
    }

    private void CheckLevelUp()
    {
       if(experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level++;
            leveluppanel.SetActive (true);
            pausegame.Pause();
            audioSource.Play();
        }
    }
}
