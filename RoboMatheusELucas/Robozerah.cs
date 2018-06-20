using Robocode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboMatheusELucas
{
    public class Robozerah : AdvancedRobot
    {
        private bool espiar;
        private double mover;

        public override void Run()
        {
            SetColors(Color.Black, Color.Silver, Color.Gold);

            mover = Math.Max(BattleFieldWidth, BattleFieldHeight);
            espiar = false;

            TurnLeft(Heading % 90);
            Ahead(mover);

            espiar = true;
            TurnGunRight(90);
            TurnRight(90);

            while (true)
            {
                espiar = true;
                Ahead(mover);
                espiar = false;
                TurnRight(90);
            }
        }


        public override void OnHitRobot(HitRobotEvent e)
        {
            Fire(1);
            Execute();
        }
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            fogo(e.Bearing);
            Execute();

        }
        public override void OnWin(WinEvent e)
        {
            Ahead(100);
            risadinha();
            Execute();
        }

        public override void OnHitByBullet(HitByBulletEvent e)

        {
           

        }

        public void tiroFatal(double EnergiaIni)
        {
            double Tiro = (EnergiaIni / 4) + .1;
            Fire(Tiro);
            Execute();
        }

        public void fogo(double Distancia)
        {
            if (Distancia > 200 || Energy < 15)
            {
                Fire(1);
            }
            else if (Distancia > 30)
            {
                Fire(2);
            }
            else
            {
                Fire(3);
            }
        }
        public void risadinha()
        {
            for (int i = 0; i < 50; i++)
            {
                TurnRight(30);
                TurnLeft(30);
            }
        }

     

    }

}


