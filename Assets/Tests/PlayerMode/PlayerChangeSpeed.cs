using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerChangeSpeed : MonoBehaviour
{ 
    private string sceneToTest = "Game";
    private GameObject speedpickup = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PlayerSpeedPowerup.prefab");

    [UnityTest]
    public IEnumerator SpeedPickUpTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var player = GameObject.Find("Player");
        float initialspeed = player.GetComponent<Player>().speed;
        var speedpickupinstance = Object.Instantiate(speedpickup, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        float finalspeed = player.GetComponent<Player>().speed;
        Assert.AreNotEqual(initialspeed, finalspeed);
    }
}
