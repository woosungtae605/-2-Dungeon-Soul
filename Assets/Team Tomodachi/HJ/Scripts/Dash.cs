using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField] private float _dashSpeed = 20f;
    [SerializeField] private float _dashTime = 0.2f;
    [SerializeField] private float _dashCooldown = 1f;

    [Header("Slide")]
    [SerializeField] private float slideDuration = 0.3f;

    private Rigidbody2D _rb;
    private Vector2 _moveDir;
    bool _isDashing;
    private bool _canDash = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        _moveDir = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) _moveDir.y += 1;
        if (Keyboard.current.sKey.isPressed) _moveDir.y -= 1;
        if (Keyboard.current.aKey.isPressed) _moveDir.x -= 1;
        if (Keyboard.current.dKey.isPressed) _moveDir.x += 1;

        _moveDir = _moveDir.normalized;

        // 대시 입력
        if (Keyboard.current.spaceKey.wasPressedThisFrame && _canDash && _moveDir != Vector2.zero)
        {
            StartCoroutine(DashCT(_moveDir));
        }
    }

    private IEnumerator DashCT(Vector2 direction)
    {
        _canDash = false;
        _isDashing = true;


        Vector2 slideVelocity = _rb.linearVelocity;
        float slideTimer = 0f;
        while (slideTimer < slideDuration)
        {
            _rb.linearVelocity =  direction * _dashSpeed / 2.5f;
            slideTimer += Time.deltaTime;
            yield return null;
        }
        // 대시
        float dashTimer = 0f;
        while (dashTimer < _dashTime)
        {
            _rb.linearVelocity = direction * _dashSpeed *1.9f;
            dashTimer += Time.deltaTime;
            yield return null;
        }

        _rb.linearVelocity = Vector2.zero;
        _isDashing = false;

        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
    }
}
