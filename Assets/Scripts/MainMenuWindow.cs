using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuWindow : MonoSingleton<MainMenuWindow>
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _playButton.onClick.AddListener(StartGame);
        _settingsButton.onClick.AddListener(GoToSettings);
        _exitButton.onClick.AddListener(Exit);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void GoToSettings()
    {
        SettingsWindow.Instance.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Exit()
    {
        Application.Quit();
    }
}