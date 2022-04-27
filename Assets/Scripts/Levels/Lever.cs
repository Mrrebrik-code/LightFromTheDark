using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private PlayerController _player;
	private bool _isActive = false;
	[SerializeField] private TriggerLever _trigger;

	public bool IsActive { get => _isActive; }

	private void OnMouseDown()
	{
		if (_trigger.IsActive)
		{
			_isActive = !_isActive;

			_animator.SetTrigger(_isActive ? "On" : "Off");
		}
		
	}
}
