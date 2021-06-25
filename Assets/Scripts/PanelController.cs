using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    SettingsPanel settingsPanel;

    [SerializeField]
    ChooseChipPanel chooseChipPanel;

    private void Awake()
    {
        settingsPanel.ChipSprites = chooseChipPanel.GetSpriteList();

        settingsPanel.ChangePanelAction = chooseChipPanel.ActivatePanel;
        //chooseChipPanel.ReturnToSettings = settingsPanel.ActivatePanel;
    }
}
