using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private PlayerController _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = Game.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == _player.name) {
            _player.AddKey();
            Destroy(gameObject);
        }
    }
}
