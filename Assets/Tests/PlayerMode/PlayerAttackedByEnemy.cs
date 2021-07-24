using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerAttackedByEnemy : MonoBehaviour
{
    private string sceneToTest = "Game";
    
    [UnityTest]
    public IEnumerator PlayerAttackedTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var player = GameObject.Find("Player");
        int initialhealth = player.GetComponent<Player>().health;
        yield return new WaitForSeconds(7f);
        int finalhealth = player.GetComponent<Player>().health;
        Assert.AreNotEqual(initialhealth,finalhealth);
    }
}
