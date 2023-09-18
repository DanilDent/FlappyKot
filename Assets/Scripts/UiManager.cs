using TMPro;
using UnityEngine;

public class UiManager : MonoSingleton<UiManager>
{
    [SerializeField] private TMP_Text _scoreText;

    public int Score
    {
        get => int.Parse(_scoreText.text.Substring(_scoreText.text.IndexOf(":") + 1));
        set => _scoreText.text = $"Score: {value}";
    }
}