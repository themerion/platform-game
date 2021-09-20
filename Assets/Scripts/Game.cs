using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game {
    private static SceneSettings _sceneSettings;
    private static int _sceneSettingsCacheIndex = -1;

    public static PlayerController GetPlayer() {
        return GetSceneSettings().Player;
    }

    private static SceneSettings GetSceneSettings() {

        if(SceneManager.GetActiveScene().buildIndex != _sceneSettingsCacheIndex)
        {
            var activeScene = SceneManager.GetActiveScene();
            
            _sceneSettings = new SceneSettings();
            _sceneSettings.Player = activeScene
                .GetRootGameObjects()
                .Select(x => { x.TryGetComponent<PlayerController>(out var pc); return pc; })
                .FirstOrDefault(x => x != null);
        }
        return _sceneSettings;
    }
}

public class GameSettings
{

}

public class SceneSettings
{
    public PlayerController Player;
}
