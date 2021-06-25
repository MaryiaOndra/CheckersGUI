using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    const int UNLOCK_AMOUNT = 2;

    List<BaseChipState> chipStates;
    BaseChipState currentState;
    Button chipBtn;

    public int ChipIndex { get; private set; }
    public BaseChipState CurrentState => currentState;

    public Action<Chip> OnChosen;

    public void Setup(Sprite _chipSprite, int _index)
    {
        chipStates = new List<BaseChipState>(GetComponentsInChildren<BaseChipState>(true));
        chipBtn = GetComponent<Button>();
        ChipIndex = _index;

        chipStates.ForEach(_state =>
        {
            _state.Setup(_chipSprite, chipBtn, _index);
            _state.NextStateAction = OnNextStateRequest;
            _state.ChooseChipAction = OnChooseAction;            
        });

        var _chipState = GetChipsState(_index);

        currentState = chipStates.Find(_state => _state.ChipState == _chipState);
        currentState.Activate();
    }

    public void OnChooseAction()
    {
        SetChipsState(ChipIndex, currentState.ChipState);
        OnChosen.Invoke(this);
    }

    public void OnNextStateRequest(ChipsState _state)
    {
        currentState.Diactivate();
        currentState = chipStates.Find(_s => _s.ChipState == _state);
        currentState.Activate();
    }

    public void ResetState(int _index, int _indexToCheck) 
    {
        if (_index >= UNLOCK_AMOUNT)
            currentState.NextStateAction.Invoke(ChipsState.Locked);
        else
            currentState.NextStateAction.Invoke(ChipsState.Unlocked);

        if (_indexToCheck == ChipIndex)
            currentState.NextStateAction.Invoke(ChipsState.Choosen);
    }

    public ChipsState GetChipsState(int _order)
    {
        int _levelIntState = AppPrefs.GetInt(PrefsKeys.Chip_ + _order);
        return (ChipsState)_levelIntState;
    }

    public void SetChipsState(int _order, ChipsState _chipState)
    {
        AppPrefs.SetInt(PrefsKeys.Chip_ + _order, (int)_chipState);
    }
}
