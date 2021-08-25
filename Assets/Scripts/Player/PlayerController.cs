using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Характеристики")]
    [SerializeField] private float _moveSpeed = 3f;    //Скорость движения
    [SerializeField] private float _jumpForce = 5f;    //Сила прыжка 

    [Header("Компоненты")]
    [SerializeField] private LayerMask _whatIsSolid;
    [SerializeField] private Transform _transformCheckGround;

    public bool _isGrounded = false;                  //Стоит ли на земле?
    private float _timeReloadJump = 0.2f;              //Время перарядки прыжка
    private float _timeFall;                           //Время падения
    private bool _jumpLoaded = true;                   //Прыжок заряжен
    private Vector3 _lastPosition;                     //Последняя позиция игрока

    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private CapsuleCollider2D _collider;
    private Transform _transform;
    private PlayerAnimStates _animStates;


    [HideInInspector]
    public Vector3 Velocity;                          //Скорость игрока

    public enum DirectionMove
    {
        right = 1,
        left = -1
    }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider2D>();
        _transform = GetComponent<Transform>();
        _animStates = GetComponent<PlayerAnimStates>();
    }

    private void Start()
    {

    }

    private void Death()
    {

    }

    private void FixedUpdate()
    {
        Velocity = (transform.position - _lastPosition) / Time.fixedDeltaTime;

        CheckGround();

        if (_isGrounded || Mathf.Abs(Velocity.y) < 0.1)
        {
            _animStates.State = PlayerAnimStates.States.idle;
            _animStates.State = PlayerAnimStates.States.idle;
        }
        else if (Velocity.y > 0.1)
        {
            _animStates.State = PlayerAnimStates.States.jump;
        }
        else if (Velocity.y < -0.1)
        {
            _animStates.State = PlayerAnimStates.States.fall;
        }

        //Начисление время падения
        if (_animStates.State == PlayerAnimStates.States.fall)
            _timeFall += Time.fixedDeltaTime;
        else
            _timeFall = 0.0f;

        _lastPosition = transform.position;
    }



    public void Run(DirectionMove direction)
    {
/*        if (_isGrounded)
        {
            _animStates.StateChar = AnimStates.States.run;
            if (!isShooting)
                _animStates.StateWeap = AnimStates.States.run;
        }*/

        Vector3 dir = Vector3.right * (int)direction;

        if (dir.x < 0.0f)
        {
            _transform.rotation = Quaternion.AngleAxis(180.0f, _transform.up);

        }
        else
        {
            _transform.rotation = Quaternion.AngleAxis(0, _transform.up);
        }

        _transform.position = Vector3.Lerp(_transform.position, _transform.position + dir, _moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded && _jumpLoaded)
        {
/*            _animStates.StateChar = AnimStates.States.jump;
            _animStates.StateWeap = AnimStates.States.jump;*/
            _rb.velocity = new Vector2(0, _jumpForce);
            StartCoroutine("ReloadJump");
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(_transformCheckGround.position, new Vector3(0.40f, 0.05f, 0.0f), 0f, _whatIsSolid);
        _isGrounded = colliders.Length > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_transformCheckGround.position, new Vector3(1.40f, 0.3f, 1.0f));
    }

    IEnumerator ReloadJump()
    {
        _jumpLoaded = false;
        yield return new WaitForSeconds(_timeReloadJump);
        _jumpLoaded = true;
    }
}
