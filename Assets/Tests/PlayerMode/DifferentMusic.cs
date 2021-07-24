using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;


public class DifferentMusic : MonoBehaviour
{
    private string sceneToTest = "Menu";
    private string nextScene = "Game";

    [UnityTest]
    public IEnumerator MusicTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var bgmusic = GameObject.FindGameObjectWithTag("music");
        yield return SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
        var gamemusic = GameObject.Find("GameMusic");
        Assert.AreNotEqual(bgmusic,gamemusic);
    }
}
