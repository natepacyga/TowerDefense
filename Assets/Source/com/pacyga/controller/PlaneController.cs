using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.controller
{
	public class PlaneController : MonoBehaviour 
	{
		
		public ObjectManager objectManager;
		private bool _showPreviewObject = false;

		private RaycastHit _raycastHit;
		
		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			objectManager = managers.GetComponent<ObjectManager>();
		}
		
		void Update()
		{
			if (_showPreviewObject) 
			{
				if (didRaycastHit()) 
				{
					objectManager.showPreviewObject(_raycastHit.point);
				}
			}
			else 
			{
				objectManager.hidePreviewObject();
			}
		}
		
		void OnMouseEnter()
		{
			_showPreviewObject = true;
		}
		
		void OnMouseExit()
		{
			_showPreviewObject = false;
		}
		
		void OnMouseUp()
		{
			if (didRaycastHit()) 
			{
				objectManager.instantiatePlayerGameObject(_raycastHit.point);
			}
		}

		private bool didRaycastHit()
		{
			RaycastHit raycastHit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out raycastHit, 1000)) 
			{
				_raycastHit = raycastHit;
				return true;
			}
			return false;
		}

	}
}