using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public class UnlockedState : BaseChipState
    {
        public override ChipsState ChipState => ChipsState.Unlocked;

        public override void Activate()
        {
            base.Activate();

            ChangeChipState.Invoke();
        }

        protected override void OnButtonPressed()
        {
            ChooseChipAction.Invoke();
            NextStateAction.Invoke(ChipsState.Selected);
        }
    }
}
