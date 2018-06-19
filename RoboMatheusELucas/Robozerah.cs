
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
            Ahead(100);
            TurnRight(90);
        }

        public override void OnHitRobot(HitRobotEvent e)
        {
            tiroFatal(e.Bearing);

        }

        public override void OnHitWall(HitWallEvent e)
        {
            Ahead(200);
            TurnLeft(180);
        }


        public override void OnScannedRobot(ScannedRobotEvent e)
        {

            double max = 100;

            if (e.Energy < max)
            {
                max = e.Energy;
                miraCanhao(e.Bearing, max, Energy);
            }
            else if (e.Energy >= max)
            {
                max = e.Energy;
                miraCanhao(e.Bearing, max, Energy);
            }
            else if (Others == 1)
            {
                max = e.Energy;
                miraCanhao(e.Bearing, max, Energy);
            }
        }

        public override void OnWin(WinEvent e)
        {
            risadinha();
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

        public void miraCanhao(double PosIni, double energiaIni, double minhaEnergia)
        {
            double Distancia = PosIni;
            double Coordenadas = Heading + PosIni - GunHeading;
            double PontoQuarenta = (energiaIni / 4) + .1;
            if (!(Coordenadas > -180 && Coordenadas <= 180))
            {
                while (Coordenadas <= -180)
                {
                    Coordenadas += 360;
                }
                while (Coordenadas > 180)
                {
                    Coordenadas -= 360;
                }
            }
            TurnGunRight(Coordenadas);

            if (Distancia > 200 || minhaEnergia < 15 || energiaIni > minhaEnergia)
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
    
