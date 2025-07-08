using UnityEngine;
using UnityEngine.InputSystem;

public class StageManager : MonoBehaviour
{
    private bool _isNearPlayer = false;
    [SerializeField] private GameObject _stageSelectUI;

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
