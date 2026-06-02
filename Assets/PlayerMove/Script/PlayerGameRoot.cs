using UnityEngine;

/// <summary>
/// PlayerのMVPを組み立てるエントリーポイント。
/// Model・Presenter・Viewの生成と依存注入を担当する。
/// </summary>
public class PlayerGameRoot : MonoBehaviour
{
    [Header("Player View")]
    [SerializeField] private PlayerView _playerView;

    [Header("移動パラメータ")]
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _gravityScale = 1f;

    private void Awake()
    {
        // Model生成
        var model = new PlayerModel(_moveSpeed, _gravityScale);

        // Presenter生成（ModelをDI）
        var presenter = new PlayerPresenter(model);

        // ViewにPresenterをDI
        _playerView.Initialize(presenter);
    }
}
