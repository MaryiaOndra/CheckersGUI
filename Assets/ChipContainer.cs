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

    public List<Chip> chips;

    public void ShowChips()
    {
        for (int i = 0; i < chipsSprites.Count; i++)
        {
            var _chipGO = Instantiate(chipPrefab, containerTr);
            var _chip = _chipGO.GetComponent<Chip>();
            chips.Add(_chip);
            _chip.Setup(chipsSprites[i]);
        }
    }
}
