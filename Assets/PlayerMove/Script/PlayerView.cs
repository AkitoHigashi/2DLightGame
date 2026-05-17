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
    private PlayerModel _model;
    private PlayerPresenter _presenter;

    private Vector2 _mouseWorldPos;

    private void Awake()
    {
        Init();
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// ModelとPresenterを初期化する
    /// </summary>
    private void Init()
    {
        _model = new PlayerModel(_moveSpeed, _gravityScale);
        _presenter = new PlayerPresenter(_model);
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
    /// Presenterに方向を渡してRigidbodyに速度を適用する
    /// </summary>
    private void ApplyMovement(float directionX)
    {
        _rb.linearVelocity = _presenter.GetMovementVelocity(directionX);
    }

    /// <summary>
    /// ライトをマウス方向に向ける
    /// </summary>
    private void RotateLightToMouse()
    {
        _playerLights.transform.up = _mouseWorldPos - (Vector2)transform.position;
    }

    /// <summary>
    /// マウスのワールド座標を毎フレーム取得する
    /// </summary>
    private void GetMousePos()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
    }
}