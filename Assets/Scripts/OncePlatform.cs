using UnityEngine;

public class OncePlatform : MonoBehaviour
{
    public PlayerController Player; // Used by child: Player Check
    Platform_PlayerCheck _playerCheck;

    // Start is called before the first frame update
    void Start()
    {
        if(Player == null) {
            Debug.Log(nameof(OncePlatform) + " " + nameof(Player) + " is not set!");
        }
        
        _playerCheck = this.gameObject.transform.GetChild(0).GetComponent<Platform_PlayerCheck>();
        _playerCheck.Setup(Player);
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
