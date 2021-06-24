using UnityEngine;

public abstract class BaseSwitcher : MonoBehaviour
{ 
    readonly int IS_ON_BOOL = Animator.StringToHash("IsOn");

    Animator switcherAnim;

    protected abstract string ParamName { get; }
    public bool SwitcherState { get; private set; }

    private void Awake()
    {
        switcherAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SwitcherState = GetData();
        switcherAnim.SetBool(IS_ON_BOOL, SwitcherState);
        Debug.Log("OnEnable" + ParamName + "State:  " + SwitcherState);
    }

    public void OnSwitch() 
    {
        var _value = SwitcherState == true ? false : true;

        switcherAnim.SetBool(IS_ON_BOOL, _value);
        SwitcherState = _value;
        SetData(_value);
    }

    void SetData(bool _value) 
    {
        AppPrefs.SetBool(ParamName, _value);
        Debug.Log("SetData" + ParamName + "State:  " + SwitcherState);
    }

    bool GetData() 
    {
        return AppPrefs.GetBool(ParamName);
    }

}
