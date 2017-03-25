using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretNodeView : MonoBehaviour {

	public Color hoverColor;

	private TurretNode self;

	private Renderer rend;
	private Color startColor;

	private Coroutine pulser;
	private bool pulsing = false;
	private float pulseDuration = 0.5f;
	private float smoothness = 0.02f;

	private BuildingManager buildingManager;

	void Start () {
		self = GetComponent<TurretNode> ();
		buildingManager = self.buildingManager;
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void Update() {
		if (pulsing && buildingManager.nodeToBuildOn != self) { 
			StopPulsing ();
		} else if (!pulsing && buildingManager.nodeToBuildOn == self) { 
			pulser = StartCoroutine(PulseColor());
		}
	}

	void OnMouseEnter()
	{
		if (IsOverGameObject()) return;
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	void OnMouseDown()
	{
		if (IsOverGameObject()) return;
		self.StartBuild ();
	}

	IEnumerator PulseColor()
	{
		float progress = 0f;
		float increment = smoothness/pulseDuration;
		while(progress < 1)
		{
			pulsing = true;
			rend.material.color = Color.Lerp(Color.green, startColor, progress);
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		pulsing = false;
	}

	void StopPulsing() {
		StopCoroutine (pulser);
		rend.material.color = startColor;
		pulsing = false;
	}

	bool IsOverGameObject() {
		return EventSystem.current.IsPointerOverGameObject ();
	}

}
