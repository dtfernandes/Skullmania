using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameConfig_SO _gameConfig;

    public void Activate(bool didWin)
    {
        _menu.SetActive(true);
        _text.text = didWin ? _gameConfig.WinMessage : _gameConfig.LooseMessage;
    }
    public void Deactivate()
    {
        _menu.SetActive(false);
    }
}
