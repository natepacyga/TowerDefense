using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.ui
{
	public class DeleteSelectedObject : MonoBehaviour 
	{
		private ObjectManager _objectManager;
		private UIManager _uiManager;
		
		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
			_uiManager = managers.GetComponent<UIManager>();
		}
		
		void OnMouseUp()
		{
			_objectManager.destroySelectedGameObject();
			_uiManager.hideGameObjectEditUI();
		} 
	}
}