using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class JoggerRandomMovement : MonoBehaviour
{
    private GameObject jogger = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Jogger.prefab");


    [UnityTest]
    public IEnumerator JoggerRandomMovementTest()
    {
        var joggerInstance = Object.Instantiate(jogger, new Vector3(0, 0, 0), Quaternion.identity);
        Vector3 position = joggerInstance.transform.position;
        yield return new WaitForSeconds(0.5f);
        Vector3 position1 = joggerInstance.transform.position;
        Assert.AreNotEqual(position, position1);
    }
}
