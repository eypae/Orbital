using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MusicPresent : MonoBehaviour
{
    private string sceneToTest = "Menu";

    [UnityTest]
    public IEnumerator MusicTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var bgmusic = GameObject.FindGameObjectWithTag("music");
        Assert.IsNotNull(bgmusic);
    }
}
