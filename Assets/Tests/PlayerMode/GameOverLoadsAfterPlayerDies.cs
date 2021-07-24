using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameOverLoadsAfterPlayerDies
{
    private string sceneToTest = "Game";
    
    [UnityTest]
    public IEnumerator GameOverLoadsTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        yield return new WaitForSeconds(15f);
        string sceneName = SceneManager.GetActiveScene().name;
        Assert.AreNotEqual(sceneName, sceneToTest);
    }
}
