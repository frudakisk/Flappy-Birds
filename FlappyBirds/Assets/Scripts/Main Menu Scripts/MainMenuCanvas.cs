using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuCanvas : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        highscoreText.text = $"Highscore\n{DataController.Instance.highscore}";
    }

    public void Quit()
    {
        DataController.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
