using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class EndPointTest {

	[Test]
	public void EditorTest() {
		//Arrange
		var Enemy = new GameObject();
		var EndPointLogic = new EndPointLogic();
		//Act
		EndPointLogic.EnemyLeaked(Enemy);

		//Assert
		Assert.IsFalse(Enemy);
	}
}
