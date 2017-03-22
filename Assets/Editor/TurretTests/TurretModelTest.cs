using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TurretModelTest
{
    public GameObject gameObject;
    public TurretModel model;

    [SetUp]
    public void Init()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<TurretModel>();
        model = gameObject.GetComponent<TurretModel>();
    }

    [Test]
    public void IsTimeToFireTest()
    {
        Assert.IsTrue(model.IsTimeToFire());
    }

    [Test]
    public void ResetTimerTest()
    {
        var fireRate = 2;
        model.ResetTimer(fireRate);
        Assert.IsFalse(model.IsTimeToFire());
    }
}