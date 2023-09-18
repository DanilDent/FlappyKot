using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public GameConfigSO GameConfig => AppController.Instance.GameConfig;
    public LevelData CurrentLevel => AppController.Instance.GameConfig.Levels[AppController.Instance.CurrentDiffIndex];

    [SerializeField] private float _spawnAtPositionX = 20f;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _wallsContainer;
    [SerializeField] private float _minWallPosY = -5.5f;
    [SerializeField] private float _maxWallPosY = 5.5f;

    private float _timer;

    private void Start()
    {
        SoundController.Instance.PlayMusic(true);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0f)
        {
            _timer = Random.Range(CurrentLevel.MinWallSpawnFrequency, CurrentLevel.MaxWallSpawnFrequency);
            GenerateNextWall(Random.Range(CurrentLevel.MinEntrySize, CurrentLevel.MaxEntrySize), Random.Range(_minWallPosY, _maxWallPosY));
        }
    }

    private void GenerateNextWall(float entrySize, float posY)
    {
        GameObject wall = Instantiate(_wallPrefab, _wallsContainer.transform);
        wall.gameObject.SetActive(false);
        GameObject topWall = wall.transform.GetChild(0).gameObject;
        GameObject bottomWall = wall.transform.GetChild(1).gameObject;

        topWall.transform.localPosition = Vector3.up * entrySize / 2f;
        bottomWall.transform.localPosition = -Vector3.up * entrySize / 2f;

        wall.transform.position = new Vector3(_spawnAtPositionX, posY, 0f);

        wall.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        SoundController.Instance.PlayMusic(false);
        SoundController.Instance.PlayFail();
        SceneManager.LoadScene(0);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
