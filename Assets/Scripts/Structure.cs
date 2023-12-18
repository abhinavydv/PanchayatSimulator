using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Structure
{
    public List<Point> points;
    public List<double> bbox;
    public int OBJECTID;
    public string GlobalID;
    public string Uniq_Id;
    public string State_Code;
    public string District_C;
    public string Tehsil_Cod;
    public string Block_Code;
    public string Village_Co;
    public string LGD_Code;
    public int Built_Up_A;
    public string Village_Na;
    public string Area_Desc;
    public string Name;
    public string Owner_Name;
    public string Property_I;
    public string Property_C;
    public double Area_Sqm;
    public int Roof_type;
    public int No_Floors;
    public string Remarks;
    public string Adl_Info;
    public double SHAPE_Leng;
    public double SHAPE_Area;
    public string GP_Code;
    public string GP_Nam;
    public string type;

    [Serializable]
    class BBox
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;
    }

    [Serializable]
    public class Point
    {
        public double x;
        public double y;
    }
}
