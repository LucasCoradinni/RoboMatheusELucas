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
        private bool peek;
        private double moveAmount;

        public override void Run()
        {
            SetColors(Color.Black, Color.Silver, Color.Red);

            moveAmount = Math.Max(BattleFieldWidth, BattleFieldHeight);
            peek = false;

            TurnLeft(Heading % 90);
            Ahead(moveAmount);

            peek = true;
            TurnGunRight(90);
            TurnRight(90);

            while (true)
            {
                peek = true;
                Ahead(moveAmount);
                peek = false;
                TurnRight(90);
            }
        }


        public override void OnHitRobot(HitRobotEvent e)
        {
            if (e.Bearing > -10 && e.Bearing < 90)
            {
                Back(100);
            }
            else
            {
                Ahead(100);
            }
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
            if (!(Coordenadas > -90 && Coordenadas <= 180))
            {
                while (Coordenadas <= -90)
                {
                    Coordenadas += 180;
                }
                while (Coordenadas > 90)
                {
                    Coordenadas -= 180;
                }
            }
            TurnGunRight(90);

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


