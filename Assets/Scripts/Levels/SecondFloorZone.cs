using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorZone : MonoBehaviour
{
    [SerializeField] private Animation _mainCameraAnim;
    [SerializeField] private List<string> _nameAnimations = new List<string>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _mainCameraAnim.Play(_nameAnimations.Count > 0 ? _nameAnimations[0] : "MoveUp");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _mainCameraAnim.Play(_nameAnimations.Count > 0 ? _nameAnimations[1] : "MoveDown");
        }
    }
}
