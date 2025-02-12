using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PawnCollisionDetect : MonoBehaviour
{
    private ISetGameStatus _gameStatus;

    [Inject]
    private void Init(ISetGameStatus gameStatus)
    {
        _gameStatus = gameStatus;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "MapObject") return;

        GetComponent<Rigidbody>().isKinematic = false;
        _gameStatus.SetStatus(EndGameStatus.Lose);
    }
}
