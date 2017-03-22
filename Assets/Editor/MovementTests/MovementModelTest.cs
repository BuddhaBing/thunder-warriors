using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class MovementModelTest
{

    public GameObject gameObject;
    public MovementModel model;

    [SetUp]
    public void Init()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<MovementModel>();
        model = gameObject.GetComponent<MovementModel>();
    }

    [Test]
    public void TargetDirTest()
    {
        var target = new Vector3(4f, 4f, 4f);
        var enemy = new Vector3(1f, 1f, 1f);
        var expected = new Vector3(3f, 3f, 3f);

        Assert.AreEqual(expected, model.TargetDir(target, enemy));
    }

    [Test]
    public void NormaliseSpeedTest()
    {
        var speed = 5f;
        var time = 2f;
        var expected = 10f;

        Assert.AreEqual(expected, model.NormaliseSpeed(speed, time));
    }
}