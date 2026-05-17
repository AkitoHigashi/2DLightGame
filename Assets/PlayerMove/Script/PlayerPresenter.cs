using UnityEngine;
public class PlayerPresenter
{
    private PlayerModel _model;

    public PlayerPresenter(PlayerModel model)
    {
        _model = model;
    }

    /// <summary>
    /// ViewからX方向を受け取り、Velocityを計算させて返す
    /// </summary>
    public Vector2 GetMovementVelocity(float directionX)
    {
        return _model.MoveSpeed * new Vector2(directionX, -_model.GravityScale);
    }
}