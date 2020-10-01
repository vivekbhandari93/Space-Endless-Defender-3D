﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadFirstScene", 2f);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
