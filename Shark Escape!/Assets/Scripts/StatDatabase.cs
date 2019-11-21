using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatDatabase : MonoBehaviour
{
    // A config file to configure all initialization stats that are called by most other scripts

    // Player stats
    public static int player_max_health = 30;
    public static float player_speed = 5f;
    public static float player_invin_frame = 1.5f;
    public static float player_attack_speed = 0.35f;

    // Camera variables
    public static float map_scrollspeed = 0.01f;

    // Top of Frame variables
    public static float frame_scrollspeed = 0.01f;

    // Player Info UI 
    public static float player_info_scrollspeed = 0.01f;    // scroll speed of Camera and PlayerInfoUI should be same.

    // Basic Enemy
    public static float enemy1_health = 30;
    public static int enemy1_points = 100;
    public static int enemy1_touchdamage = 10;
    public static float enemy1_speed = 1.0f;

    // Boss 1
    public static float boss1_health = 1000;
    public static int boss1_points = 10000;
    public static int boss1_touchdamage = 200;
    public static float boss1_speed = 1.0f;
    public static bool boss1_isAwake = false;
}
