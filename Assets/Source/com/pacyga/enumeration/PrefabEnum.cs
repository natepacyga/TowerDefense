using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.pacyga.enumeration
{
	public class PrefabEnum
	{
		public const string PREFABS_PATH = "Prefabs/";
		public const string GAME_OBJECTS_PATH = PREFABS_PATH + "GameObjects/";
		public const string UI_PATH = PREFABS_PATH + "UI/";

		public const string GAME_OBJECT_EDIT_UI_PATH = UI_PATH + "GameObjectEditUI";

		public const string TROLL_AVATAR_PATH = GAME_OBJECTS_PATH + "TrollAvatar";

		public const string BULLET_PATH = GAME_OBJECTS_PATH + "Bullet";

		public const string BANK_PATH = GAME_OBJECTS_PATH + "Bank";
		public const string LUMBERYARD_PATH = GAME_OBJECTS_PATH + "Lumberyard";
		public const string RESIDENCE_PATH = GAME_OBJECTS_PATH + "Residence";
		public const string TOWER_PATH = GAME_OBJECTS_PATH + "Tower";
		public const string TREE_1_PATH = GAME_OBJECTS_PATH + "Tree1";
		public const string TREE_2_PATH = GAME_OBJECTS_PATH + "Tree2";
		public const string TREE_3_PATH = GAME_OBJECTS_PATH + "Tree3";
		public const string TREE_4_PATH = GAME_OBJECTS_PATH + "Tree4";
		public const string WALL_PATH = GAME_OBJECTS_PATH + "Wall";

		public static readonly List<string> GAME_OBJECTS = new List<string>{BANK_PATH, 
																																				LUMBERYARD_PATH,
																																				RESIDENCE_PATH,
																																				TOWER_PATH,
																																				TREE_1_PATH,
																																				TREE_2_PATH,
																																				TREE_3_PATH,
																																				TREE_4_PATH,
																																				WALL_PATH
																																				};

		public static readonly int GAME_OBJECTS_COUNT = GAME_OBJECTS.Count;
		
	}
}