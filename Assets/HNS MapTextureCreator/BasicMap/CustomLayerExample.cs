using UnityEngine;
using SickscoreGames.HUDNavigationSystem;

public class CustomLayerExample : MonoBehaviour
{
	private HUDNavigationSystem _HUDNavigationSystem;

	void Start ()
	{
		_HUDNavigationSystem = HUDNavigationSystem.Instance;
	}


	void Update ()
	{
		// check if the 'F' key was pressed
		if (Input.GetKeyDown(KeyCode.F) && _HUDNavigationSystem.currentMinimapProfile != null)
		{
			// get custom layer from the current map profile
			GameObject customLayer = _HUDNavigationSystem.currentMinimapProfile.GetCustomLayer("BasicLayerMap");
			if (customLayer != null)
				customLayer.SetActive(!customLayer.activeSelf);
		}
	}
}