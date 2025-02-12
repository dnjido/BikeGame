using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FinishTrigger : MonoBehaviour
{
    private ISetGameStatus _gameStatus;

    [Inject]
    private void Init([InjectOptional]ISetGameStatus gameStatus)
    {
        _gameStatus = gameStatus;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        _gameStatus.SetStatus(EndGameStatus.Win);
    }
}
