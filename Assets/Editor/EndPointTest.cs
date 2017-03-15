using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;

public class EndPointTest {

	[Test]
	public void EditorTest() {
		//Arrange
		var enemy = new GameObject();
		var endPointLogic = new EndPointLogic();
		var endPointMotor = GetMotorMock();
		endPointLogic.MyMotor = endPointMotor;

		//Act
		//endPointLogic.EnemyLeaked(enemy);
		//Assert
		endPointMotor.Received().DestroyItem(enemy);
	}

	public EndPointMotor GetMotorMock(){
		EndPointMotor EPM = Substitute.For<EndPointMotor>();
		return EPM;
	}
}
