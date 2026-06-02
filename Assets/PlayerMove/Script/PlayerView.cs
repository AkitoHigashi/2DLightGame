using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    [Header("ライトオブジェクト")]
    [SerializeField] private GameObject _playerLights;

    [Header("ライト回転の最小距離")]
    [SerializeField] private float _lightRotateThreshold = 0.1f;

    private Rigidbody2D _rb;
    private PlayerPresenter _playerPresenter;

    private Vector2 _mouseWorldPos;

    /// <summary>
    /// GameRootから呼ばれる初期化メソッド。PresenterをViewに注入する。
    /// </summary>
    public void Initialize(PlayerPresenter presenter)
    {
        _playerPresenter = presenter;
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
