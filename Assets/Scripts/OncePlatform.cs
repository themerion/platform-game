using UnityEngine;

public class OncePlatform : MonoBehaviour
{
    private PlayerController _player; // Used by child: Player Check
    Platform_PlayerCheck _playerCheck;

    // Start is called before the first frame update
    void Start()
    {
        _player = Game.GetPlayer();
        
        _playerCheck = this.gameObject.transform.GetChild(0).GetComponent<Platform_PlayerCheck>();
        _playerCheck.Setup(_player);
        _playerCheck.OnLeave(PlayerExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerExit(Collider2D col) {
        Destroy(gameObject);
    }
}
