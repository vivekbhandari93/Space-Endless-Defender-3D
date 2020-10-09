using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("time delay in seconds")][SerializeField] float timeDelay = 2f;
    [Tooltip("Prefab VFX on player")][SerializeField] GameObject deathVFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSquence();
        deathVFX.SetActive(true);
        Invoke("ReloadScene", timeDelay);
    }

    private void StartDeathSquence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
