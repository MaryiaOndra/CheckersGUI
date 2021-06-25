using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsPanel : BasePanel
{
    [SerializeField]
    List<BaseChipBtn> chipBtns;

    //const int PLAYER_CHIP_INDEX = 0;
    //const int ENEMY_CHIP_INDEX = 1;

    #region "Settings"
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
    [Space]

    List<BaseSwitcher> baseSwitchers;
    BaseSwitcher musicSwitcher;
    BaseSwitcher soundSwitcher;
    BaseSwitcher autoDiceRollingSwitcher;
    #endregion

    int activeChipIndex;
    public List<Sprite> ChipSprites {get;set;}

    public Action<int> ChangePanelAction;
    public Action GetSpriteAction; 

    protected override void Awake()
    {
        base.Awake();

        baseSwitchers = new List<BaseSwitcher>(GetComponentsInChildren<BaseSwitcher>());
        musicSwitcher = baseSwitchers.Find(_f => _f.ParamName == PrefsKeys.Music_);
        soundSwitcher = baseSwitchers.Find(_f => _f.ParamName == PrefsKeys.Sound_);
        autoDiceRollingSwitcher = baseSwitchers.Find(_f => _f.ParamName == PrefsKeys.DiceState_);

        chipBtns.ForEach(_ch => _ch.OnClickBtnAction = GetBtnAction);
    }

    public override void ActivatePanel()
    {
        Debug.Log("ActivatePanel");

        for (int i = 0; i < chipBtns.Count; i++)
        {            
            var _index = chipBtns[i].SetChipButtonIndex();
            Debug.Log("chipBtns[i].Index;" + _index);

            var _sprite = ChipSprites[_index];
            chipBtns[i].SetSprite(_sprite);
        }       
        
        base.ActivatePanel();
    }

    public void ResetSettingsData()
    {
        baseSwitchers.ForEach(_sw => _sw.ResetAction.Invoke(true));
        chipBtns.ForEach(_ch => _ch.ResetChipIndexes());
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

    void GetBtnAction(BaseChipBtn _baseChipBtn) 
    {
        activeChipIndex = _baseChipBtn.Index;
    }

    //public void ChooseEnemyChip() 
    //{
    //    var _sprite = EnemyChipImg.sprite;
    //    activeChipIndex = ENEMY_CHIP_INDEX;
    //    ChangePanelAction.Invoke(activeChipIndex);
    //    DiactivatePanel();      
    //}

    //public void ChoosePlayerChip() 
    //{
    //    var _sprite = PlayerChipImg.sprite;
    //    activeChipIndex = PLAYER_CHIP_INDEX;
    //    ChangePanelAction.Invoke(activeChipIndex);
    //    DiactivatePanel();
    //}



    //public void ActivatePanel(Sprite _sprite) 
    //{
    //    base.ActivatePanel();
    //    SetSprite(_sprite);
    //}
}
