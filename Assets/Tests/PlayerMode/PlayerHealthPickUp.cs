using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerHealthPickUp : MonoBehaviour
{
    private string sceneToTest = "Game";
    private GameObject healthpickup = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HealthPickup.prefab");

    [UnityTest]
    public IEnumerator HealthPickUpTest()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var player = GameObject.Find("Player");
        player.GetComponent<Player>().TakeDamage(1);
        int initialhealth = player.GetComponent<Player>().health;
        var healthpickupinstance = Object.Instantiate(healthpickup, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        int finalhealth = player.GetComponent<Player>().health;
        Assert.AreNotEqual(initialhealth, finalhealth);
    }
}
