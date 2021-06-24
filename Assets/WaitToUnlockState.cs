using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToUnlockState : BaseChipState
{
    public override ChipsState ChipState => ChipsState.WaitToUnlock;

    protected override void OnButtonPressed()
    {
        throw new System.NotImplementedException();
    }
}
