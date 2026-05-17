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
        _playerModel = new PlayerModel(_moveSpeed, _gravityScale);
        _playerPresenter = new PlayerPresenter(_playerModel);
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
        _rb.linearVelocity = _playerPresenter.GetMovementVelocity(directionX);
    }

    /// <summary>
    /// ライトをマウス方向に向ける（閾値以下の距離では更新しない）
    /// </summary>
    private void RotateLightToMouse()
    {
        Vector2 dir = _mouseWorldPos - (Vector2)transform.position;
        if (dir.magnitude < _lightRotateThreshold) return;
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
