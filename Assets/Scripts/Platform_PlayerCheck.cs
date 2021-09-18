using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Platform_PlayerCheck : MonoBehaviour
{
    PlayerController _player;
    Action<Collider2D> _onTriggerEnter = (x => {});
    Action<Collider2D> _onTriggerExit = (x => {});

    // Start is called before the first frame update
    void Start() { }

    public void Setup(PlayerController player) {
        _player = player;
    }

    public void OnEnter(Action<Collider2D> func) {
        _onTriggerEnter = func;
    }

    public void OnLeave(Action<Collider2D> func) {
        _onTriggerExit = func;
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == _player.name) {
            _onTriggerExit(col);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == _player.name) {
            _onTriggerEnter(col);
        }
    }
}

