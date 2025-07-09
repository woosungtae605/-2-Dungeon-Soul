using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private bool _isNearPlayer = false;
    [SerializeField] private GameObject _stageSelectUI;
    private Outline _outLine;

    private void Awake()
    {
        _outLine = GetComponent<Outline>();
    }
    private void Start()
    {
        _outLine.enabled = true;
    }
    private void Update()
    {
        if (_isNearPlayer == true && Keyboard.current.fKey.wasPressedThisFrame)
        {
            _stageSelectUI.SetActive(!_stageSelectUI.activeSelf);
        }
       
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isNearPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isNearPlayer = false;
            _stageSelectUI.SetActive(false);
        }
    }
}
