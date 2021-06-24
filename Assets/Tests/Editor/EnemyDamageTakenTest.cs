using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class EnemyDamageTakenTest
{
    [Test]
    public void CalculateEnemyDamageTaken_Test()
    {
        var damage = 1;
        var enemy = new Enemy();
        enemy.health = 5;
        enemy.TakeDamage(damage);
        var expectedHealth = 4;
        var actualHealth = enemy.health;
        Assert.That(actualHealth, Is.EqualTo(expectedHealth));
    }
}