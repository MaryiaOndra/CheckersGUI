using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedState : BaseChipState
{
    public override ChipsState ChipState => ChipsState.Locked;

    protected override void OnButtonPressed()
    {
        throw new System.NotImplementedException();
    }
}
