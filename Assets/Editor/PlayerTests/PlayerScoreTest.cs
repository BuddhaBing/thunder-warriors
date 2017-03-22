using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PlayerScoreTest
{
    public GameObject gameObject;
    public PlayerScore model;

    [SetUp]
    public void Init()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<PlayerScore>();
        model = gameObject.GetComponent<PlayerScore>();
    }

    [Test]
    public void GetKillCount()
    {
        Assert.AreEqual(0, model.GetKillCount());
    }

    [Test]
    public void AssignKill()
    {
        model.AssignKill();
        Assert.AreEqual(1, model.GetKillCount());
    }
}