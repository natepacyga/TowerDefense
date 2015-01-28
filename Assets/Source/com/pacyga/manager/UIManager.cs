using UnityEngine;
using System.Collections;
using com.pacyga.enumeration;
using UnityEngine.UI;

namespace com.pacyga.manager
{
	public class UIManager : MonoBehaviour 
	{
		private const float GAME_OBJECT_EDIT_UI_Y = 5f;

		private GameManager _gameManager;

		private GameObject _gameObjectEditUI;

		public Text resourcesReadout;

		void Start () 
		{
			GameObject managers = GameObject.Find("Managers");
			_gameManager = managers.GetComponent<GameManager>();

			_gameObjectEditUI = GameObject.Instantiate(Resources.Load(PrefabEnum.GAME_OBJECT_EDIT_UI_PATH, typeof(GameObject))) as GameObject;
		}

		void Update()
		{
			if (_gameManager.mode != ModeEnum.GAME)
			{
				hideGameObjectEditUI();
			}
			resourcesReadout.text = "Gold: " + _gameManager.gold + " Wood: " + _gameManager.wood + " Residences: " + _gameManager.residences + " Banks: " + _gameManager.banks + " Lumberyards: " + _gameManager.lumberyards + " Trees: " + _gameManager.trees;
		}

		public void showGameObjectEditUI()
		{
			if (_gameManager.mode == ModeEnum.GAME)
			{
				setGameObjectEditUIVisibility(true);
			}
		}

		public void hideGameObjectEditUI()
		{
			setGameObjectEditUIVisibility(false);
		}

		private void setGameObjectEditUIVisibility(bool state)
		{
			for (int i = 0; i < _gameObjectEditUI.transform.childCount; ++i)
			{
				GameObject child = _gameObjectEditUI.transform.GetChild(i).gameObject;
				if (child.renderer != null) 
				{
					child.renderer.enabled = state;
				}
			}
		}

		public void setGameObjectEditUITransformRelativeTo(Transform relativeTransform)
		{
			Vector3 position = new Vector3(relativeTransform.position.x + relativeTransform.collider.bounds.size.x, GAME_OBJECT_EDIT_UI_Y, relativeTransform.position.z);
			_gameObjectEditUI.transform.position = position;
		}

	}
}