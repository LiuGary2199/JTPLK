using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassyStud
{
    public static string EnzymeGoNss(double a)
    {
        return Math.Round(a, 1).ToString();
    }
    public static string EnzymeGoNss(double a, int digits)
    {
        return Math.Round(a, digits).ToString();
    }

    public static double Found(double a)
    {
        return Math.Round(a, 1);
    }

}
