﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Sydney_Naylor_19013037
{
    class FactoryBuilding : Building // this building will create units
    {
        private FactoryType fType;
        private int productionSpeed;
        private int spawnPoint;

        enum FactoryType
        {
            MELEE,
            RANGED
        }
        public FactoryBuilding(int xB, int yB, string teamB) : base(xB, yB, 350, teamB, 'F')
        {
            if (yB >= Map.MAPSIZE - 1)
            {
                spawnPoint = yB - 1;
            }
            else
            {
                spawnPoint = yB + 1;
            }
            fType = (FactoryType)GameEngine.random.Next(0, 2);
            productionSpeed = GameEngine.random.Next(3, 7);
        }
        public FactoryBuilding(string values)
        {
            string[] parameters = values.Split(',');

            xB = int.Parse(parameters[1]);
            yB = int.Parse(parameters[2]);
            healthB = int.Parse(parameters[3]);
            maxHealthB = int.Parse(parameters[4]);
            fType = (FactoryType)int.Parse(parameters[5]);
            productionSpeed = int.Parse(parameters[6]);
            spawnPoint = int.Parse(parameters[7]);
            teamB = parameters[8];
            imageB = parameters[9][0];
            destroyedB = parameters[10] == "True" ? true : false;
        }

        public override void Destruction()  // for when the building gets destroyed
        {
            destroyedB = true;
            imageB = '_';
        }

        public override string Save()
        {
            return string.Format(
                 $"Factory, {xB}, {yB}, {healthB}, {maxHealthB}, {(int)fType}," +
                 $"{productionSpeed}, {spawnPoint}," +
                 $"{teamB}, {imageB}, {destroyedB}"
                                );
        }
        public Unit SpawnUnits()
        {
            Unit unit;
            if (fType == FactoryType.MELEE)
            {
                unit = new MeleeUnit(xB, spawnPoint, teamB);
            }
            else
            {
                unit = new RangedUnit(xB, spawnPoint, teamB);
            }
            return unit;
        }

        public int ProductionSpeed
        {
            get { return productionSpeed; }
        }
        public string GetFactoryTypeName()
        {
            return new string[] { "Melee", "Ranged" }[(int)fType];
        }
        public override string ToString()
        {
            return
            "----------------------------------------------" + Environment.NewLine +
            "Resource Building (" + imageB + "/" + teamB[0] + ")" + Environment.NewLine +
            "----------------------------------------------" + Environment.NewLine +
            "Type: " + GetFactoryTypeName() + Environment.NewLine +
            base.ToString() + Environment.NewLine;
        }

        //public override int XB
        //{
        //    get { return xB; }
        //    set { xB = value; }
        //}
        //public override int YB
        //{
        //    get { return yB; }
        //    set { yB = value; }
        //}
        //public override int HealthB
        //{
        //    get { return healthB; }
        //    set { healthB = value; }
        //}
        //public override int MaxHealthB
        //{
        //    get { return maxHealthB; }
        //}
        //public override string TeamB
        //{
        //    get { return teamB; }
        //}
        //public override char ImageB
        //{
        //    get { return imageB; }
        //}
        //public override bool Destroyed
        //{
        //    get { return destroyedB; }
        //}

    }
}
