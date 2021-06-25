using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public class LockedState : BaseChipState
    {
        public override ChipsState ChipState => ChipsState.Locked;

        protected override void OnButtonPressed()
        {
            NextStateAction.Invoke(ChipsState.WaitToUnlock);
        }
    }
}
