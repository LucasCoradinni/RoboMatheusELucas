
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
        int shots = 0;
        int a = 0;
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
            Ahead(100);
            TurnRight(90);
        }

        public override void OnHitRobot(HitRobotEvent inimigo)
        {
            Ahead(100);
            TurnRight(90);

        }

        public override void OnHitWall(HitWallEvent e)
        {
            Ahead(200);
            TurnLeft(180);
        }

        
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            mira(e.Bearing);
            fogo(e.Distance);
        }
        
        public override void OnWin(WinEvent e)
        {
            risadinha();
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
    
