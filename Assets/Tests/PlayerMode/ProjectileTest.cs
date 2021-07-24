using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
public class ProjectileTest : MonoBehaviour
{
    private GameObject summoner = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/YP1.prefab");
    private GameObject player = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player1.prefab");
    private GameObject projectile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Projectile.prefab");

    [UnityTest]
    public IEnumerator ProjectileShootTest()
    {
        var summonerInstance = Object.Instantiate(summoner, new Vector3(0, 0, 0), Quaternion.identity);
        var playerInstance = Object.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        int initialhealth = summonerInstance.GetComponent<Summoner>().health;
        var projectileInstance = Object.Instantiate(projectile, summonerInstance.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        int finalhealth = summonerInstance.GetComponent<Summoner>().health;
        Assert.AreNotEqual(initialhealth, finalhealth);
    }
}
