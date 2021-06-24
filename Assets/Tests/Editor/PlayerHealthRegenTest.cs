using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


public class PlayerHealthRegen: MonoBehaviour
{
    [Test]
    public void PlayerHealthRegen_Test()
    {
        var healamount = 1;
        var player = new Player();
        player.health = 4;
        player.HealPlayer(healamount);
        var expectedHealth = 5;
        var actualHealth = player.health;
        Assert.That(actualHealth, Is.EqualTo(expectedHealth));

    }
}
