using UnityEngine;

public class AppController : MonoSingleton<AppController>
{
    public GameConfigSO GameConfig => _gameConfig;
    public int CurrentDiffIndex
    {
        get => _currentDiffIndex;
        set => _currentDiffIndex = value;
    }

    [SerializeField] private GameConfigSO _gameConfig;

    private int _currentDiffIndex;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.Landscape;
    }

}