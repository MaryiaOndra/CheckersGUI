using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class BaseChipBtn : MonoBehaviour
{
    [SerializeField]
    Image chipSprite;

    Button button;

    protected abstract string PrefsKey { get; }
    protected abstract int DefoultIndx { get; }
    public int Index { get; set; }

    public UnityAction<BaseChipBtn> OnClickBtnAction;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public int SetChipButtonIndex() 
    {
        Index = GetChipIndex();

        if (Index == 0)
        {
            Index = DefoultIndx;
        }

        return Index;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }

    void OnButtonClicked() 
    {
        OnClickBtnAction.Invoke(this);
    }

    public void SetSprite(Sprite _sprite) 
    {
        chipSprite.sprite = _sprite;
    }

    protected int GetChipIndex()
    {
        return AppPrefs.GetInt(PrefsKey);
    }

    public void SaveChipIndex(int _index)
    {
        AppPrefs.SetInt(PrefsKey, _index);
    }

    public void ResetChipIndexes()
    {
        Index = DefoultIndx;
    }

}
