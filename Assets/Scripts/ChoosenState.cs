using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosenState : BaseChipState
{
    public override ChipsState ChipState => ChipsState.Choosen;

    protected override void OnButtonPressed()
    {
        NextStateAction.Invoke(ChipsState.Choosen);
    }
}
