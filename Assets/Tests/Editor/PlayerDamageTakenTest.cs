using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;


public class PlayerDamageTakenTest : MonoBehaviour
{ 
    [Test]
    public void CalculatePlayerDamageTaken_Test() 
    {
        var damage = 1;
        var player = new Player();
        player.health = 5;
        player.DamageHealth(damage);
        var expectedHealth = 4;
        var actualHealth = player.health;
        Assert.That(actualHealth, Is.EqualTo(expectedHealth));
    }
}
