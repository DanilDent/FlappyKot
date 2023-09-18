using UnityEngine;

public class SoundController : MonoSingleton<SoundController>
{
    [SerializeField] private AudioSource _audio;

    [SerializeField] private AudioClip _mainTheme;
    [SerializeField] private AudioClip _buttonClick;
    [SerializeField] private AudioClip _scoreAdd;
    [SerializeField] private AudioClip _failSound;

    private float _volume = 0.5f;

    public float Volume
    {
        get => _volume;
        set
        {
            if (!(_volume >= 0 && _volume <= 1f))
            {
                return;
            }
            _volume = value;
            _audio.volume = _volume;
        }
    }

    public void PlayMusic(bool enabled)
    {
        _audio.clip = _mainTheme;
        if (enabled)
        {
            _audio.loop = true;
            _audio.Play();
        }
        else
        {
            _audio.Stop();
        }
    }

    public void PlayButtonClick()
    {
        _audio.PlayOneShot(_buttonClick);
    }

    public void PlayScoreAdd()
    {
        _audio.PlayOneShot(_scoreAdd);
    }

    public void PlayFail()
    {
        _audio.PlayOneShot(_failSound);
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Volume = SettingsWindow.Instance.SoundVolume;
    }
}
