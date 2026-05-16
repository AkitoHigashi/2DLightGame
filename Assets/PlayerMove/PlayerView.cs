using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerView : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField] private float _moveSpeed = 10f;
    [Header("重力")]
    [SerializeField] private float _gravityScale = 1f;

    [Header("ライトオブジェクト")]
    [SerializeField] private GameObject _playerLights;

    private Rigidbody2D _rb;
    public Vector2 CurrentDirection => _currentDirection;
    private Vector2 _currentDirection;

    public Vector2 CurrentMousePos => _currentMousePos;
    private Vector2 _currentMousePos;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        LightsControl();
    }
    private void FixedUpdate()
    {
        PerformMove(_currentMousePos.normalized.x, _gravityScale);
    }

    /// <summary>
    /// 方向を受け取って移動する処理メソッド
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="gravityScale"></param>
    private void PerformMove(float direction, float gravityScale)
    {
        _rb.linearVelocity = _moveSpeed * new Vector2(direction, -gravityScale);
    }
    /// <summary>
    /// ライトの向きをマウス位置に合わせる処理メソッド
    /// </summary>
    private void LightsControl()
    {
        _playerLights.transform.up = _currentMousePos - (Vector2)transform.position;
    }


    /// <summary>/// キャラ移動用のUnityEvent登録メソッド/// </summary>
    public void OnTestMove(InputAction.CallbackContext context)
    {
        _currentDirection = context.ReadValue<Vector2>();
        Debug.Log($"移動値: {_currentDirection}");
    }
    public void OnMousePos(InputAction.CallbackContext context)
    {
        //スクリーン座標のマウス位置
        var screenPos = context.ReadValue<Vector2>();
        _currentMousePos = Camera.main.ScreenToWorldPoint(screenPos);
        //Debug.Log($"マウス位置: {_currentMousePos}");
    }
}
