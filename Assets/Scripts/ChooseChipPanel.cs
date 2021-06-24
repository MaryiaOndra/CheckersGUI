using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChipPanel : BasePanel
{
    [SerializeField]
    ChipContainer chipContainer;

    public Sprite SpriteToChange { get; private set; }

    public void ActivatePanel(int _index)
    {
        base.ActivatePanel();

        chipContainer.InstantiateChips();
        ResetShipsState(chipContainer.ChipsList, _index);
        SpriteToChange = chipContainer.GetSprite(_index);
    }

    public void Setup()
    {
        if (GetChipsState(0) == ChipsState.Locked)
        {
            SetChipsState(0, ChipsState.Unlocked);
        }
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

