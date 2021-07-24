using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;


public class MultiplayerLoadingSceneAutoConnects : MonoBehaviour
{
    private string sceneToTest = "Loading";
   
    [UnityTest]
    public IEnumerator MultiplayerLoadingTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        yield return new WaitForSeconds(5f);
        string sceneName = SceneManager.GetActiveScene().name;
        Assert.AreNotEqual(sceneName, sceneToTest);
    }
}
