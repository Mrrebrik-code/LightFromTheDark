using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerControl;
    [SerializeField] bool _keyboardControl;
    [SerializeField] bool _buttonsControl;
    [SerializeField] bool _acceletarionControl;

    private bool _pressedRunRight;
    private bool _pressedRunLeft;
    private bool _pressedJump;

    private void FixedUpdate()
    {

            if (_keyboardControl)
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                    _playerControl.Run(Input.GetAxis("Horizontal") > 0 ? PlayerController.DirectionMove.right : PlayerController.DirectionMove.left);
                if (Input.GetAxisRaw("Jump") != 0)
                    _playerControl.Jump();
            }
            if(_buttonsControl)
            {
                if (_pressedRunRight)
                    _playerControl.Run(PlayerController.DirectionMove.right);
                else if (_pressedRunLeft)
                    _playerControl.Run(PlayerController.DirectionMove.left);

                if (_pressedJump)
                    _playerControl.Jump();
            }
            if(_acceletarionControl)
            {
                Vector3 acceleration = Input.acceleration;
                acceleration.z = 0.0f;
                if(acceleration.magnitude > 0.2f)
                    _playerControl.AccelerationMove(acceleration);
            }

    }

    public void OnDownButtonRunRight()
    {
        _pressedRunRight = true;
    }
    public void OnUpButtonRunRight()
    {
        _pressedRunRight = false;
    }

    public void OnDownButtonRunLeft()
    {
        _pressedRunLeft = true;
    }
    public void OnUpButtonRunLeft()
    {
        _pressedRunLeft = false;
    }

    public void OnDownButtonJump()
    {
        _pressedJump = true;
    }
    public void OnUpButtonJump()
    {
        _pressedJump = false;
    }
}
