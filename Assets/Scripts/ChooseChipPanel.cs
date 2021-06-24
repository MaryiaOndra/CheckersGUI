using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChipPanel : BasePanel
{
    [SerializeField]
    ChipContainer chipContent;

    private void Start()
    {
        chipContent.ShowChips();
    }

    public void Setup()
    {
        if (GetChipsState(0) == ChipsState.Locked)
        {
            SetChipsState(0, ChipsState.Unlocked);
            ;
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
}

public enum ChipsState
{
    Locked,
    Unlocked,
    Choosen,
    WaitToUnlock
}

