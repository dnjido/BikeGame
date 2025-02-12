using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSatusUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    // Start is called before the first frame update
    void Start() => Create();

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Create()
    {
        EndGameStatus status = GameStatusStorage.gameStatus;

        if (status == EndGameStatus.Win) _label.text = "You Win";
        if (status == EndGameStatus.Lose) _label.text = "You Lose";
    }
}
