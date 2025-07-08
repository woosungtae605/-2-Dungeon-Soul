using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;

    private Rigidbody2D _rid;
    [SerializeField] private float _moveSpeed;
    Vector2 _moveDir;
    float _saveSizeX;

    private void Awake()
    {
        _saveSizeX = transform.localScale.x;
        _rid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rid.linearVelocity = _moveDir * _moveSpeed;

        if (Keyboard.current.aKey.isPressed) transform.localScale = new Vector3(-_saveSizeX, transform.localScale.y);
        else if (Keyboard.current.dKey.isPressed)
        {
            transform.localScale = new Vector3(_saveSizeX, transform.localScale.y);
        }
    }
      public void OnMove(InputValue Value)
      {  
          _moveDir = Value.Get<Vector2>();
      }
}
