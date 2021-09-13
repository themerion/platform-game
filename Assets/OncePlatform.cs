using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncePlatform : MonoBehaviour
{
    public PlayerController Player; // Used by child: Player Check
    OncePlatform_PlayerCheck _playerCheck;

    // Start is called before the first frame update
    void Start()
    {
        _playerCheck = this.gameObject.transform.GetChild(0).GetComponent<OncePlatform_PlayerCheck>();
        _playerCheck.Setup(Player, PlayerExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerExit(Collider2D col) {
        Destroy(gameObject);
    }
}
