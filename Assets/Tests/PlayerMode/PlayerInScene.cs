using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerInScene : MonoBehaviour
{
    private string sceneToTest = "Game";
   
    [UnityTest]
    public IEnumerator PlayerPresentTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var player = GameObject.Find("Player");
        Assert.IsNotNull(player);
    }
}
