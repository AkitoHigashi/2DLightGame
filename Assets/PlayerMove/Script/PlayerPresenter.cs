using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel _model;

    public PlayerPresenter(float moveSpeed, float gravityScale)
    {

    }
    public Vector2 MovementProcess(float direction,float gravityScale)
    {
         return _model.MoveSpeed * new Vector2(direction, -gravityScale);
    }
}
