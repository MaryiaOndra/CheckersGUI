using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipContainer : MonoBehaviour
{
    [SerializeField]
    List<Sprite> chipsSprites;
    [SerializeField]
    GameObject chipPrefab;
    [SerializeField]
    Transform containerTr;

    public List<Chip> ChipsList { get; private set; }

    public Sprite GetSprite(int _index) 
    {
        return chipsSprites[_index];
    }

    public void InstantiateChips()
    {
        var _chips = new List<Chip>();

        for (int i = 0; i < chipsSprites.Count; i++)
        {
            var _chipGO = Instantiate(chipPrefab, containerTr);
            var _chip = _chipGO.GetComponent<Chip>();
            _chips.Add(_chip);
            _chip.Setup(chipsSprites[i], i);
        }

        ChipsList = _chips;
    }
}
