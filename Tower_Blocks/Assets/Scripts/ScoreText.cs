using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeGenerated += GameManager_OnCubeGenerated;
    }

    private void onDestroy()
    {
        GameManager.OnCubeGenerated -= GameManager_OnCubeGenerated;
    }

   private void GameManager_OnCubeGenerated()
    {
        score++;
        text.text = "Score: " + score;
    }
}
