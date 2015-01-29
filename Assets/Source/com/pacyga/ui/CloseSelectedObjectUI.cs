using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.ui
{
	public class CloseSelectedObjectUI : MonoBehaviour 
	{
		private UIManager _uiManager;
		private MouseManager _mouseManager;
		
		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_uiManager = managers.GetComponent<UIManager>();
			_mouseManager = managers.GetComponent<MouseManager>();
		}
		
		void Update()
		{
			if (Input.GetMouseButtonUp(0) && _mouseManager.didRaycastHitState && _mouseManager.raycastHit.collider == collider)
			{
				_uiManager.hideGameObjectEditUI();
			}
		}
	}
}
