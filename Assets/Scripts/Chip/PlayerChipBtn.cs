using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public class PlayerChipBtn : BaseChipBtn
    {
        const int PLAYER_CHIP_INDEX = 0;

        protected override string PrefsKey => PrefsKeys.PlayerChipIndx_;

        protected override int DefoultIndx => PLAYER_CHIP_INDEX;
    }
}
