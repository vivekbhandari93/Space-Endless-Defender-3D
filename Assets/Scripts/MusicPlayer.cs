using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GetComponent<AudioSource>().Play();
        Invoke("LoadFirstScene", 2f);        
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
