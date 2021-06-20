using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private string mainSceneName;
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() => PlayGame());
        quitButton.onClick.AddListener(() => QuitGame());
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }
    
    private void QuitGame() => Application.Quit();

}
