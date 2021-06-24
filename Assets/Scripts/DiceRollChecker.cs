using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollChecker : BaseSwitcher
{
    [SerializeField]
    GameObject activeDice;

    [SerializeField]
    GameObject inactiveDice;

    public override string ParamName => PrefsKeys.DiceState_;

    protected override void OnEnable()
    {
        ChangeDiceState(SwitcherState);
    }

    public void ChangeDiceState(bool _state) 
    {
        var _activeObject = _state ? activeDice : inactiveDice;
        var _inactiveObject = _state ? inactiveDice : activeDice;
        _activeObject.SetActive(true);
        _inactiveObject.SetActive(false);

        SwitcherState = _state;
    }

    public override void ResetParams(bool _value)
    {
        base.ResetParams(_value);

        ChangeDiceState(_value);
    }
}
