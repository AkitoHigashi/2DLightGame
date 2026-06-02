using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel _playerModel;

    public PlayerPresenter(PlayerModel model)
    {
        _playerModel = model;
    }

    /// <summary>
    /// ViewからX方向を受け取り、Modelに速度計算を委譲して返す
    /// </summary>
    public Vector2 GetMovementVelocity(float directionX)
    {
        return _playerModel.CalcVelocity(directionX);
    }
}
