﻿using RageGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    static class LevelList
    {
        static List<ILevel> LevelLista = new List<ILevel> {  new Level1() , new Level2(), new Level3(), new Level4() ,null};
        static int ActualNum = 0;
        public static string[] Actual()
        {
            if (LevelLista[ActualNum] == null)
            {
                Fokepernyo.EndScreen();
            }
            return LevelLista[ActualNum].map();
        }
        public static string Music()
        {
            return LevelLista[ActualNum].music();
        }
        public static  void NextLevel()
        {
            ActualNum++;

        }
    }
}
