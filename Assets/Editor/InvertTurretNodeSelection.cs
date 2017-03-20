using System;
using UnityEngine;
using UnityEditor;

using System.Collections.Generic;

public class InvertTurretNodeSelection : ScriptableWizard {


	[MenuItem ("Selection/Invert Turret Node Selection")]
	static void static_InvertTurretNodeSelection() { 

		List< GameObject > oldSelection = new List< GameObject >();
		List< GameObject > newSelection = new List< GameObject >();

		foreach( GameObject selectedObj in Selection.GetFiltered( typeof( GameObject ), SelectionMode.ExcludePrefab ) )
			oldSelection.Add( selectedObj );

		foreach( GameObject notSelectedObj in FindObjectsOfType( typeof( GameObject ) ) )
		{
			// if ( !oldSelection.Contains( notSelectedObj ) && notSelectedObj.name.Contains("TurretNode") ) // ALTERNATE METHOD
			if ( !oldSelection.Contains( notSelectedObj ) && notSelectedObj.tag == "Turret Node" )
				newSelection.Add( notSelectedObj );
		}

		Selection.objects = newSelection.ToArray();

	}

}