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
    /// X方向入力から移動速度ベクトルを計算する
    /// </summary>
    public Vector2 CalcVelocity(float directionX)
    {
        return MoveSpeed * new Vector2(directionX, -GravityScale);
    }
}
