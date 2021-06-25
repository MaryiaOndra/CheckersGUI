using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public class EnemyChipBtn : BaseChipBtn
    {
        const int ENEMY_CHIP_INDEX = 1;

        protected override string PrefsKey => PrefsKeys.EnemyChipIndx_;

        protected override int DefoultIndx => ENEMY_CHIP_INDEX;
    }
}
