using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;


public class SpawnPointTests {

	private SpawnPointController SpawnManagerTest;

	[SetUp]
	public void Startup(){
		GameObject SpawnPoint = new GameObject ();
		SpawnManagerTest = SpawnPoint.AddComponent<SpawnPointController> ();
	}
		
}
