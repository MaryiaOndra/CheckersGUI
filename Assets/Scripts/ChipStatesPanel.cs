using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChipStatesPanel : MonoBehaviour
{
    [SerializeField]
    TMP_Text allChips;
    [SerializeField]
    TMP_Text unlockedChips;

    public void SetChipsState(int _unlocked, int _all) 
    {
        allChips.text = _all.ToString();
        unlockedChips.text = _unlocked.ToString();
    }
}
