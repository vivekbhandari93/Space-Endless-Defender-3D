using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    Text displayScores;
    int countScores = 0;

    private void Start()
    {
        displayScores = GetComponent<Text>();
        displayScores.text = countScores.ToString();
    }

    public void AddScores()
    {
        countScores += 10;
        displayScores.text = countScores.ToString();
    }
}
