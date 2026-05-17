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

    [Header("ライト回転の最小距離")]
    [SerializeField] private float _lightRotateThreshold = 0.1f;

    private Rigidbody2D _rb;
    private PlayerModel _playerModel;
    private PlayerPresenter _playerPresenter;

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
        _playerModel = new PlayerModel(_moveSpeed, _gravityScale, _lightRotateThreshold);
        _playerPresenter = new PlayerPresenter(_playerModel);
    }

    private void Update()
    {
        GetMousePos();
        RotateLightToMouse();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    /// <summary>
    /// Presenterから速度を取得してRigidbodyに適用する
    /// </summary>
    private void ApplyMovement()
    {
        _rb.linearVelocity = _playerPresenter.GetMovementVelocity(
            _playerPresenter.GetMovementDirectionX(_mouseWorldPos, transform.position)
        );
    }

    /// <summary>
    /// Presenterから方向を取得してライトを向ける
    /// </summary>
    private void RotateLightToMouse()
    {
        Vector2 dir = _playerPresenter.GetLightDirection(_mouseWorldPos, transform.position);
        if (dir == Vector2.zero) return;
        _playerLights.transform.up = dir;
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
