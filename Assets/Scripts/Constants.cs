using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Constants
    {

        //CUBES GEN

        /*---Position---*/
        public static readonly float distance_Z_betweenCubes = 2f;
        public static readonly float distance_X_betweenCubes = 1.6f;

        /*---Probabilty of creation---*/
        public static readonly int probabilityCubeCreation = 2; // 1/probabilty each second

        //CANON

        /*---Movement---*/
        public static readonly float canonSpeed = 95400f;
        /*---Bullet---*/
        public static readonly float bulletSpeed = 10f;
        public static readonly float spawnBulletPositionLeft = -0.7f;
        public static readonly float spawnBulletPositionRight = 0.7f;
        /*---Dash---*/
        public static readonly float dashSpeed = 200f;
        public static readonly float InvicibiltyDelay = 0.5f;
        public static readonly float coolDownDash = 4f;

        //SHOP

        /*---Prices---*/
        public static readonly int newWeaponPrice = 0;
        public static readonly int armorPrice = 0;

        /*---Shield_Color---*/
        public static Color32 ShieldColor()
        {
            return new Color32(157, 197, 227, 155);
        }

        //CUBES

        /*---Life---*/
        public static readonly int greenCubeLife = 1;
        public static readonly int orangeCubeLife = 3;
        public static readonly int redCubeLife = 10;

        /*---Gold---*/
        public static readonly int greenCubeGold = 10;
        public static readonly int orangeCubeGold = 30;
        public static readonly int redCubeGold = 100;

        /*---XP---*/
        public static readonly int greenCubeXP = 1;
        public static readonly int orangeCubeXP = 2;
        public static readonly int redCubeXP = 5;

        /*---Color---*/
        public static Color32 GetCubeColor(string color)
        {
            switch (color)
            {
                case "green":
                    return new Color32(0, 255, 0, 0);
                case "orange":
                    return new Color32(255, 155, 0, 0);
                case "red":
                    return new Color32(255, 0, 0, 0);

                default: return new Color32(0, 0, 0, 0);
            }
        }
        /*---Bullet---*/
        public static readonly float speed = -2f;
        public static readonly int probabilityBullet = 4; // 1/probabilty each second

        //GAME

        public static readonly float gameOverDelay = 0.5f;
        public static readonly float MaxTime = 10f;

        //LIST OF VARIABLES IN MEMORY

        //life
        //gold
        //score
        //MaxScore
        //xp
        //newWeaponBool
        //armorBool
        //DashActivated

        //GET OR SET VALUE IN MEMORY
        public static int GetValueInMemory(string value)
        {
            return PlayerPrefs.GetInt(value);
        }
        public static void SetValueInMemory(string valueName, int value)
        {
            PlayerPrefs.SetInt(valueName, value);
        }
        
        //Speed Increasing camera and canon --> go see in CameraMovement.cs and CanonMovement.cs



    }
}
