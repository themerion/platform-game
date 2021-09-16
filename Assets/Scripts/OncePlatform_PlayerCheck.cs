using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OncePlatform_PlayerCheck : MonoBehaviour
{
    PlayerController _player;
    Action<Collider2D> _onTriggerExit;

    // Start is called before the first frame update
    void Start() { }

    public void Setup(PlayerController player, Action<Collider2D> onTriggerExit) {
        _player = player;
        _onTriggerExit = onTriggerExit;
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == _player.name) {
            _onTriggerExit(col);
        }
    }
}

