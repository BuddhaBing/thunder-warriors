using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PlayerMoneyTest
{

    public GameObject gameObject;
    public PlayerMoney model;
    public int startingMoney = 100;

    [SetUp]
    public void Init()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<PlayerMoney>();
        model = gameObject.GetComponent<PlayerMoney>();
        model.money = startingMoney;
    }

    [Test]
    public void GetMoneyTest()
    {
        Assert.AreEqual(startingMoney, model.GetMoney());
    }

    [Test]
    public void AddMoneyTest()
    {
        var moreMoney = 10;
        model.AddMoney(moreMoney);
        Assert.AreEqual((startingMoney + moreMoney), model.GetMoney());
    }

    [Test]
    public void TakeMoneyTest()
    {
        var lessMoney = 10;
        model.TakeMoney(lessMoney);
        Assert.AreEqual((startingMoney - lessMoney), model.GetMoney());
    }

    [Test]
    public void CanAffordTest()
    {
        Assert.IsTrue(model.CanAfford(50));
        Assert.IsFalse(model.CanAfford(150));
    }

    // TODO add tests for canaffordturret and takemoneyturret once they've been refactored
}