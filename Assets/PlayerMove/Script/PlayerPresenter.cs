using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel _playerModel;

    public PlayerPresenter(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    /// <summary>
    /// 移動速度ベクトルを計算して返す
    /// </summary>
    public Vector2 GetMovementVelocity(float directionX)
    {
        return _playerModel.MoveSpeed * new Vector2(directionX, -_playerModel.GravityScale);
    }

    /// <summary>
    /// ライトを向ける方向ベクトルを計算して返す（閾値以下はゼロベクトル）
    /// </summary>
    public Vector2 GetLightDirection(Vector2 mouseWorldPos, Vector2 playerPos)
    {
        Vector2 dir = mouseWorldPos - playerPos;
        if (dir.magnitude < _playerModel.LightRotateThreshold) return Vector2.zero;
        return dir;
    }

    /// <summary>
    /// 移動のX方向を計算して返す
    /// </summary>
    public float GetMovementDirectionX(Vector2 mouseWorldPos, Vector2 playerPos)
    {
        return (mouseWorldPos - playerPos).normalized.x;
    }
}
