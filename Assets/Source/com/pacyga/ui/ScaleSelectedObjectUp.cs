using UnityEngine;
using System.Collections;
using com.pacyga.manager;

namespace com.pacyga.ui
{
	public class ScaleSelectedObjectUp : MonoBehaviour 
	{
		private float SCALE_AMOUNT = .1f;

		private ObjectManager _objectManager;
		
		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_objectManager = managers.GetComponent<ObjectManager>();
		}
		
		void OnMouseUp()
		{
			Vector3 scale = _objectManager._selectedGameObject.transform.localScale;
			Vector3 newScale = new Vector3((scale.x + SCALE_AMOUNT), (scale.y + SCALE_AMOUNT), (scale.z + SCALE_AMOUNT));
			_objectManager._selectedGameObject.transform.localScale = newScale;
		} 
	}
}