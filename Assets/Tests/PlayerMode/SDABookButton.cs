using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SDABookButton
{
    private string sceneToTest = "Menu";
    
    [UnityTest]
    public IEnumerator ButtonTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var button = GameObject.Find("Book");
        Assert.IsNotNull(button);
    }
}