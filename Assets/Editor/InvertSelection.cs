using System;
using UnityEngine;
using UnityEditor;

using System.Collections.Generic;

public class InvertSelection : ScriptableWizard {


	[MenuItem ("Selection/Invert Entire Selection")]
	static void static_InvertSelection() { 

		List< GameObject > oldSelection = new List< GameObject >();
		List< GameObject > newSelection = new List< GameObject >();

		foreach( GameObject selectedObj in Selection.GetFiltered( typeof( GameObject ), SelectionMode.ExcludePrefab ) )
			oldSelection.Add( selectedObj );

		foreach( GameObject notSelectedObj in FindObjectsOfType( typeof( GameObject ) ) )
		{
			if ( !oldSelection.Contains( notSelectedObj ) )
				newSelection.Add( notSelectedObj );
		}

		Selection.objects = newSelection.ToArray();

	}

}