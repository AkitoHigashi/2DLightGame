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
    private PlayerModel _playerModel;
    private PlayerPresenter _playerPresenter;

    public Vector2 MoveInput => _moveInput;
    private Vector2 _moveInput;

    public Vector2 MouseWorldPos => _mouseWorldPos;
    private Vector2 _mouseWorldPos;

    private void Init()
    {

    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetMousePos();
        RotateLightToMouse();
    }
    private void FixedUpdate()
    {
        Vector2 dir = _mouseWorldPos - (Vector2)transform.position;
        ApplyMovement(dir.normalized.x);
    }

    /// <summary>
    /// 方向を受け取って移動する処理メソッド
    /// </summary>
    /// <param name="direction"></param>
    private void ApplyMovement(float direction)
    {
        _rb.linearVelocity = _playerPresenter.MovementProcess(direction, _gravityScale);
    }
    /// <summary>
    /// ライトの向きをマウス位置に合わせる処理メソッド
    /// </summary>
    private void RotateLightToMouse()
    {
        _playerLights.transform.up = _mouseWorldPos - (Vector2)transform.position;
    }
    /// <summary>
    /// マウスの位置を取得する処理メソッド
    /// </summary>
    private void GetMousePos()
    {
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    /// <summary>/// キャラ移動用のUnityEvent登録メソッド/// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        Debug.Log($"移動値: {_moveInput}");
    }
    // <summary>/// マウス位置取得用のUnityEvent登録メソッド/// </summary>
    public void OnMousePos(InputAction.CallbackContext context)
    {
        //スクリーン座標のマウス位置
        var screenPos = context.ReadValue<Vector2>();
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
        //Debug.Log($"マウス位置: {_currentMousePos}");
    }
}
