using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsPanel : BasePanel
{
    [Header("Switches")]
    [Tooltip("Switch on control settings for control switches from inspector")]
    [SerializeField]
    bool controlSettings = false;
    [Space]
    [SerializeField]
    bool music;   
    [SerializeField]
    bool sound;
    [SerializeField]
    bool autoDiceRolling;   

    List<BaseSwitcher> baseSwitchers;
    BaseSwitcher musicSwitcher;   
    BaseSwitcher soundSwitcher;   
    BaseSwitcher autoDiceRollingSwitcher;

    [SerializeField]
    public Action<int> ChangePanelAction;

    protected override void Awake()
    {
        base.Awake();

        baseSwitchers = new List<BaseSwitcher>(GetComponentsInChildren<BaseSwitcher>());
        musicSwitcher = baseSwitchers.Find(_f => _f.ParamName == PrefsKeys.Music_);
        soundSwitcher = baseSwitchers.Find(_f => _f.ParamName == PrefsKeys.Sound_);
        autoDiceRollingSwitcher = baseSwitchers.Find(_f => _f.ParamName == PrefsKeys.DiceState_);

    }
    public void ResetSettingsData()
    {
        baseSwitchers.ForEach(_sw => _sw.ResetAction.Invoke(true));
    }

    private void Update()
    {
        if (controlSettings)
        {
            musicSwitcher.SwitcherState = music;
            soundSwitcher.SwitcherState = sound;
            autoDiceRollingSwitcher.SwitcherState = autoDiceRolling;
        }
    }

    public void ChooseChip(int _index) 
    {
        ChangePanelAction.Invoke(_index );
        DiactivatePanel();      
    }
}
