using UnityEngine;

public class PlayerModel
{
    public float MoveSpeed { get; private set; }
    public float GravityScale { get; private set; }

    public PlayerModel(float moveSpeed, float gravityScale)
    {
        MoveSpeed = moveSpeed;
        GravityScale = gravityScale;
    }

    /// <summary>
    /// 移動速度ベクトルを計算して返す
    /// </summary>
    public Vector2 CalcMovementVelocity(float directionX)
    {
        return MoveSpeed * new Vector2(directionX, -GravityScale);
    }
}