using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => SoundController.Instance.PlayButtonClick());
    }

    private void OnDestroy()
    {
        _button?.onClick?.RemoveAllListeners();
    }
}