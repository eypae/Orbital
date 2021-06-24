using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class BoomerMovesTowardsPlayer 
{
    private GameObject boomer = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/BoomerEnemy.prefab");
    private GameObject player = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player1.prefab");

    [UnityTest]
    public IEnumerator BoomerMovesToPlayer()
    {
        var playerInstance = Object.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        var boomerInstance = Object.Instantiate(boomer, new Vector3(9, 8, 0), Quaternion.identity);
        float distfromplayer = (boomerInstance.transform.position - playerInstance.transform.position).sqrMagnitude;
        yield return new WaitForSeconds(0.5f);
        float distfromplayer1 = (boomerInstance.transform.position - playerInstance.transform.position).sqrMagnitude;
        Assert.Less(distfromplayer1, distfromplayer);
    }
}
