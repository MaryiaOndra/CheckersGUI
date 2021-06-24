using System;
using UnityEngine;

public abstract class BaseSwitcher : MonoBehaviour
{
    readonly int IS_ON_BOOL = Animator.StringToHash("IsOn");

    Animator switcherAnim;

    public Action<bool> ResetAction;

    public abstract string ParamName { get; }
    public virtual bool SwitcherState
    {
        get { return AppPrefs.GetBool(ParamName); }
        set 
        {
            AppPrefs.SetBool(ParamName, value);
            if(switcherAnim) switcherAnim.SetBool(IS_ON_BOOL, value);
        }
    }

    protected virtual void OnEnable()
    {
        switcherAnim.SetBool(IS_ON_BOOL, SwitcherState);
    }

    protected virtual void Awake()
    {
        switcherAnim = GetComponent<Animator>();
        ResetAction = ResetParams;
    }

    public virtual void OnSwitch()
    {
        var _value = SwitcherState == true ? false : true;
        SwitcherState = _value;
    }

    public virtual void ResetParams( bool _value)
    {
        SwitcherState = _value;        
    }
}
