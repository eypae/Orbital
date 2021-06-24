using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class BossDamageTakenTest
{
    [Test]
    public void CalculateBossDamageTaken_Test()
    {
        var damage = 1;
        var boss = new Boss();
        boss.health = 6;
        boss.DamageHealth(damage);
        var expectedHealth = 5;
        var actualHealth = boss.health;
        Assert.That(actualHealth, Is.EqualTo(expectedHealth));
    }
}
