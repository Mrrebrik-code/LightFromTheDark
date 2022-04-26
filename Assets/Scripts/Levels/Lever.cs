using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private PlayerController _player;
	private bool _isActive = false;

	public bool IsActive { get => _isActive; }

	private void OnMouseDown()
	{
		if (Vector2.Distance(transform.position, _player.transform.position) <= 10f)
		{
			_isActive = !_isActive;

			_animator.SetTrigger(_isActive ? "On" : "Off");
		}
		
	}
}
