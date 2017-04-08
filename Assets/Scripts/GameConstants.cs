using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameConstants {
//	#if UNITY_ANDROID 
	public static string LEADERBOARD_ID = GPGSIds.leaderboard_comlinestopleaderboard;
//	#elif UNITY_IPHONE
//	public static string LEADERBOARD_ID = "com.linestop.leaderboard";
//	#endif

	public static float LEVEL_1_TO_10_SPEED                    = 5.0f;
	public static float LEVEL_11_TO_20_SPEED                   = 5.5f;
	public static float LEVEL_21_TO_30_SPEED                   = 6.0f;
	public static float LEVEL_31_TO_40_SPEED                   = 6.5f;
	public static float LEVEL_41_TO_50_SPEED                   = 7.0f;
	public static float LEVEL_51_TO_60_SPEED                   = 7.5f;
	public static float LEVEL_61_TO_70_SPEED                   = 8.0f;
	public static float LEVEL_71_TO_80_SPEED                   = 8.5f;
	public static float LEVEL_81_TO_90_SPEED                   = 9.0f;
	public static float LEVEL_91_TO_100_SPEED                  = 9.5f;
	public static float LEVEL_101_TO_120_SPEED                 = 10.0f;
	public static float LEVEL_121_TO_140_SPEED                 = 10.5f;
	public static float LEVEL_141_TO_160_SPEED                 = 11.0f;
	public static float LEVEL_161_TO_180_SPEED                 = 11.5f;
	public static float LEVEL_181_TO_200_SPEED                 = 12.0f;
//
	public static float LEVEL_201_TO_220_SPEED                 = 12.5f;
	public static float LEVEL_221_TO_240_SPEED                 = 13.0f;
	public static float LEVEL_241_TO_260_SPEED                 = 14.5f;
	public static float LEVEL_261_TO_280_SPEED                 = 15.0f;
	public static float LEVEL_281_TO_300_SPEED                 = 15.5f;
//	public static float LEVEL_201_TO_210_SPEED                 = 10.0f;
//	public static float LEVEL_211_TO_220_SPEED                 = 10.3f;
//	public static float LEVEL_221_TO_230_SPEED                 = 10.5f;
//	public static float LEVEL_231_TO_240_SPEED                 = 10.8f;
//	public static float LEVEL_241_TO_250_SPEED                 = 11.0f;
//	public static float LEVEL_251_TO_260_SPEED                 = 11.3f;
//	public static float LEVEL_261_TO_270_SPEED                 = 11.5f;
//	public static float LEVEL_271_TO_280_SPEED                 = 11.8f;
//	public static float LEVEL_281_TO_290_SPEED                 = 12.0f;
//	public static float LEVEL_291_TO_300_SPEED                 = 12.3f;
//	public static float LEVEL_161_TO_170_SPEED                 = 9.3f;
//	public static float LEVEL_171_TO_180_SPEED                 = 9.6f;
//	public static float LEVEL_181_TO_190_SPEED                 = 9.9f;
//	public static float LEVEL_191_TO_200_SPEED                 = 10.2f;
//
//	public static float LEVEL_201_TO_210_SPEED                 = 10.5f;
//	public static float LEVEL_211_TO_220_SPEED                 = 10.8f;
//	public static float LEVEL_221_TO_230_SPEED                 = 11.1f;
//	public static float LEVEL_231_TO_240_SPEED                 = 11.4f;
//	public static float LEVEL_241_TO_250_SPEED                 = 11.7f;
//	public static float LEVEL_251_TO_260_SPEED                 = 12.0f;
//	public static float LEVEL_261_TO_270_SPEED                 = 12.3f;
//	public static float LEVEL_271_TO_280_SPEED                 = 12.6f;
//	public static float LEVEL_281_TO_290_SPEED                 = 12.9f;
//	public static float LEVEL_291_TO_300_SPEED                 = 13.2f;

	public static readonly List<float> LEVEL_SPEEDS            = new List<float> {
		LEVEL_1_TO_10_SPEED, 
		LEVEL_11_TO_20_SPEED,
		LEVEL_21_TO_30_SPEED,
		LEVEL_31_TO_40_SPEED,
		LEVEL_41_TO_50_SPEED,
		LEVEL_51_TO_60_SPEED,
		LEVEL_61_TO_70_SPEED,
		LEVEL_71_TO_80_SPEED,
		LEVEL_81_TO_90_SPEED,
		LEVEL_91_TO_100_SPEED,
		LEVEL_101_TO_120_SPEED,
		LEVEL_121_TO_140_SPEED,
		LEVEL_141_TO_160_SPEED,
		LEVEL_161_TO_180_SPEED,
		LEVEL_181_TO_200_SPEED,
		LEVEL_201_TO_220_SPEED,
		LEVEL_221_TO_240_SPEED,
		LEVEL_241_TO_260_SPEED,
		LEVEL_261_TO_280_SPEED,
		LEVEL_281_TO_300_SPEED
//		LEVEL_201_TO_210_SPEED,
//		LEVEL_211_TO_220_SPEED,
//		LEVEL_221_TO_230_SPEED,
//		LEVEL_231_TO_240_SPEED,
//		LEVEL_241_TO_250_SPEED,
//		LEVEL_251_TO_260_SPEED,
//		LEVEL_261_TO_270_SPEED,
//		LEVEL_271_TO_280_SPEED,
//		LEVEL_281_TO_290_SPEED,
//		LEVEL_291_TO_300_SPEED

	};
}
