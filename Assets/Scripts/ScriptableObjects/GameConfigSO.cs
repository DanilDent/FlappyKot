using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Config", menuName = "Configs/Game Config")]
public class GameConfigSO : ScriptableObject
{
    [SerializeField] private float _playerImpulse;
    [SerializeField] private List<LevelData> _levels;

    public float PlayerImpulse => _playerImpulse;
    public IReadOnlyList<LevelData> Levels => _levels;
}