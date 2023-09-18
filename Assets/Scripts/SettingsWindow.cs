using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoSingleton<SettingsWindow>
{
    [SerializeField] private Button _diffLeftArrowButton;
    [SerializeField] private Button _diffRightArrowButton;
    [SerializeField] private TextMeshProUGUI _diffText;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Button _backButton;

    public int Difficulty
    {
        get => AppController.Instance.CurrentDiffIndex;
        private set => _diffText.text = AppController.Instance.GameConfig.Levels[value].Name;
    }

    public float SoundVolume
    {
        get => _soundSlider.value;
    }

    private void Start()
    {
        UpdateChooseDiffControls();
        _diffLeftArrowButton.onClick.AddListener(DecreaseDifficulty);
        _diffRightArrowButton.onClick.AddListener(IncreaseDifficulty);
        _backButton.onClick.AddListener(GoBack);

        _soundSlider.onValueChanged.AddListener((volume) =>
        {
            SoundController.Instance.Volume = volume;
        });

        gameObject.SetActive(false);
    }

    private void IncreaseDifficulty()
    {
        AppController.Instance.CurrentDiffIndex++;
        UpdateChooseDiffControls();
    }

    private void DecreaseDifficulty()
    {
        AppController.Instance.CurrentDiffIndex--;
        UpdateChooseDiffControls();
    }

    private void UpdateChooseDiffControls()
    {
        int currentDiffIndex = AppController.Instance.CurrentDiffIndex;

        _diffRightArrowButton.interactable = currentDiffIndex < AppController.Instance.GameConfig.Levels.Count - 1;
        _diffLeftArrowButton.interactable = currentDiffIndex > 0;
        _diffText.text = AppController.Instance.GameConfig.Levels[currentDiffIndex].Name;
    }

    private void GoBack()
    {
        MainMenuWindow.Instance.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    protected override void OnDestroy()
    {
        _diffLeftArrowButton.onClick.RemoveAllListeners();
        _diffRightArrowButton.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();

        base.OnDestroy();
    }
}