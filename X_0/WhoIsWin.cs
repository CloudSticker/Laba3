using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_0
{
    class WhoIsWin
    {

        public int[] CheckTurn(int[,] arr)
        {
            int[] Ansarr = new int[] { 0, 0, 0, 0 };
            for (int i = 0; i <= arr.GetUpperBound(1); i++)
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    if (arr[i, j] != 0)
                        Ansarr = neighbors(arr, i, j);
                    for (int t = 0; t < 4; t++)
                        if (Ansarr[t] != 0)
                            return Ansarr;
                }
            return Ansarr;
        }

        public int[] neighbors(int[,] arr, int i1, int j1)
        {
            int[] Ansarr = new int[]{0, 0, 0, 0};
            int k = 0;

            //---------------------------------------------------- Проверка по горизонтали 

            for (int i = i1; i <= i1 + 4; i++)//Первая проверка
            { 
                if (i <= 9)
                {
                    if (arr[i, j1] == arr[i1, j1])
                    {
                        k++;

                    }
                    else
                        break;

                }
            }
            
            if (k == 5)
            {
                Ansarr[0] = i1;
                Ansarr[1] = j1;
                Ansarr[2] = i1 + 4;
                Ansarr[3] = j1;
                return Ansarr;
            }
            else
            {
                k = 0;
                for (int i = i1; i >= i1 - 4; i--)//Вторая проверка
                {
                    if (i >= 0)
                    {
                        if (arr[i, j1] == arr[i1, j1])
                        {
                            k++;
                            
                        }
                        else
                            break;
                    }
                }
                if (k == 5)
                {
                    Ansarr[0] = i1;
                    Ansarr[1] = j1;
                    Ansarr[2] = i1 - 4;
                    Ansarr[3] = j1;
                    return Ansarr;
                }
                else
                {
                    k = 0;
                    for (int j = j1; j <= j1 + 4; j++)//Третья проверка
                    {
                        if (j <= 9)
                        {
                            if (arr[i1, j] == arr[i1, j1])
                            {
                                k++;
                            }
                            else
                                break;
                        }
                    }
                    if (k == 5)
                    {
                        Ansarr[0] = i1;
                        Ansarr[1] = j1;
                        Ansarr[2] = i1;
                        Ansarr[3] = j1 + 4;
                        return Ansarr;
                    }
                    else
                    {
                        k = 0;
                        for (int j = j1; j >= j1 - 4; j--)//Четвертая проверка
                        {
                            if (j >= 0)
                            {
                                if (arr[i1, j] == arr[i1, j1])
                                {
                                    k++;
                                }
                                else
                                    break;
                            }
                        }
                        if (k == 5)
                        {
                            Ansarr[0] = i1;
                            Ansarr[1] = j1;
                            Ansarr[2] = i1;
                            Ansarr[3] = j1 - 4;
                            return Ansarr;
                        }
                    }
                }
               
            }


            //---------------------------------------------------- Проверка по диагонали

            k = 0;
            for (int t = 0; t < 5; t++)//Первая проверка
            {
                
                if ((i1 + t >= 0) && (i1 + t <= 9) && (j1 + t >= 0) && (j1 + t <= 9))
                {
                    if (arr[i1 + t, j1 + t] == arr[i1, j1])
                    {
                        k++;
                    }
                    else
                        break;
                }
            }

            if (k == 5)
            {
                Ansarr[0] = i1;
                Ansarr[1] = j1;
                Ansarr[2] = i1 + 4;
                Ansarr[3] = j1 + 4;
                return Ansarr;
            }
            else
            {
                k = 0;
                for (int t = 0; t < 5; t++)//Вторая проверка
                {

                    if ((i1 + t >= 0) && (i1 + t <= 9) && (j1 - t >= 0) && (j1 - t <= 9))
                    {
                        if (arr[i1 + t, j1 - t] == arr[i1, j1])
                        {
                            k++;
                        }
                        else
                            break;
                    }
                }
                if (k == 5)
                {
                    Ansarr[0] = i1;
                    Ansarr[1] = j1;
                    Ansarr[2] = i1 + 4;
                    Ansarr[3] = j1 - 4;
                    return Ansarr;
                }
                else
                {
                    k = 0;
                    for (int t = 0; t < 5; t++)//Третья проверка
                    {

                        if ((i1 - t >= 0) && (i1 - t <= 9) && (j1 - t >= 0) && (j1 - t <= 9))
                        {
                            if (arr[i1 - t, j1 - t] == arr[i1, j1])
                            {
                                k++;
                            }
                            else
                                break;
                        }
                    }
                    if (k == 5)
                    {
                        Ansarr[0] = i1;
                        Ansarr[1] = j1;
                        Ansarr[2] = i1 - 4;
                        Ansarr[3] = j1 - 4;
                        return Ansarr;
                    }
                    else
                    {
                        k = 0;
                        for (int t = 0; t < 5; t++)//Четвёртая проверка
                        {

                            if ((i1 - t >= 0) && (i1 - t <= 9) && (j1 + t >= 0) && (j1 + t <= 9))
                            {
                                if (arr[i1 - t, j1 + t] == arr[i1, j1])
                                {
                                    k++;
                                }
                                else
                                    break;
                            }
                        }
                        if (k == 5)
                        {
                            Ansarr[0] = i1;
                            Ansarr[1] = j1;
                            Ansarr[2] = i1 - 4;
                            Ansarr[3] = j1 + 4;
                            return Ansarr;
                        }
                    }
                }
            }
            return Ansarr;
        }
    }
}
