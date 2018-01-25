/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Point {

  [MarshalAs(UnmanagedType.R4)]
  private float _x;
  [MarshalAs(UnmanagedType.R4)]
  private float _y;

  public float this[uint i] {
    get {
      switch (i) {
        case 0: return X;
        case 1: return Y;
        default: throw new System.IndexOutOfRangeException();
      }
    }
    set {
      switch (i) {
        case 0: X = value; break;
        case 1: Y = value; break;
        default: throw new System.IndexOutOfRangeException();
      }
    }
  }

  public float X {
    get { return this._x; }
    set { this._x = value; }
  }

  public float Y {
    get { return this._y; }
    set { this._y = value; }
  }

  public static Point Zero {
    get { return new Point(0.0f, 0.0f); }
  }

  public static Point XAxis {
    get { return new Point(1.0f, 0.0f); }
  }

  public static Point YAxis {
    get { return new Point(0.0f, 1.0f); }
  }

  public Point(float x, float y) {
    this._x = x;
    this._y = y;
  }

  public Point(Pointi point) : this((float)point.X, (float)point.Y) {
  }

  public Point(Size size) : this(size.Width, size.Height) {
  }

  public static Point operator+(Point v) {
    return v;
  }

  public static Point operator-(Point v) {
    return new Point(-v.X, -v.Y);
  }

  public static Point operator+(Point v0, Point v1) {
    return new Point(v0.X + v1.X, v0.Y + v1.Y);
  }

  public static Point operator-(Point v0, Point v1) {
    return new Point(v0.X - v1.X, v0.Y - v1.Y);
  }

  public static Point operator*(Point v, float f) {
    return new Point(v.X * f, v.Y * f);
  }

  public static Point operator*(float f, Point v) {
    return v * f;
  }

  public static Point operator/(Point v, float f) {
    if (f == 0.0f) { throw new System.DivideByZeroException(); }
    return new Point(v.X / f, v.Y / f);
  }

  public static bool operator==(Point v0, Point v1) {
    return v0.X == v1.X && v0.Y == v1.Y;
  }

  public static bool operator!=(Point v0, Point v1) {
    return !(v0 == v1);
  }

  public override bool Equals(System.Object obj) {
    return obj is Point && this == (Point)obj;
  }

  public bool Equals(Point v) {
    return this == v;
  }

  public override int GetHashCode() {
    return X.GetHashCode() ^ Y.GetHashCode();
  }

  public override string ToString() {
    return System.String.Format("{0},{1}", X, Y);
  }

  public static float LengthSquared(Point v) {
    return v.X * v.X + v.Y * v.Y;
  }

  public static float Length(Point v) {
    return (float)System.Math.Sqrt((double)LengthSquared(v));
  }

  public static Point Normalize(Point v) {
    return v / Length(v);
  }

  public static Point PerpendicularCCW(Point v) {
    return new Point(-v.Y, v.X);
  }

  public static Point PerpendicularCW(Point v) {
    return new Point(v.Y, -v.X);
  }

  public static Point Perpendicular(Point v, bool cw) {
    return cw ? PerpendicularCW(v) : PerpendicularCCW(v);
  }

  public static float Dot(Point v0, Point v1) {
    return v0.X * v1.X + v0.Y * v1.Y;
  }

  public static float PerpDot(Point v0, Point v1) {
    return v0.X * v1.Y - v0.Y * v1.X;
  }

  private static float Lerp(float x, float y, float t) {
    return x + t * (y - x);
  }

  public static Point Lerp(Point v0, Point v1, float t) {
    return new Point(Lerp(v0.X, v1.X, t), Lerp(v0.Y, v1.Y, t));
  }

  public static float SignedAngle(Point v0, Point v1) {
    return (float)System.Math.Atan2(PerpDot(v0, v1), Dot(v0, v1));
  }

  public static Point Parse(string str) {
    Point p;
    if (Point.TryParse(str, out p)) {
      return p;
    }
    throw new ArgumentException("Cannot create Point from '" + str + "'");
  }

  public static bool TryParse(string str, out Point result) {
    bool ret = NoesisGUI_PINVOKE.Point_TryParse(str != null ? str : string.Empty, out result);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

