using System;
using UnityEngine;
using UnityEngine.Events;

namespace CheckersGUi
{
    public abstract class BaseSwitcher : MonoBehaviour
    {
        readonly int IS_ON_BOOL = Animator.StringToHash("IsOn");

        Animator switcherAnim;

        public Action<bool> ResetAction;
        public Action<bool, string> SwitchSettingsAction;

        public abstract string ParamName { get; }
        public virtual bool SwitcherState
        {
            get { return AppPrefs.GetBool(ParamName); }
            set
            {
                AppPrefs.SetBool(ParamName, value);
                if (switcherAnim) switcherAnim.SetBool(IS_ON_BOOL, value);
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

            SwitchSettingsAction.Invoke(_value, ParamName);
        }

        public virtual void ResetParams(bool _value)
        {
            SwitcherState = _value;
            SwitchSettingsAction.Invoke(_value, ParamName);
        }
    }
}
