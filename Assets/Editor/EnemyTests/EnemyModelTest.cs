using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class EnemyModelTest {

    public GameObject gameObject;
    public EnemyModel model;
    public int maxHealth;

    [SetUp]
    public void Init()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<EnemyModel>();
        model = gameObject.GetComponent<EnemyModel>();
        maxHealth = 100;
        model.SetMaxHealth(maxHealth);
    }

    [Test]
	public void SetMaxHealthTest()
	{
		Assert.AreEqual(maxHealth, model.GetHealth());
	}

	[Test]
	public void TakeDamageTest()
	{
		int damage = 10;
		model.TakeDamage(damage);

		Assert.AreEqual (90, model.GetHealth ());
	}

    [Test]
    public void IsDeadTest()
    {
        Assert.IsFalse(model.IsDead());
        model.TakeDamage(maxHealth);
        Assert.IsTrue(model.IsDead());
    }

    [Test]
    public void HealthRatio()
    {
        Assert.AreEqual(1, model.HealthRatio());
    }
}
