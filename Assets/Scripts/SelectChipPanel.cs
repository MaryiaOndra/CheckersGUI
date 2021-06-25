using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public class SelectChipPanel : BasePanel
    {
        [SerializeField]
        ChipContainer chipContainer;

        [SerializeField]
        ChipStatesPanel statesPanel;

        int newChipIndex;
        public Sprite SpriteToChange { get; private set; }
        List<Chip> chipsList { get; set; }

        public Action<int> ReturnToSettings;
        public Action ChangeSpriteAction;

        internal List<Sprite> GetSpriteList() => chipContainer.ChipsSprites;


        private void OnEnable()
        {
            chipsList = chipContainer.ChipsList;
        }

        public void ActivatePanel(int _index)
        {
            base.ActivatePanel();
            Debug.Log("ActivatePanel");

            chipsList = chipContainer.ChipsList;
            chipsList[_index].OnNextStateRequest(ChipsState.Selected);
            newChipIndex = _index;
            chipsList.ForEach(_ch => _ch.OnChosen = OnChoosenChip);
            chipsList.ForEach(_ch => _ch.ChangeStateAction = ChangePanelStates);
            ChangePanelStates();

            chipsList.ForEach(_ch => _ch.CurrentState.Activate());
        }

        void OnChoosenChip(Chip _chip)
        {
            FromChoosenToUnlock();
            newChipIndex = _chip.ChipIndex;
        }

        void ChangePanelStates()
        {
            int _all = chipsList.Count;
            int _unlocked = chipsList.FindAll(_ch => _ch.CurrentState.ChipState == ChipsState.Unlocked).Count;
            int _selected = chipsList.FindAll(_ch => _ch.CurrentState.ChipState == ChipsState.Selected).Count;
            statesPanel.SetChipsState(_unlocked + _selected, _all);
        }

        public void FromChoosenToUnlock()
        {
            var _chip = chipsList.Find(_ch => _ch.CurrentState.ChipState == ChipsState.Selected);

            if (_chip)
                _chip.OnNextStateRequest(ChipsState.Unlocked);
        }

        public void ResetChipsState(List<Chip> _chips, int _index)
        {
            for (int i = 0; i < _chips.Count; i++)
            {
                _chips[i].ResetState(i, _index);
            }
        }

        public override void DiactivatePanel()
        {
            chipsList[newChipIndex].OnNextStateRequest(ChipsState.Unlocked);
            ReturnToSettings.Invoke(newChipIndex);

            base.DiactivatePanel();
        }
    }

    public enum ChipsState
    {
        Locked,
        Unlocked,
        Selected,
        WaitToUnlock
    }
}

