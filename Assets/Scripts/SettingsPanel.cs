using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CheckersGUi
{
    public class SettingsPanel : BasePanel
    {
        [SerializeField]
        List<BaseChipBtn> chipBtns;

        List<BaseSwitcher> baseSwitchers;

        int activeChipIndex;
        public List<Sprite> ChipSprites { get; set; }

        public Action<int> ChangePanelAction;

        [SerializeField]
        UnityEvent<bool> SoundSettings;
        [SerializeField]
        UnityEvent<bool> MusicSettings;
        [SerializeField]
        UnityEvent<bool> AutoRollDiceSettings;
        [SerializeField]
        UnityEvent<bool> ChipLightSettings;

        protected override void Awake()
        {
            base.Awake();

            baseSwitchers = new List<BaseSwitcher>(GetComponentsInChildren<BaseSwitcher>());
            baseSwitchers.ForEach(_sw => _sw.SwitchSettingsAction = OnSettingsAction);
        }

        public void OnSettingsAction(bool _bool, string _s)
        {
            if (_s == PrefsKeys.Sound_)
                SoundSettings.Invoke(_bool);
            else if (_s == PrefsKeys.Music_)
                MusicSettings.Invoke(_bool);
            else if (_s == PrefsKeys.Light_)
                ChipLightSettings.Invoke(_bool);
            else if (_s == PrefsKeys.AutoDiceRoll_)
                AutoRollDiceSettings.Invoke(_bool); ;
        }


        public override void ActivatePanel()
        {
            for (int i = 0; i < chipBtns.Count; i++)
            {
                var _index = chipBtns[i].Index;
                var _sprite = ChipSprites[_index];
                chipBtns[i].SetSprite(_sprite);
            }

            base.ActivatePanel();
        }

        public void ResetSettingsData()
        {
            baseSwitchers = new List<BaseSwitcher>(GetComponentsInChildren<BaseSwitcher>());
            baseSwitchers.ForEach(_sw => _sw.ResetAction.Invoke(true));

            for (int i = 0; i < chipBtns.Count; i++)
            {
                chipBtns[i].ResetChipIndex();
                var _sprite = ChipSprites[chipBtns[i].Index];
                chipBtns[i].SetSprite(_sprite);
            }
        }

        public void GetBtnAction(BaseChipBtn _baseChipBtn)
        {
            activeChipIndex = _baseChipBtn.Index;
            ChangePanelAction.Invoke(activeChipIndex);
        }

        public void ActivateAfterChange(int _newIndex)
        {
            base.ActivatePanel();

            var _changeChip = chipBtns.Find(_ch => _ch.Index == activeChipIndex);
            var _sprite = ChipSprites[_newIndex];
            _changeChip.SetSprite(_sprite);
            _changeChip.Index = _newIndex;
        }
    }
}
