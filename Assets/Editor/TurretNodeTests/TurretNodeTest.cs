using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TurretNodeTest
{
    public GameObject gameObject;
    public TurretNode model;

    [SetUp]
    public void Init()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<TurretNode>();
        model = gameObject.GetComponent<TurretNode>();
    }

    [Test]
    public void IsTimeToFireTest()
    {
        Assert.IsTrue(model.IsBuildable());
    }

    [Test]
    public void SetOccupiedTest()
    {
        model.SetOccupied(true);
        Assert.IsFalse(model.IsBuildable());
    }
}