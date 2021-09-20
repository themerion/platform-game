using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    private PlayerController _player;
    public int keysRequired;
    public string nextScene;

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
            if(_player.KeyCount() >= keysRequired) {
                NextScene();
            }
        }
    }

    private void NextScene() {
        if(!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        } else {
            // Try to load the "next" scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
