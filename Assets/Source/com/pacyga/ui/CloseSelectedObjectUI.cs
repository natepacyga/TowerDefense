using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.ui
{
	public class CloseSelectedObjectUI : MonoBehaviour 
	{
		private UIManager _uiManager;
		
		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_uiManager = managers.GetComponent<UIManager>();
		}
		
		void OnMouseUp()
		{
			_uiManager.hideGameObjectEditUI();
		}
	}
}
