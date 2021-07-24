using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayButton
{
    private string sceneToTest = "Menu";
    
    [UnityTest]
    public IEnumerator ButtonTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var button = GameObject.Find("Play");
        Assert.IsNotNull(button);
    }
}