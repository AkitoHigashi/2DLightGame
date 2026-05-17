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
}