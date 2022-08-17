using UnityEngine;

public class Game : MonoBehaviour {

	public static int Initialized 		= 0;

	public static int SCORE = 0;
	public static bool wasIngame = false;

	public static bool gameCompletedReported = false;

	/////////////////////////////////
	// Scenes Names
	/////////////////////////////////
	public static string TAG_ANIMAL 	= "Animal";
	public static string TAG_PLANT 		= "Plant";
	public static string TAG_SEED		= "Seed";
	public static string TAG_GROUND 	= "Ground";

	/////////////////////////////////
	// Scenes Names
	/////////////////////////////////
	public static string S_MAIN_MENU 	= "MainMenu";
	public static string S_GAME 		= "Game";
	public static string S_INIT 		= "_Init";

	/////////////////////////////////
	// Characters - Plants Types
	/////////////////////////////////
	public static int currentCharacter = 0;
	
	public const int TYPE_BEE 		= 1;
	public const int TYPE_HUMMING 	= 2;
	public const int TYPE_FLY 		= 3;
	public const int TYPE_BAT 		= 4;
	public const int TYPE_HERMIT 	= 5;
	public const int TYPE_SQUIRREL 	= 6;
	public const int TYPE_WIND 		= 7;

	/////////////////////////////////
	// Levels
	/////////////////////////////////
	public static int currentLevel 	= 1;

	public const int LEVEL_1 		= 1;
	public const int LEVEL_2 		= 2;
	public const int LEVEL_3 		= 3;
	public const int LEVEL_4 		= 4;
	public const int LEVEL_5 		= 5;
	public const int LEVEL_6 		= 6;
	public const int LEVEL_7 		= 7;
	public const int LEVEL_8 		= 8;

	public static bool UNLOCKED_LEVEL_1 = true;
	public static bool UNLOCKED_LEVEL_2 = false;
	public static bool UNLOCKED_LEVEL_3 = false;
	public static bool UNLOCKED_LEVEL_4 = false;
	public static bool UNLOCKED_LEVEL_5 = false;
	public static bool UNLOCKED_LEVEL_6 = false;
	public static bool UNLOCKED_LEVEL_7 = false;
	public static bool UNLOCKED_LEVEL_8 = false;

	/////////////////////////////////
	// Color Properties
	/////////////////////////////////

	public const int COLOR_YELLOW 	= 1;
	public const int COLOR_RED 		= 2;
	public const int COLOR_LIGHT 	= 3;
	public const int COLOR_DARK 	= 4;

	/////////////////////////////////
	// Nectar Properties
	/////////////////////////////////
	public const int NECTAR_PRESENT 		= 1;
	public const int NECTAR_HIDDEN 			= 2;
	public const int NECTAR_ABUNDANT_HIDDEN = 3;
	public const int NECTAR_NONE 			= 4;

	/////////////////////////////////
	// Odor Properties
	/////////////////////////////////
	public const int ODOR_FRESH 		= 1;
	public const int ODOR_NONE 			= 2;
	public const int ODOR_FRUITSY 		= 3;
	public const int ODOR_PUTRID 		= 4;

	/////////////////////////////////
	// Shape Properties
	/////////////////////////////////
	public const int SHAPE_LANDING 		= 1;
	public const int SHAPE_TUBULAR 		= 2;
	public const int SHAPE_BOWL 		= 3;
	public const int SHAPE_TRAP 		= 4;

	/////////////////////////////////
	// Levels Stars
	/////////////////////////////////
	public static int STARS_LEVEL_1 	= 0;
	public static int STARS_LEVEL_2 	= 0;
	public static int STARS_LEVEL_3 	= 0;
	public static int STARS_LEVEL_4 	= 0;
	public static int STARS_LEVEL_5 	= 0;
	public static int STARS_LEVEL_6 	= 0;
	public static int STARS_LEVEL_7 	= 0;
	public static int STARS_LEVEL_8 	= 0;

}
