using UnityEngine;
public class PlayerPresenter
{
    private PlayerModel _playermodel;

    public PlayerPresenter(PlayerModel model)
    {
        _playermodel = model;
    }

    /// <summary>
    /// ViewからX方向を受け取り、Velocityを計算させて返す
    /// </summary>
    public Vector2 GetMovementVelocity(float directionX)
    {
        return _playermodel.MoveSpeed * new Vector2(directionX, -_playermodel.GravityScale);
    }
}