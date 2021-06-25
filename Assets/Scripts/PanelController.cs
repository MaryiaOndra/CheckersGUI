using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField]
        SettingsPanel settingsPanel;

        [SerializeField]
        SelectChipPanel chooseChipPanel;

        private void Awake()
        {
            settingsPanel.ChipSprites = chooseChipPanel.GetSpriteList();

            settingsPanel.ChangePanelAction = chooseChipPanel.ActivatePanel;
            chooseChipPanel.ReturnToSettings = settingsPanel.ActivateAfterChange;
        }
    }
}
