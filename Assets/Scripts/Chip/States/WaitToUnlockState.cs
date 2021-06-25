using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToUnlockState : BaseChipState
{
    [SerializeField]
    ChipTimer timer;

    public override ChipsState ChipState => ChipsState.WaitToUnlock;

    public override void Activate()
    {
        base.Activate();

        timer.GetStartTime(Index);
        timer.StartTimer();
        timer.FinishTimeAction = GoToNextState;
    }

    private void OnEnable()
    {
        timer.GetStartTime(Index);
        timer.StartTimer();
        timer.FinishTimeAction = GoToNextState;
    }

    private void OnDisable()
    {
        timer.SetTime(Index);
    }

    void GoToNextState() 
    {
        NextStateAction.Invoke(ChipsState.Unlocked);
    }

    protected override void OnButtonPressed()
    {
        Debug.Log("you need to wait for unlocking to select");
    }
}
