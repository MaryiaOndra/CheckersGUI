using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    List<BaseChipState> chipStates;
    BaseChipState currentState;
    int chipIndex;
    Button chipBtn;


    public void Setup(Sprite _chipSprite, int _index)
    {
        chipStates = new List<BaseChipState>(GetComponentsInChildren<BaseChipState>(true));
        chipBtn = GetComponent<Button>();
        Debug.Log("Setup _index " + _index);
        chipIndex = _index;

        chipStates.ForEach(_state =>
        {
            _state.Setup(_chipSprite, chipBtn);
            _state.NextStateAction = OnNextStateRequest;
        });

        currentState = chipStates.Find(_state => _state.ChipState == ChipsState.WaitToUnlock);
        currentState.Activate();
    }

    public void OnNextStateRequest(ChipsState _state)
    {
        currentState.Diactivate();
        currentState = chipStates.Find(_s => _s.ChipState == _state);
        currentState.Activate();
    }

    public void ResetState(int _index, int _indexToCheck) 
    {
        if (_index >= 2)
            currentState.NextStateAction.Invoke(ChipsState.Locked);
        else
            currentState.NextStateAction.Invoke(ChipsState.Unlocked);

        if (_indexToCheck == chipIndex)
            currentState.NextStateAction.Invoke(ChipsState.Choosen);
    }
}
