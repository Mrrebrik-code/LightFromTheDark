using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{
    [SerializeField] private Sprite _spriteRepaired;
    [SerializeField] private Sprite _spriteRepairedShadow;

    [HideInInspector] public bool IsRepaired;


    private void OnMouseDown()
    {
        if(IsRepaired == false)
        {
            IsRepaired = true;
            GetComponent<SpriteRenderer>().sprite = _spriteRepaired;
            transform.Find("Shadow").GetComponent<SpriteRenderer>().sprite = _spriteRepairedShadow;
        }
    }
}
