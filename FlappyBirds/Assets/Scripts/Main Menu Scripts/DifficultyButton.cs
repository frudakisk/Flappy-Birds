using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    public float difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayWithDifficulty);
    }

    /// <summary>
    /// Sets the difficulty of the game and opens the gameplay scene
    /// </summary>
    private void PlayWithDifficulty()
    {
        GameManager.spawnRate = difficulty;
        SceneManager.LoadScene(1);
    }
}
