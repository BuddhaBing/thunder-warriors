using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;
//
//public class EndPointTest {
//
//	[Test]
//	public void EditorTest() {
//		//Arrange
//		var enemy = new GameObject();
//		var endPointLogic = new EndPointLogic();
//		var endPointMotor = new SpawnMotorMock();
//		endPointLogic.MyMotor = endPointMotor;
//
//		//Act
//		endPointLogic.EnemyLeaked(enemy);
//		//Assert
//		Assert.IsTrue(endPointMotor.DestroyItemCalled);
//	}
//
//}
//
//public class SpawnMotorMock : SpawnMotor{
//	public bool DestroyItemCalled = false;
//	public void DestroyItem(GameObject go){
//		DestroyItemCalled = true;
//	}
//			
//}