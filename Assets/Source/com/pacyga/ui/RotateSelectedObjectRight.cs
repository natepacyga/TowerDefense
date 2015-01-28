using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.ui
{
	public class RotateSelectedObjectRight : MonoBehaviour 
	{
		private const int ROTATE_AMOUNT = 10;

		private ObjectManager _objectManager;
		
		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
		}
		
		void OnMouseUp()
		{
			_objectManager._selectedGameObject.transform.Rotate(0, ROTATE_AMOUNT, 0, Space.World);
		} 
	}
}