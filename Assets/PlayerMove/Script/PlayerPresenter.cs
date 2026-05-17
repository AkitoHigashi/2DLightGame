using UnityEngine;
public class PlayerPresenter
{
    private PlayerModel _playemodel;

    public PlayerPresenter(PlayerModel model)
    {
        _playemodel = model;
    }

    /// <summary>
    /// ViewからX方向を受け取り、Velocityを計算させて返す
    /// </summary>
    public Vector2 GetMovementVelocity(float directionX)
    {
        return _playemodel.MoveSpeed * new Vector2(directionX, -_playemodel.GravityScale);
    }
}