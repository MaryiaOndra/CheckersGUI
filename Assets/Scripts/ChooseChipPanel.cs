using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChipPanel : BasePanel
{
    [SerializeField]
    ChipContainer chipContainer;

    public Sprite SpriteToChange { get; private set; }

    public void ActivatePanel( int _index, Sprite _sprite)
    {
        base.ActivatePanel();
                
        ResetShipsState(chipContainer.ChipsList, _index);
        SpriteToChange = _sprite;
        chipContainer.ChipsList.ForEach(_ch => _ch.OnChosen = OnChoosenChip);
    }

    void OnChoosenChip(Chip _chip) 
    {
        SpriteToChange = _chip.CurrentState.ChipSprite;

        FromChoosenToUnlock();
    }

    public void FromChoosenToUnlock() 
    {
        var _chip = chipContainer.ChipsList.Find(_ch => _ch.CurrentState.ChipState == ChipsState.Choosen);

        if (_chip)
            _chip.OnNextStateRequest(ChipsState.Unlocked);
    }

    public void ResetShipsState(List<Chip> _chips, int _index)
    {
        for (int i = 0; i < _chips.Count; i++)
        {
            _chips[i].ResetState(i, _index);
        }
    }



}

public enum ChipsState
{
    Locked,
    Unlocked,
    Choosen,
    WaitToUnlock
}

