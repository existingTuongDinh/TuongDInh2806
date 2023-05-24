using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualization
{
    interface ISortEngine
    {
        void DoWork(int[] TheArray, Graphics g, int MaxVal);
    }
    
        class BubbleSortEngine : ISortEngine
        {

            private bool _sorted = false;
            private int[] TheArray;
            private int[] MaxVal;
            private Graphics g;
            Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            public void DoWork(int[] TheArray, Graphics g, int MaxVal)
            {
                this.TheArray = TheArray;
                this.g = g;
                this.MaxVal = new[] { MaxVal };
                double temp;

                while (!_sorted)
                {
                    for (int i = 0; i < TheArray.Length-1; i++)
                    {
                        if (TheArray[i] > TheArray[i + 1])
                        {
                            Swap(i, i + 1);
                        }
                    }
                    _sorted = IsSorted();
                }
            }
            private bool IsSorted()
            {
                for (int i = 0; i < TheArray.Length - 1; i++)
                {
                    if (TheArray[i] < TheArray[i + 1]) return false;
                }
                return true;
            }
            private void Swap(int i, int j)
            {
                int temp = TheArray[i];
                TheArray[i] = TheArray[j];
                TheArray[j] = temp;

                g.FillRectangle(BlackBrush, i, 0, 1, MaxVal[0]);
                g.FillRectangle(BlackBrush, j, 0, 1, MaxVal[0]);

                g.FillRectangle(WhiteBrush, i, MaxVal[0] - TheArray[i], 1, MaxVal[0]);
                g.FillRectangle(WhiteBrush, j, MaxVal[0] - TheArray[j], 1, MaxVal[0]);


            }
        }
    
}
