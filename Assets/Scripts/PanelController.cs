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
        settingsPanel.ChangePanelAction = chooseChipPanel.ActivatePanel;
    }
}
