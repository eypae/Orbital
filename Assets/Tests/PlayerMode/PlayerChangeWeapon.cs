using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerChangeWeapon : MonoBehaviour
{
    private string sceneToTest = "Game";
    private GameObject newweapon = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/WepPickup1.prefab");

    [UnityTest]
    public IEnumerator ChangeWeapon()
    {
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));
        var player = GameObject.Find("Player");
        var initialweapon = GameObject.FindGameObjectWithTag("Weapon");
        var weaponpickup = Object.Instantiate(newweapon, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        var finalweapon = GameObject.FindGameObjectWithTag("Weapon");
        Assert.AreNotEqual(initialweapon, finalweapon);
    }
}
