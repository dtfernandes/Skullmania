using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new GameConfig_SO", menuName = "ScriptableObjects/GameConfig_SO", order = 0)]
public class GameConfig_SO : ScriptableObject
{
    [Header("seconds")]
    [SerializeField] private float _gameSurvivalTime;
    [Header("Game texts")]
    [TextArea][SerializeField] private string _winMessage;
    [TextArea][SerializeField] private string _looseMessage;

    public float SurvivalTime => _gameSurvivalTime;
    public string WinMessage => _winMessage;
    public string LooseMessage => _looseMessage;
}
