using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабиринт
{
    class MainClass
    {
        public Lab lab;

        public int countW = 0;

        public Point playerVector;
        public Point currentCoord;
        public Point exitVector;
        public Point exitCoord;


        public void Generate(string firstFlank, string secondFlank)
        {
            this.countW = firstFlank.Count(x => x == 'W') + secondFlank.Count(x => x == 'W');
            lab = new Lab(this.countW);
            playerVector = new Point(0, 1);
            currentCoord = new Point(lab.size / 2, 0);
            RunnerGenerator(firstFlank.Substring(1));
            playerVector = exitVector;
            currentCoord = exitCoord;
            RunnerGenerator(secondFlank.Substring(1));
        }

        public void RunnerGenerator(string flank)
        {
            while (flank.Length > 0)
            {
                var isRotation = false;
                var reversedVector1 = new Point(-playerVector.dl, -playerVector.shir);
                CLoseSideByDirection(lab.arr[currentCoord.shir, currentCoord.dl], reversedVector1, newValue: true);

                while (flank[0] != 'W')
                {
                    isRotation = true;
                    switch (flank[0])
                    {
                        case 'R':
                            RotateCellRight(lab.arr[currentCoord.shir, currentCoord.dl], playerVector);
                            playerVector.StrRight();
                            break;
                        case 'L':
                            RotateCellLeft(lab.arr[currentCoord.shir, currentCoord.dl], playerVector);
                            playerVector.StrLeft();
                            break;
                    }
                    flank = flank.Substring(1);
                }

                if (!isRotation)
                {
                    RotateCellForward(lab.arr[currentCoord.shir, currentCoord.dl], playerVector);
                }

                if (flank.Length == 1)
                {
                    exitCoord = new Point(currentCoord.dl, currentCoord.shir);
                    exitVector = new Point(-playerVector.dl, -playerVector.shir);
                    break;
                }

                currentCoord.dl = currentCoord.dl + playerVector.dl;
                currentCoord.shir = currentCoord.shir + playerVector.shir;



                flank = flank.Substring(1);
            }
        }

        public string GetLabEncryption()
        {
            return lab.Shifr_Cells();
        }

        private void RotateCellRight(Cell cell, Point directionVector)
        {
            CLoseSideByDirection(cell, directionVector);
            RotateCellForward(cell, directionVector);
        }

        private void RotateCellLeft(Cell cell, Point directionVector)
        {
        }

        private void RotateCellForward(Cell cell, Point directionVector)
        {
            var bufVector = new Point(directionVector.dl, directionVector.shir);
            bufVector.StrLeft();
            CLoseSideByDirection(cell, bufVector);
        }

        private void CLoseSideByDirection(Cell cell, Point directionVector, bool newValue = false)
        {
            if (cell.condition == 1)
                return;
            if (directionVector.shir == 1 && directionVector.dl == 0)
                cell.bottomWall = newValue;
            else if (directionVector.shir == -1 && directionVector.dl == 0)
                cell.topWall = newValue;
            else if (directionVector.shir == 0 && directionVector.dl == 1)
                cell.rightWall = newValue;
            else if (directionVector.shir == 0 && directionVector.dl == -1)
                cell.leftWall = newValue;
        }
    }
}
