using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipContainer : MonoBehaviour
{
    [SerializeField]
    List<Sprite> chipsSprites;
    [SerializeField]
    GameObject chipPrefab;
    [SerializeField]
    Transform containerTr;

    public List<Chip> ChipsList { get; private set; }
    public List<Sprite> ChipsSprites => chipsSprites;

    public Sprite GetSprite(int _index) 
    {
        return chipsSprites[_index];
    }

    void Awake()
    {
        var _chips = new List<Chip>();
        var _buttons = new List<Button>();

        for (int i = 0; i < chipsSprites.Count; i++)
        {
            var _chipGO = Instantiate(chipPrefab, containerTr);
            var _chip = _chipGO.GetComponent<Chip>();
            var _btn = _chipGO.GetComponent<Button>();
            _chips.Add(_chip);
            _chip.Setup(chipsSprites[i], i);

        }

        ChipsList = _chips;
        Debug.Log("ChipContainer AWAKE");
    }
}
