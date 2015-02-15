using System;
public static class Constants {

	public const string COIN = "coin";
	public const string OBSTACLE = "obstacle";
	public const string COINDOUBLER = "coindoubler";
	public const string MAGNET = "magnet";
	public const string CANON_RIDE = "canonride";
	public const string ROCKET = "rocket";
	public const string FLYING_HELMET = "flyinghelmet";
	public const string SPEED_SLOWER = "speedslower";
	public const string SHEILD = "sheild";
	public const string PARACHUTE_HEALTH_INCREMENT =  "parahealthinc";
	public const string PARACHUTE_HEALTH_DECREMENT =  "parahealthdec";
	public const float LEFT_BOUNDRY_TRANSFORM_X =  -3.5f;
	public const float RIGHT_BOUNDRY_TRANSFORM_X = 3.5f;
	public const int COIN_SPAWN_LIMIT_LEFT = -2;
	public const int COIN_SPAWN_LIMIT_RIGHT = 2;
	public const float DEFAULT_POWER_UP_TIMER = 30.0f;
	public const float DEFAULT_PARACHUTE_SIZE_DELTA_DECREMENT = 0.005f;
	public const float DEFAULT_PARACHUTE_SIZE_DELTA_INCREMENT = 0.001f;
	public const float DEFAULT_SLOW_DRAG = 5.0f;
	public const float DEFAULT_FAST_DRAG =0.9f;
	public const float DEFAULT_HARD_DRAG = 0.8f;
	public const float DEFAULT_HARDER_DRAG = 0.7f;
	public const float DEFAULT_HARDEST_DRAG = 0.6f;
	public const string UPDATEJSONFILE = "Json/Updates";
	public const int UPDATELEVEL1 = 1;
	public const int UPDATELEVEL2 = 2;
	public const int UPDATELEVEL3 = 3;
	public const int UPDATELEVEL4 = 4;
	public const int UPDATELEVEL5 = 5;
	public const int MAX_LEVEL = 5;
	public const string SCORE = "score";

}
public static class PersistentStore {

	public const string COIN = "persistentcoin";
	public const string PARAHEALTH_LEVEL = "parahealthlevel";
	public const string EXTRA_LIFE = "extralife";
	public const string MAGNET_LEVEL =  "magnetlevel";
	public const string COIN_DOUBLER_LEVEL = "coindoublerlevel";
	public const string CANON_RIDE_LEVEL = "canonridelevel";
	public const string ROCKET_LEVEL = "rocketlevel";
	public const string FLYING_HELMET_LEVEL = "flyinghelmetlevel";
	public const string SPEED_SLOWER_LEVEL = "speedslowerlevel";
	public const string SHEILD_LEVEL = "sheildlevel";
	public const string LEVEL = "level";
	
}
