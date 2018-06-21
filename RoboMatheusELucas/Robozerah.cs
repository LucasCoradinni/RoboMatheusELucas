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
            
            while (true)
            {
                SetTurnRadarRight(360);
                espiar = true;
                Ahead(mover);
                espiar = false;
                TurnRight(90);
            }
        }
        public override void OnHitRobot(HitRobotEvent e)
        {
          Scan();
          if (Energy > 30)
          Fire(3);	

          espiar = true;			

         changuePosition();

         Ahead(100);
         Fire(3);
 
        }
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            mira(e.Bearing);
            fogo(e.Bearing);
        }

        public override void OnWin(WinEvent e)
        {
                 risadinha();
        }

        public override void OnHitByBullet(HitByBulletEvent e)

        {
            Ahead(50); 
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
        public void mira(double Adv)
        {
            double A = Heading + Adv - GunHeading;
            if (!(A > -180 && A <= 180))
            {
                while (A <= -180)
                {
                    A += 360;
                }
                while (A > 180)
                {
                    A -= 360;
                }
            }
            TurnGunRight(A);
        }

        public void changuePosition()
        {

            Ahead(mover);
            TurnLeft(90);
        }

    }

}


