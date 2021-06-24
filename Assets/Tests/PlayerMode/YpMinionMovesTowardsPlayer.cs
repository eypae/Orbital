using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class YpMinionMovesTowardsPlayer
{
    private GameObject ypMinion = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/YPMinion.prefab");
    private GameObject player = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player1.prefab");

    [UnityTest]
    public IEnumerator YpMinionMovesToPlayer()
    {
        var playerInstance = Object.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        var ypMinionInstance = Object.Instantiate(ypMinion, new Vector3(9, 8, 0), Quaternion.identity);
        float distfromplayer = (ypMinionInstance.transform.position - playerInstance.transform.position).sqrMagnitude;
        yield return new WaitForSeconds(0.5f);
        float distfromplayer1 = (ypMinionInstance.transform.position - playerInstance.transform.position).sqrMagnitude;
        Assert.Less(distfromplayer1, distfromplayer);
    }
}