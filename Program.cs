using System;
using System.Collections.Generic;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(", ");
            int width = int.Parse(size[0]);
            int height = int.Parse(size[1]);
            List<string> grid = new List<string>();
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                grid.Add(line);
            }
            string[] data = Console.ReadLine().Split(", ");
            int xCoord = int.Parse(data[0]);
            int yCoord = int.Parse(data[1]);
            int N = int.Parse(data[2]);
            //1 0 1
            //0 1 0
            //1 1 1

            List<List<int>> firstGrid = new List<List<int>>();
            for (int i = 0; i < grid.Count; i++)
            {
                List<int> list = new List<int>();
                grid[i].ToCharArray();
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int temp = int.Parse(grid[i][j].ToString());
                    list.Add(temp);
                }
                firstGrid.Add(list);
            }
            int counter = 0;
            for (int i = 0; i <= N; i++)
            {
                Cell trackedCell = new Cell();
                trackedCell.cellValue = firstGrid[yCoord][xCoord];
                if (trackedCell.cellValue == 1)
                {
                    counter++;
                }
                List<List<int>> newGrid = new List<List<int>>();
                List<int> firstLine = new List<int>();
                List<int> newFirstLine = new List<int>();
                firstLine = firstGrid[0];
                Cell TopLeftCorner = new Cell();
                TopLeftCorner.cellValue = firstLine[0];
                TopLeftCorner.neighboursValue = firstLine[1] + firstGrid[1][0] + firstGrid[1][1];
                TopLeftCorner.cellValue = CellValue(TopLeftCorner.cellValue, TopLeftCorner.neighboursValue);
                newFirstLine.Add(TopLeftCorner.cellValue);

                for (int j = 1; j < firstLine.Count - 1; j++)
                {
                    Cell UpperSideCell = new Cell();
                    UpperSideCell.cellValue = firstLine[j];
                    UpperSideCell.neighboursValue = firstLine[j - 1] + firstLine[j + 1] + firstGrid[1][j - 1] + firstGrid[1][j] + firstGrid[1][j + 1];
                    UpperSideCell.cellValue = CellValue(UpperSideCell.cellValue, UpperSideCell.neighboursValue);
                    newFirstLine.Add(UpperSideCell.cellValue);
                }
                Cell TopRightCorner = new Cell();
                TopRightCorner.cellValue = firstLine[firstLine.Count - 1];
                TopRightCorner.neighboursValue = firstLine[firstLine.Count - 2] + firstGrid[1][firstLine.Count - 1] + firstGrid[1][firstLine.Count - 2];
                TopLeftCorner.cellValue = CellValue(TopRightCorner.cellValue, TopRightCorner.neighboursValue);
                newFirstLine.Add(TopRightCorner.cellValue);
                newGrid.Add(newFirstLine);
                for (int k = 1; k < firstGrid.Count - 1; k++)
                {
                    List<int> nextLine = new List<int>();
                    Cell leftCell = new Cell();
                    leftCell.cellValue = firstGrid[k][0];
                    leftCell.neighboursValue = firstGrid[k][1] + firstGrid[k - 1][0] + firstGrid[k - 1][1] + firstGrid[k + 1][0] + firstGrid[k + 1][1];
                    leftCell.cellValue = CellValue(leftCell.cellValue, leftCell.neighboursValue);
                    nextLine.Add(leftCell.cellValue);
                    for (int t = 1; t < firstLine.Count - 1; t++)
                    {
                        Cell innerCell = new Cell();
                        innerCell.cellValue = firstGrid[k][t];
                        innerCell.neighboursValue = firstGrid[k][t - 1] + firstGrid[k][t + 1] + firstGrid[k + 1][t - 1] + firstGrid[k + 1][t] + firstGrid[k + 1][t + 1] + firstGrid[k - 1][t - 1] + firstGrid[k - 1][t] + firstGrid[k - 1][t + 1];
                        innerCell.cellValue = CellValue(innerCell.cellValue, innerCell.neighboursValue);
                        nextLine.Add(innerCell.cellValue);

                    }
                    Cell rightCell = new Cell();
                    rightCell.cellValue = firstGrid[k][firstLine.Count - 1];
                    rightCell.neighboursValue = firstGrid[k][firstLine.Count - 2] + firstGrid[k + 1][firstLine.Count - 1] + firstGrid[k + 1][firstLine.Count - 2] + firstGrid[k - 1][firstLine.Count - 1] + firstGrid[k - 1][firstLine.Count - 2];
                    rightCell.cellValue = CellValue(rightCell.cellValue, rightCell.neighboursValue);
                    nextLine.Add(rightCell.cellValue);
                    newGrid.Add(nextLine);
                }
                List<int> newLastLine = new List<int>();
                Cell BottomLeftCorner = new Cell();
                BottomLeftCorner.cellValue = firstGrid[firstGrid.Count - 1][0];
                BottomLeftCorner.neighboursValue = firstGrid[firstGrid.Count - 1][1] + firstGrid[firstGrid.Count - 2][0] + firstGrid[firstGrid.Count - 2][1];
                BottomLeftCorner.cellValue = CellValue(BottomLeftCorner.cellValue, BottomLeftCorner.neighboursValue);
                newLastLine.Add(BottomLeftCorner.cellValue);
                for (int m = 1; m < firstLine.Count-1; m++)
                {
                    Cell BottomCell = new Cell();
                    BottomCell.cellValue = firstGrid[firstGrid.Count - 1][m];
                    BottomCell.neighboursValue = firstGrid[firstGrid.Count - 1][m - 1] + firstGrid[firstGrid.Count - 1][m + 1] + firstGrid[firstGrid.Count - 2][m - 1] + firstGrid[firstGrid.Count - 2][m + 1] + firstGrid[firstGrid.Count - 2][m];
                    BottomCell.cellValue = CellValue(BottomCell.cellValue, BottomCell.neighboursValue);
                    newLastLine.Add(BottomCell.cellValue);
                }
                Cell BottomRightCorner = new Cell();
                BottomRightCorner.cellValue = firstGrid[firstGrid.Count - 1][firstLine.Count - 1];
                BottomRightCorner.neighboursValue = firstGrid[firstGrid.Count - 1][firstLine.Count - 2] + firstGrid[firstGrid.Count - 2][firstLine.Count - 1] + firstGrid[firstGrid.Count - 2][firstLine.Count - 2];
                BottomRightCorner.cellValue = CellValue(BottomRightCorner.cellValue, BottomRightCorner.neighboursValue);
                newLastLine.Add(BottomRightCorner.cellValue);
                newGrid.Add(newLastLine);
             
                firstGrid = newGrid;
           

            }
            Console.WriteLine(counter);

        }
        static int CellValue(int cellValue, int neighboursValue)
        {
            if (cellValue == 1 && (neighboursValue == 2 || neighboursValue == 3 || neighboursValue == 6))
            {
                cellValue = 1;
            }
            else if (cellValue == 1 && !(neighboursValue == 2 || neighboursValue == 3 || neighboursValue == 6))
            {
                cellValue = 0;
            }
            else if (cellValue == 0 && (neighboursValue == 3 || neighboursValue == 6))
            {
                cellValue = 1;
            }
            else if (cellValue == 0 && !(neighboursValue == 3 || neighboursValue == 6))
            {
                cellValue = 0;
            }
            return cellValue;
        }

    }
    
    public class Cell
    {
        public int cellValue;
        public int neighboursValue;

    }

}
