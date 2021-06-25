using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public class ChoosenState : BaseChipState
    {
        public override ChipsState ChipState => ChipsState.Selected;

        protected override void OnButtonPressed()
        {
            NextStateAction.Invoke(ChipsState.Selected);
        }
    }
}
