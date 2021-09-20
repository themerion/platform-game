using UnityEngine;

public class KillBlockController : MonoBehaviour
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
            _player.Kill();
        }
    }
}
