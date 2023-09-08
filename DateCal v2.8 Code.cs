using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCal_v2._8
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("When you write down the date please avoid using spacebar . and /\nAlso make sure to write day and the month as 2 digits and the year as 4 \n");
                int[] persianyears = new int[2816];
                int r = 0;
                int correct = 0;
                while (correct < 2816)
                {
                    if (r % 4 == 0)
                    {
                        for (int i = 0; i < 29; i++)
                        {
                            if (i == 0)
                            {
                                persianyears[correct] = 365;
                            }
                            if (i % 4 == 0 && i != 0)
                            {
                                persianyears[correct] = 366;
                            }
                            else
                            {
                                persianyears[correct] = 365;
                            }
                            correct++;
                        }
                        r = 1;
                    }
                    else
                    {
                        for (int e = 0; e < 33; e++)
                        {
                            if (e == 0)
                            {
                                persianyears[correct] = 365;
                            }
                            if (e % 4 == 0 && e != 0)
                            {
                                persianyears[correct] = 366;
                            }
                            else
                            {
                                persianyears[correct] = 365;
                            }
                            correct++;
                        }
                        r++;
                    }
                }
                int[] gregorianyears = new int[10000];
                for (int y = 0; y < 10000; y++)
                {
                    if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
                    {
                        gregorianyears[y] = 366;
                    }
                    else
                    {
                        gregorianyears[y] = 365;
                    }
                }
                int[] persianmonths = new int[] { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 30 };
                int[] persianmonthsnl = new int[] { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 };
                int[] gregorianmonthsleap = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int[] gregorianmonths = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                loop:
                Console.WriteLine("1- Convert a Gregorian date to a Persian date\n2- Convert Persian date to a Gregorian date\n3- Delta between two Gregorian dates\n4- Delta between two Persian dates\n5- To find Gregorian deadline date\n6- To find Persian deadline date\n");
                String u = Convert.ToString(Console.ReadLine());
                if (u == "")
                { 
                    goto loop;
                }
                int choosing = Convert.ToInt32(u);
                if (choosing == 1)
                {
                    run1:
                    Console.Write("\nEnter Gregorian date: ");
                    string gregoriandate = Convert.ToString(Console.ReadLine());
                    if (gregoriandate.Length < 8)
                    {
                        Console.Write("\nYour date is'nt in the right format, try again\n");
                        goto run1;
                    }
                    int gregoriandateday = Convert.ToInt16(Convert.ToString(gregoriandate[0])) * 10 + Convert.ToInt16(Convert.ToString(gregoriandate[1]));
                    int gregorianmonth = Convert.ToInt16(Convert.ToString(gregoriandate[2])) * 10 + Convert.ToInt16(Convert.ToString(gregoriandate[3]));
                    int gregorianyear = Convert.ToInt16(Convert.ToString(gregoriandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(gregoriandate[5])) * 100 + Convert.ToInt16(Convert.ToString(gregoriandate[6])) * 10 + Convert.ToInt16(Convert.ToString(gregoriandate[7]));
                    if (gregorianmonth > 12 || gregorianmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect month, try again\n");
                        goto run1;
                    }
                    else if ((gregoriandateday > gregorianmonthsleap[gregorianmonth-1] && gregorianyears[gregorianyear] == 366) || gregoriandateday < 1)
                    {
                        Console.Write("\nYou typed incorrect day, try again\n");
                        goto run1;
                    }
                    else if ((gregoriandateday > gregorianmonths[gregorianmonth-1] && gregorianyears[gregorianyear] == 365)  || gregoriandateday < 1)
                    {
                        Console.Write("\nYou typed incorrect day, try again\n");
                        goto run1;
                    }
                    if (gregorianyear > 3437)
                    {
                        Console.Write("\nYou typed incorrect year, try again\n");
                        goto run1;
                    }
                    for (int a = 0; a < gregorianyear; a++)
                    {
                        gregoriandateday += gregorianyears[a];
                    }
                    if ((gregorianyear % 4 == 0 && gregorianyear % 100 != 0) || gregorianyear % 400 == 0)
                    {
                        for (int b = 0; b < (gregorianmonth - 1); b++)
                        {
                            gregoriandateday += gregorianmonthsleap[b];
                        }
                    }
                    else
                    {
                        for (int b = 0; b < (gregorianmonth - 1); b++)
                        {
                            gregoriandateday += gregorianmonths[b];
                        }
                    }
                    int persianyear = 0;
                    int persianmonth = 1;
                    int persianday = gregoriandateday - 226896;
                    for (int i = 0; persianday > persianyears[i]; i++, persianyear++)
                    {
                        persianday -= persianyears[i];
                    }
                    for (int w = 0; persianday > persianmonths[w]; w++, persianmonth++)
                    {
                        persianday -= persianmonths[w];
                    }
                    Console.Write("\nThe Persian date is:  ");
                    Console.Write(Convert.ToString(persianday));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(persianmonth));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(persianyear));
                }
                if (choosing == 2)
                {
                    run2:
                    Console.Write("\nEnter Persian date:    ");
                    string persiandate = Convert.ToString(Console.ReadLine());
                    if (persiandate.Length < 8)
                    {
                        Console.Write("\nYour date is'nt in the right format, try again\n");
                        goto run2;
                    }
                    int persianday = Convert.ToInt16(Convert.ToString(persiandate[0])) * 10 + Convert.ToInt16(Convert.ToString(persiandate[1]));
                    int persianmonth = Convert.ToInt16(Convert.ToString(persiandate[2])) * 10 + Convert.ToInt16(Convert.ToString(persiandate[3]));
                    int persianyear = Convert.ToInt16(Convert.ToString(persiandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(persiandate[5])) * 100 + Convert.ToInt16(Convert.ToString(persiandate[6])) * 10 + Convert.ToInt16(Convert.ToString(persiandate[7]));
                    if (persianyear > 2815)
                    {
                        Console.Write("\nYou typed incorrect year, try again\n");
                        goto run2;
                    }   
                    if (persianmonth > 12 || persianmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect month, try again\n");
                        goto run2;
                    }
                    else if ((persianday > persianmonths[persianmonth-1] && persianyears[persianyear] == 366) || persianday < 1)
                    {
                        Console.Write("\nYou typed incorrect day, try again\n");
                        goto run2;
                    }
                    else if ((persianday > persianmonthsnl[persianmonth-1] && persianyears[persianyear] == 365) || persianday < 1)
                    {
                        Console.Write("\nYou typed incorrect day, try again\n");
                        goto run2;
                    }
                    for (int a2 = 0; a2 < persianyear; a2++)
                    {
                        persianday += persianyears[a2];
                    }
                    for (int b2 = 0; b2 < (persianmonth - 1); b2++)
                    {
                        persianday += persianmonths[b2];
                    }
                    int gregorianday = persianday + 226896;
                    int gregorianyear = 0;
                    for (int i = 0; gregorianday > gregorianyears[i]; i++, gregorianyear++)
                    {
                        gregorianday -= gregorianyears[i];
                    }
                    int gregorianmoth = 1;
                    if (gregorianyears[gregorianyear] == 366)
                    {
                        for (int w = 0; gregorianday > gregorianmonthsleap[w]; w++, gregorianmoth++)
                        {
                            gregorianday -= gregorianmonthsleap[w];
                        }
                    }
                    else
                    {
                        for (int w = 0; gregorianday > gregorianmonths[w]; w++, gregorianmoth++)
                        {
                            gregorianday -= gregorianmonths[w];
                        }
                    }
                    Console.Write("\nThe Gregorian date is: ");
                    Console.Write(Convert.ToString(gregorianday));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(gregorianmoth));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(gregorianyear));
                }
                if (choosing == 3)
                {
                    run3:
                    Console.Write("\nEnter start Gregorian date: ");
                    string startgregoriandate = Convert.ToString(Console.ReadLine());
                    if (startgregoriandate.Length < 8)
                    {
                        Console.Write("\nYour date is'nt in the right format, try again\n");
                        goto run3;
                    }
                    Console.Write("\nEnter end Gregorian date:   ");
                    string endgregoriandate = Convert.ToString(Console.ReadLine());
                    if (endgregoriandate.Length < 8)
                    {
                        Console.Write("\nYour date is'nt in the right format, try again\n");
                        goto run3;
                    }
                    int startday = Convert.ToInt16(Convert.ToString(startgregoriandate[0])) * 10 + Convert.ToInt16(Convert.ToString(startgregoriandate[1]));
                    int startmonth = Convert.ToInt16(Convert.ToString(startgregoriandate[2])) * 10 + Convert.ToInt16(Convert.ToString(startgregoriandate[3]));
                    int startyear = Convert.ToInt16(Convert.ToString(startgregoriandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(startgregoriandate[5])) * 100 + Convert.ToInt16(Convert.ToString(startgregoriandate[6])) * 10 + Convert.ToInt16(Convert.ToString(startgregoriandate[7]));
                    int endday = Convert.ToInt16(Convert.ToString(endgregoriandate[0])) * 10 + Convert.ToInt16(Convert.ToString(endgregoriandate[1]));
                    int endmonth = Convert.ToInt16(Convert.ToString(endgregoriandate[2])) * 10 + Convert.ToInt16(Convert.ToString(endgregoriandate[3]));
                    int endyear = Convert.ToInt16(Convert.ToString(endgregoriandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(endgregoriandate[5])) * 100 + Convert.ToInt16(Convert.ToString(endgregoriandate[6])) * 10 + Convert.ToInt16(Convert.ToString(endgregoriandate[7]));
                    if (startmonth > 12 || startmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect start month, try again\n");
                        goto run3;
                    }
                    else if ((startday > gregorianmonthsleap[startmonth-1] && gregorianyears[startyear] == 366) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run3;
                    }
                    else if ((startday > gregorianmonths[startmonth-1] && gregorianyears[startyear] == 365) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run3;
                    }
                    if (endmonth > 12 || endmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect end month, try again\n");
                        goto run3;
                    }
                    else if ((endday > gregorianmonthsleap[endmonth-1] && gregorianyears[endyear] == 366) || endday < 1)
                    {
                        Console.Write("\nYou typed incorrect end day, try again\n");
                        goto run3;
                    }
                    else if ((endday > gregorianmonths[endmonth-1] && gregorianyears[endyear] == 365) || endday < 1)
                    {
                        Console.Write("\nYou typed incorrect end day, try again\n");
                        goto run3;
                    }
                    int deltaday = endday - startday;
                    int deltamonth = endmonth - startmonth;
                    int deltayear = endyear - startyear;
                    if (deltaday < 0)
                    {
                        if (gregorianyears[startyear] == 365)
                        {
                            deltaday += gregorianmonths[startmonth];
                            deltamonth--;
                        }
                        else
                        {
                            deltaday += gregorianmonthsleap[startmonth];
                            deltamonth--;
                        }
                    }
                    if (deltamonth < 0)
                    {
                        deltamonth += 12;
                        deltayear--;
                    }
                    int deltamonthcount = deltamonth + 12 * deltayear;
                    for (int a = 0; a < startyear; a++)
                    {
                        startday += gregorianyears[a];
                    }
                    if ((startyear % 4 == 0 && startyear % 100 != 0) || startyear % 400 == 0)
                    {
                        for (int b = 0; b < (startmonth - 1); b++)
                        {
                            startday += gregorianmonthsleap[b];
                        }
                    }
                    else
                    {
                        for (int b = 0; b < (startmonth - 1); b++)
                        {
                            startday += gregorianmonths[b];
                        }
                    }
                    for (int a = 0; a < endyear; a++)
                    {
                        endday += gregorianyears[a];
                    }
                    if ((endyear % 4 == 0 && endyear % 100 != 0) || endyear % 400 == 0)
                    {
                        for (int b = 0; b < (endmonth - 1); b++)
                        {
                            endday += gregorianmonthsleap[b];
                        }
                    }
                    else
                    {
                        for (int b = 0; b < (endmonth - 1); b++)
                        {
                            endday += gregorianmonths[b];
                        }
                    }
                    if (startday > endday)
                    {
                        int j = startday;
                        startday = endday;
                        endday = j;
                    }
                    Console.Write("\nThe delta in days:                                    ");
                    Console.WriteLine(Convert.ToString(endday - startday));
                    if (((endday - startday) / 7) > 0)
                    {
                        Console.Write("\nThe delta in weeks & days:                        ");
                        Console.Write(Convert.ToString((endday - startday) / 7));
                        Console.Write("   ");
                        Console.WriteLine(Convert.ToString(endday - startday - ((endday - startday) / 7) * 7));
                    }
                    if (deltamonthcount > 0)
                    {
                        Console.Write("\nThe delta in months, weeks & days:            ");
                        Console.Write(Convert.ToString(deltamonthcount));
                        Console.Write("   ");
                        Console.Write(Convert.ToString(deltaday / 7));
                        Console.Write("   ");
                        Console.WriteLine(Convert.ToString(deltaday - ((deltaday / 7) * 7)));
                    }
                    if (deltayear > 0)
                    {
                        Console.Write("\nThe delta in years, months, weeks & days:  ");
                        Console.Write(Convert.ToString(deltayear));
                        Console.Write("   ");
                        Console.Write(Convert.ToString(deltamonth));
                        Console.Write("   ");
                        Console.Write(Convert.ToString(deltaday / 7));
                        Console.Write("   ");
                        Console.WriteLine(Convert.ToString(deltaday - ((deltaday / 7) * 7)));
                    }
                }
                if (choosing == 4)
                {
                    run4:
                    Console.Write("\nEnter start Persian date: ");
                    string startpersiandate = Convert.ToString(Console.ReadLine());
                    if (startpersiandate.Length < 8)
                    {
                        Console.Write("\nYour date is'nt in the right format, try again\n");
                        goto run4;
                    }
                    Console.Write("\nEnter end Persian date:   ");
                    string endpersiandate = Convert.ToString(Console.ReadLine());
                    if (endpersiandate.Length < 8)
                    {
                        Console.Write("\nYour date is'nt in the right format, try again\n");
                        goto run4;
                    }
                    int startday = Convert.ToInt16(Convert.ToString(startpersiandate[0])) * 10 + Convert.ToInt16(Convert.ToString(startpersiandate[1]));
                    int startmonth = Convert.ToInt16(Convert.ToString(startpersiandate[2])) * 10 + Convert.ToInt16(Convert.ToString(startpersiandate[3]));
                    int startyear = Convert.ToInt16(Convert.ToString(startpersiandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(startpersiandate[5])) * 100 + Convert.ToInt16(Convert.ToString(startpersiandate[6])) * 10 + Convert.ToInt16(Convert.ToString(startpersiandate[7]));
                    int endday = Convert.ToInt16(Convert.ToString(endpersiandate[0])) * 10 + Convert.ToInt16(Convert.ToString(endpersiandate[1]));
                    int endmonth = Convert.ToInt16(Convert.ToString(endpersiandate[2])) * 10 + Convert.ToInt16(Convert.ToString(endpersiandate[3]));
                    int endyear = Convert.ToInt16(Convert.ToString(endpersiandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(endpersiandate[5])) * 100 + Convert.ToInt16(Convert.ToString(endpersiandate[6])) * 10 + Convert.ToInt16(Convert.ToString(endpersiandate[7]));
                    if (startyear > 2815)
                    {
                        Console.Write("\nYou typed incorrect year, try again\n");
                        goto run4;
                    }
                    if (startmonth > 12 || startmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect start month, try again\n");
                        goto run4;
                    }
                    else if ((startday > persianmonths[startmonth-1] && persianyears[startyear] == 366 ) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run4;
                    }
                    else if ((startday > persianmonthsnl[startmonth-1] && persianyears[startyear] == 365) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run4;
                    }
                    if (endyear > 2815)
                    {
                        Console.Write("\nYou typed incorrect year, try again\n");
                        goto run4;
                    }
                    if (endmonth > 12 || endmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect end month, try again\n");
                        goto run4;
                    }
                    else if ((endday > persianmonths[endmonth-1] && persianyears[endyear] == 366) || endday < 1)
                    {
                        Console.Write("\nYou typed incorrect end day, try again\n");
                        goto run4;
                    }
                    else if ((endday > persianmonthsnl[endmonth-1] && persianyears[endyear] == 365) || endday < 1)
                    {
                        Console.Write("\nYou typed incorrect end day, try again\n");
                        goto run4;
                    }
                    int deltaday = endday - startday;
                    int deltamonth = endmonth - startmonth;
                    int deltayear = endyear - startyear;
                    if (deltaday < 0)
                    {
                        deltaday += persianmonths[startmonth];
                        deltamonth--;
                    }
                    if (deltamonth < 0)
                    {
                        deltamonth += 12;
                        deltayear--;
                    }
                    int deltamonthcount = deltamonth + 12 * deltayear;
                    for (int a1 = 0; a1 < startyear; a1++)
                    {
                        startday += persianyears[a1];
                    }
                    for (int b1 = 0; b1 < (startmonth - 1); b1++)
                    {
                        startday += persianmonths[b1];
                    }
                    for (int x = 0; x < endyear; x++)
                    {
                        endday += persianyears[x];
                    }
                    for (int y = 0; y < (endmonth - 1); y++)
                    {
                        endday += persianmonths[y];
                    }
                    if (startday > endday)
                    {
                        int j = startday;
                        startday = endday;
                        endday = j;
                    }
                    Console.Write("\nThe delta in days:                                    ");
                    Console.WriteLine(Convert.ToString(endday - startday));
                    if (((endday - startday) / 7) > 0)
                    {
                        Console.Write("\nThe delta in weeks & days:                        ");
                        Console.Write(Convert.ToString((endday - startday) / 7));
                        Console.Write("   ");
                        Console.WriteLine(Convert.ToString(endday - startday - ((endday - startday) / 7) * 7));
                    }
                    if (deltamonthcount > 0)
                    {
                        Console.Write("\nThe delta in months, weeks & days:            ");
                        Console.Write(Convert.ToString(deltamonthcount));
                        Console.Write("   ");
                        Console.Write(Convert.ToString(deltaday / 7));
                        Console.Write("   ");
                        Console.WriteLine(Convert.ToString(deltaday - ((deltaday / 7) * 7)));
                    }
                    if (deltayear > 0)
                    {
                        Console.Write("\nThe delta in years, months, weeks & days:  ");
                        Console.Write(Convert.ToString(deltayear));
                        Console.Write("   ");
                        Console.Write(Convert.ToString(deltamonth));
                        Console.Write("   ");
                        Console.Write(Convert.ToString(deltaday / 7));
                        Console.Write("   ");
                        Console.WriteLine(Convert.ToString(deltaday - ((deltaday / 7) * 7)));
                    }
                }
                if (choosing == 5)
                {
                    run5:
                    Console.Write("\nEnter start Gregorian date: ");
                    string startgregoriandate = Convert.ToString(Console.ReadLine());
                    if (startgregoriandate.Length < 8)
                    {
                        Console.Write("\nYour date is'nt in the right format, try again\n");
                        goto run5;
                    }
                    Console.Write("\nEnter deadline duration:    ");
                    string o = Convert.ToString(Console.ReadLine());
                    if (o.Length < 1)
                    {
                        Console.Write("\nYou didn't wrote the duration, try again\n");
                        goto run5;
                    }
                    int duration = Convert.ToInt16(o);
                    int startday = Convert.ToInt16(Convert.ToString(startgregoriandate[0])) * 10 + Convert.ToInt16(Convert.ToString(startgregoriandate[1]));
                    int startmonth = Convert.ToInt16(Convert.ToString(startgregoriandate[2])) * 10 + Convert.ToInt16(Convert.ToString(startgregoriandate[3]));
                    int startyear = Convert.ToInt16(Convert.ToString(startgregoriandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(startgregoriandate[5])) * 100 + Convert.ToInt16(Convert.ToString(startgregoriandate[6])) * 10 + Convert.ToInt16(Convert.ToString(startgregoriandate[7]));
                    if (startmonth > 12 || startmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect start month, try again\n");
                        goto run5;
                    }
                    else if ((startday > gregorianmonthsleap[startmonth-1] && gregorianyears[startyear] == 366) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run5;
                    }
                    else if ((startday > gregorianmonths[startmonth-1] && gregorianyears[startyear] == 365) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run5;
                    }
                    for (int a = 0; a < startyear; a++)
                    {
                        startday += gregorianyears[a];
                    }
                    if ((startyear % 4 == 0 && startyear % 100 != 0) || startyear % 400 == 0)
                    {
                        for (int b = 0; b < (startmonth - 1); b++)
                        {
                            startday += gregorianmonthsleap[b];
                        }
                    }
                    else
                    {
                        for (int b = 0; b < (startmonth - 1); b++)
                        {
                            startday += gregorianmonths[b];
                        }
                    }
                    startday += duration;
                    int gregorianyear = 0;
                    try
                    {
                        for (int i = 0; startday > gregorianyears[i]; i++, gregorianyear++)
                        {
                            startday -= gregorianyears[i];
                        }
                    }
                    catch
                    {
                        Console.Write("\nYou typed incorrect duration , try again\n");
                        goto run5;
                    }
                    int gregorianmoth = 1;
                    if (gregorianyears[gregorianyear] == 366)
                    {
                        for (int w = 0; startday > gregorianmonthsleap[w]; w++, gregorianmoth++)
                        {
                            startday -= gregorianmonthsleap[w];
                        }
                    }
                    else
                    {
                        for (int w = 0; startday > gregorianmonths[w]; w++, gregorianmoth++)
                        {
                            startday -= gregorianmonths[w];
                        }
                    }
                    Console.Write("\nThe deadline date is:       ");
                    Console.Write(Convert.ToString(startday));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(gregorianmoth));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(gregorianyear));
                }
                if (choosing == 6)
                {
                    run6:
                    Console.Write("\nEnter start Persian date: ");
                    string startpersiandate = Convert.ToString(Console.ReadLine());
                    Console.Write("\nEnter deadline duration:  ");
                    string o = Convert.ToString(Console.ReadLine());
                    if (o.Length < 1)
                    {
                        Console.Write("\nYou didn't wrote the duration, try again\n");
                        goto run6;
                    }
                    int duration = Convert.ToInt16(o);
                    int startday = Convert.ToInt16(Convert.ToString(startpersiandate[0])) * 10 + Convert.ToInt16(Convert.ToString(startpersiandate[1]));
                    int startmonth = Convert.ToInt16(Convert.ToString(startpersiandate[2])) * 10 + Convert.ToInt16(Convert.ToString(startpersiandate[3]));
                    int startyear = Convert.ToInt16(Convert.ToString(startpersiandate[4])) * 1000 + Convert.ToInt16(Convert.ToString(startpersiandate[5])) * 100 + Convert.ToInt16(Convert.ToString(startpersiandate[6])) * 10 + Convert.ToInt16(Convert.ToString(startpersiandate[7]));
                    if (startyear > 2815)
                    {
                        Console.Write("\nYou typed incorrect year, try again\n");
                        goto run6;
                    }
                    if (startmonth > 12 || startmonth < 1)
                    {
                        Console.Write("\nYou typed incorrect start month, try again\n");
                        goto run6;
                    }
                    else if ((startday > persianmonths[startmonth-1] && persianyears[startyear] == 366) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run6;
                    }
                    else if ((startday > persianmonthsnl[startmonth-1] && persianyears[startyear] == 365) || startday < 1)
                    {
                        Console.Write("\nYou typed incorrect start day, try again\n");
                        goto run6;
                    }
                    for (int p = 0; p < startyear; p++)
                    {
                        startday += persianyears[p];
                    }
                    for (int s = 0; s < (startmonth - 1); s++)
                    {
                        startday += persianmonths[s];
                    }
                    startday += duration;
                    int persianyear = 0;
                    int persianmonth = 1;
                    try
                    {
                        for (int i = 0; startday > persianyears[i]; i++, persianyear++)
                        {
                            startday -= persianyears[i];
                        }
                    }
                    catch
                    {
                        Console.Write("\nYou typed incorrect duration , try again\n");
                        goto run6;
                    }
                    for (int w = 0; startday > persianmonths[w]; w++, persianmonth++)
                    {
                        startday -= persianmonths[w];
                    }
                    Console.Write("\nThe deadline date is:     ");
                    Console.Write(Convert.ToString(startday));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(persianmonth));
                    Console.Write(" ");
                    Console.Write(Convert.ToString(persianyear));
                }
            Console.WriteLine("\n");
            goto loop;
        }
    }
}
