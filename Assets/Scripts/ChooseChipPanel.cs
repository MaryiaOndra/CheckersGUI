using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChipPanel : BasePanel
{
    [SerializeField]
    ChipContainer chipContainer;

    [SerializeField]
    ChipStatesPanel chipStates;

    int newChipIndex;
    public Sprite SpriteToChange { get; private set; }

    public Action<int> ReturnToSettings;
    public Action ChangeSpriteAction;

    internal List<Sprite> GetSpriteList()
    {
        return chipContainer.ChipsSprites;
    }

    public void ActivatePanel( int _index)
    {
        base.ActivatePanel();

        chipContainer.ChipsList[_index].OnNextStateRequest(ChipsState.Choosen);
  
        // chosenChipIndex = _index;

        chipContainer.ChipsList.ForEach(_ch => _ch.OnChosen = OnChoosenChip);
    }

    void OnChoosenChip(Chip _chip) 
    {
        SpriteToChange = _chip.CurrentState.ChipSprite;
        FromChoosenToUnlock();
        newChipIndex = _chip.ChipIndex;
    }

    public void FromChoosenToUnlock() 
    {
        var _chip = chipContainer.ChipsList.Find(_ch => _ch.CurrentState.ChipState == ChipsState.Choosen);

        if (_chip)
            _chip.OnNextStateRequest(ChipsState.Unlocked);
    }

    public void ResetChipsState(List<Chip> _chips, int _index)
    {
        for (int i = 0; i < _chips.Count; i++)
        {
            _chips[i].ResetState(i, _index);
        }
    }    

    public override void DiactivatePanel()
    {
        chipContainer.ChipsList[newChipIndex].OnNextStateRequest(ChipsState.Unlocked);
        ReturnToSettings.Invoke(newChipIndex);

        base.DiactivatePanel();
    }


}

public enum ChipsState
{
    Locked,
    Unlocked,
    Choosen,
    WaitToUnlock
}

