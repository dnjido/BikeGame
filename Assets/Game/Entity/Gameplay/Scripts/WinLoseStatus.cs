using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetGameStatus
{
    public void SetStatus(EndGameStatus status);
}

public class WinLoseStatus : MonoBehaviour, ISetGameStatus
{
    [SerializeField]private GameObject _endGameUI;
    private bool _statusIsSet;

    public void SetStatus(EndGameStatus status)
    {
        if(_statusIsSet) return;

        _statusIsSet = true;
        GameStatusStorage.SetStatus(status);
        GetComponent<CreateUI>().Create(_endGameUI);
    }
}

public enum EndGameStatus
{
    Win = 0,
    Lose = 1
}