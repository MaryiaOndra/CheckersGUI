using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedState : BaseChipState
{
    public override ChipsState ChipState => ChipsState.Unlocked;

    protected override void OnButtonPressed()
    {
        ChooseChipAction.Invoke();
        NextStateAction.Invoke(ChipsState.Choosen);
    }
}
