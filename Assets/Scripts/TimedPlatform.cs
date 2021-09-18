using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatform : MonoBehaviour
{
    public PlayerController Player; // Used by child: Player Check
    public float duration = 0.75f;
    Platform_PlayerCheck _playerCheck;
    double playerLandedTime;
    bool playerHasLanded = false;

    // Start is called before the first frame update
    void Start()
    {
        if(Player == null) {
            Debug.Log(nameof(TimedPlatform) + " " + nameof(Player) + " is not set!");
        }

        _playerCheck = this.gameObject.transform.GetChild(0).GetComponent<Platform_PlayerCheck>();
        _playerCheck.Setup(Player);
        _playerCheck.OnEnter(WhenPlayerLands);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHasLanded)
        {
            double now = Time.fixedTimeAsDouble;
            if(now > playerLandedTime + duration )
            {
                Destroy(gameObject);
            }
        }
    }

    void WhenPlayerLands(Collider2D col) {
        if(!playerHasLanded)
        {
            playerHasLanded = true;
            playerLandedTime = Time.fixedTimeAsDouble;
            Debug.Log("playerLandedTime "+playerLandedTime);
        }
    }
}
