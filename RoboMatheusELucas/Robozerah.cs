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
        public override void Run()
        {
            SetColors(Color.Black, Color.Silver, Color.Red);

            while (true)
            {
                TurnRadarRight(360);
                Ahead(100);
                Back(100);

            }
        }
        public override void OnHitByBullet(HitByBulletEvent e)
        {
            TurnRight(60);
            Ahead(20);

        }
        public override void OnHitRobot(HitRobotEvent inimigo)
        {
            TurnRight(inimigo.Bearing);
            Fire(3);

        }


        public override void OnHitWall(HitWallEvent e)
        {
            Ahead(200);
            TurnLeft(180);
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            mira(e.Bearing);
            Fire(1);

            if (e.Energy < 12)
            {
                tiroFatal(e.Energy);
            }
            else
            {
                Fire(1);
            }

            fogo(e.Distance);

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

        public void tiroFatal(double EnergiaIni)
        {
            double Tiro = (EnergiaIni / 4) + .1;
            Fire(Tiro);

        }

        public void fogo(double Distancia)
        {
            if (Distancia > 200 || Energy < 15)
            {
                Fire(1);
            }
            else if (Distancia > 50)
            {
                Fire(2);
            }
            else
            {
                Fire(3);
            }
        }


    }
}
    
