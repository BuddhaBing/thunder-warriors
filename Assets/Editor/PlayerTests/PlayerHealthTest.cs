using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PlayerHealthTest {

	public GameObject gameObject;
	public PlayerHealth model;

	[SetUp]
	public void Init() {
		gameObject = new GameObject();
		gameObject.AddComponent<PlayerHealth>();
        model = gameObject.GetComponent<PlayerHealth>();
        model.health = 5;
        model.damagePerEnemy = 1;
	}

	[Test]
	public void GetHealth() {
		Assert.AreEqual(5, model.GetHealth());
	}

	[Test]
	public void IsDead() {
		Assert.IsFalse(model.IsDead());
		model.health = 0;
		Assert.IsTrue(model.IsDead());
	}

	[Test]
	public void TakeDamage() {
		model.TakeDamage();
		Assert.AreEqual(4, model.health);
	}
}
