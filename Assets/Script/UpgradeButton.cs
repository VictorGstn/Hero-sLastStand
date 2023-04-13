using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] AttackArea attackArea;
    [SerializeField] GameObject leveluppanel;
    PauseGame PauseGame;

    public void HealthUpgrade()
    {
        character.AddHealth();
        leveluppanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SpeedUpgrade()
    {
        playerMovement.AddSpeed();
        leveluppanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void DamageUpgrade()
    {
        attackArea.AddDamage();
        leveluppanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
