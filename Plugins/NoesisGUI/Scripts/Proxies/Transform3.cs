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
public struct Transform3 {

  private Vector3 _r0;
  private Vector3 _r1;
  private Vector3 _r2;
  private Vector3 _r3;

  public Vector3 this[uint i] {
    get {
      switch (i) {
        case 0: return this._r0;
        case 1: return this._r1;
        case 2: return this._r2;
        case 3: return this._r3;
        default: throw new System.IndexOutOfRangeException();
      }
    }
    set {
      switch (i) {
        case 0: this._r0 = value; break;
        case 1: this._r1 = value; break;
        case 2: this._r2 = value; break;
        case 3: this._r3 = value; break;
        default: throw new System.IndexOutOfRangeException();
      }
    }
  }

  public static Transform3 Identity {
    get {
      return new Transform3(
        1.0f, 0.0f, 0.0f,
        0.0f, 1.0f, 0.0f,
        0.0f, 0.0f, 1.0f,
        0.0f, 0.0f, 0.0f);
    }
  }

  public Transform3(
    float m00, float m01, float m02,
    float m10, float m11, float m12,
    float m20, float m21, float m22,
    float m30, float m31, float m32) : this(
    new Vector3(m00, m01, m02),
    new Vector3(m10, m11, m12),
    new Vector3(m20, m21, m22),
    new Vector3(m30, m31, m32))
  {
  }

  public Transform3(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3) {
    this._r0 = v0;
    this._r1 = v1;
    this._r2 = v2;
    this._r3 = v3;
  }

  public static Transform3 operator*(Transform3 m, float f) {
    return new Transform3(m[0] * f, m[1] * f, m[2] * f, m[3] * f);
  }

  public static Transform3 operator*(float f, Transform3 m) {
    return m * f;
  }

  public static Transform3 operator/(Transform3 m, float f) {
    if (f == 0.0f) { throw new System.DivideByZeroException(); }
    return new Transform3(m[0] / f, m[1] / f, m[2] / f, m[3] / f);
  }

  public static Vector3 operator*(Vector3 v, Transform3 m) {
    return PointTransform(v, m);
  }

  public static Vector4 operator*(Vector4 v, Transform3 m) {
    return new Vector4(
      v[0] * m[0][0] + v[1] * m[1][0] + v[2] * m[2][0] + v[3] * m[3][0],
      v[0] * m[0][1] + v[1] * m[1][1] + v[2] * m[2][1] + v[3] * m[3][1],
      v[0] * m[0][2] + v[1] * m[1][2] + v[2] * m[2][2] + v[3] * m[3][2],
      v[3]);
  }

  public static Transform3 operator*(Transform3 m0, Transform3 m1) {
    return new Transform3(
      new Vector3(
        m0[0][0] * m1[0][0] + m0[0][1] * m1[1][0] + m0[0][2] * m1[2][0],
        m0[0][0] * m1[0][1] + m0[0][1] * m1[1][1] + m0[0][2] * m1[2][1],
        m0[0][0] * m1[0][2] + m0[0][1] * m1[1][2] + m0[0][2] * m1[2][2]),
      new Vector3(
        m0[1][0] * m1[0][0] + m0[1][1] * m1[1][0] + m0[1][2] * m1[2][0],
        m0[1][0] * m1[0][1] + m0[1][1] * m1[1][1] + m0[1][2] * m1[2][1],
        m0[1][0] * m1[0][2] + m0[1][1] * m1[1][2] + m0[1][2] * m1[2][2]),
      new Vector3(
        m0[2][0] * m1[0][0] + m0[2][1] * m1[1][0] + m0[2][2] * m1[2][0],
        m0[2][0] * m1[0][1] + m0[2][1] * m1[1][1] + m0[2][2] * m1[2][1],
        m0[2][0] * m1[0][2] + m0[2][1] * m1[1][2] + m0[2][2] * m1[2][2]),
      new Vector3(
        m0[3][0] * m1[0][0] + m0[3][1] * m1[1][0] + m0[3][2] * m1[2][0] + m1[3][0],
        m0[3][0] * m1[0][1] + m0[3][1] * m1[1][1] + m0[3][2] * m1[2][1] + m1[3][1],
        m0[3][0] * m1[0][2] + m0[3][1] * m1[1][2] + m0[3][2] * m1[2][2] + m1[3][2])
    );
  }

  public static bool operator==(Transform3 m0, Transform3 m1) {
    return m0[0] == m1[0] && m0[1] == m1[1] && m0[2] == m1[2] && m0[3] == m1[3];
  }

  public static bool operator!=(Transform3 m0, Transform3 m1) {
    return !(m0 == m1);
  }

  public override bool Equals(System.Object obj) {
    return obj is Transform3 && this == (Transform3)obj;
  }

  public bool Equals(Transform3 m) {
    return this == m;
  }

  public override int GetHashCode() {
    return ((this[0].GetHashCode() ^ this[1].GetHashCode()) ^ this[2].GetHashCode()) ^ this[3].GetHashCode();
  }

  public void SetUpper3x3(Matrix3 m) {
    this[0] = m[0];
    this[1] = m[1];
    this[2] = m[2];
  }

  public Matrix3 GetUpper3x3() {
    return new Matrix3(this[0], this[1], this[2]);
  }

  public void SetTranslation(Vector3 v) {
    this[3] = v;
  }

  public Vector3 GetTranslation() {
    return this[3];
  }

  public static Transform3 Scale(float scaleX, float scaleY, float scaleZ) {
    return new Transform3(
      scaleX, 0.0f, 0.0f,
      0.0f, scaleY, 0.0f,
      0.0f, 0.0f, scaleZ,
      0.0f, 0.0f, 0.0f);
  }

  public static Transform3 Trans(float transX, float transY, float transZ) {
    return new Transform3(
      1.0f, 0.0f, 0.0f,
      0.0f, 1.0f, 0.0f,
      0.0f, 0.0f, 1.0f,
      transX, transY, transZ);
  }

  public static Transform3 RotX(float radians) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
      1.0f, 0.0f, 0.0f,
      0.0f,   cs,   sn,
      0.0f,  -sn,   cs,
      0.0f, 0.0f, 0.0f);
  }

  public static Transform3 RotY(float radians) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
          cs, 0.0f,   sn,
        0.0f, 1.0f, 0.0f,
         -sn, 0.0f,   cs,
        0.0f, 0.0f, 0.0f);
  }

  public static Transform3 RotZ(float radians) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
        cs,   sn, 0.0f,
       -sn,   cs, 0.0f,
      0.0f, 0.0f, 1.0f,
      0.0f, 0.0f, 0.0f);
  }

  public static Transform3 Inverse(Transform3 m) {
    Matrix3 rotInv = Matrix3.Inverse(m.GetUpper3x3());
    Vector3 trans = new Vector3(
      -m[3][0] * rotInv[0][0] - m[3][1] * rotInv[1][0] - m[3][2] * rotInv[2][0],
      -m[3][0] * rotInv[0][1] - m[3][1] * rotInv[1][1] - m[3][2] * rotInv[2][1],
      -m[3][0] * rotInv[0][2] - m[3][1] * rotInv[1][2] - m[3][2] * rotInv[2][2]);
    return new Transform3(rotInv[0], rotInv[1], rotInv[2], trans);
  }

  public static Transform3 PreScale(float scaleX, float scaleY, float scaleZ, Transform3 m) {
    return new Transform3(
      m[0][0] * scaleX, m[0][1] * scaleX, m[0][2] * scaleX,
      m[1][0] * scaleY, m[1][1] * scaleY, m[1][2] * scaleY,
      m[2][0] * scaleZ, m[2][1] * scaleZ, m[2][2] * scaleZ,
               m[3][0],          m[3][1],          m[3][2]);
  }

  public static Transform3 PreTrans(float transX, float transY, float transZ, Transform3 m) {
    return new Transform3(
      m[0][0], m[0][1], m[0][2],
      m[1][0], m[1][1], m[1][2],
      m[2][0], m[2][1], m[2][2],
      m[3][0] + m[0][0] * transX + m[1][0] * transY + m[2][0] * transZ,
      m[3][1] + m[0][1] * transX + m[1][1] * transY + m[2][1] * transZ,
      m[3][2] + m[0][2] * transX + m[1][2] * transY + m[2][2] * transZ);
  }

  public static Transform3 PreRotX(float radians, Transform3 m) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
                          m[0][0],                     m[0][1],                     m[0][2],
      m[1][0] * cs + m[2][0] * sn, m[1][1] * cs + m[2][1] * sn, m[1][2] * cs + m[2][2] * sn,
      m[2][0] * cs - m[1][0] * sn, m[2][1] * cs - m[1][1] * sn, m[2][2] * cs - m[1][2] * sn,
                          m[3][0],                     m[3][1],                     m[3][2]);
  }

  public static Transform3 PreRotY(float radians, Transform3 m) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
      m[0][0] * cs + m[2][0] * sn, m[0][1] * cs + m[2][1] * sn, m[0][2] * cs + m[2][2] * sn,
                          m[1][0],                     m[1][1],                     m[1][2],
      m[2][0] * cs - m[0][0] * sn, m[2][1] * cs - m[0][1] * sn, m[2][2] * cs - m[0][2] * sn,
                          m[3][0],                     m[3][1],                     m[3][2]);
  }

  public static Transform3 PreRotZ(float radians, Transform3 m) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
      m[0][0] * cs + m[1][0] * sn, m[0][1] * cs + m[1][1] * sn, m[0][2] * cs + m[1][2] * sn,
      m[1][0] * cs - m[0][0] * sn, m[1][1] * cs - m[0][1] * sn, m[1][2] * cs - m[0][2] * sn,
                          m[2][0],                     m[2][1],                     m[2][2],
                          m[3][0],                     m[3][1],                     m[3][2]);
  }

  public static Transform3 PostScale(Transform3 m, float scaleX, float scaleY, float scaleZ) {
    return new Transform3(
      m[0][0] * scaleX, m[0][1] * scaleY, m[0][2] * scaleZ,
      m[1][0] * scaleX, m[1][1] * scaleY, m[1][2] * scaleZ,
      m[2][0] * scaleX, m[2][1] * scaleY, m[2][2] * scaleZ,
      m[3][0] * scaleX, m[3][1] * scaleY, m[3][2] * scaleZ);
  }

  public static Transform3 PostTrans(Transform3 m, float transX, float transY, float transZ) {
    return new Transform3(
               m[0][0],          m[0][1],          m[0][2],
               m[1][0],          m[1][1],          m[1][2],
               m[2][0],          m[2][1],          m[2][2],
      m[3][0] + transX, m[3][1] + transY, m[3][2] + transZ);
  }

  public static Transform3 PostRotX(Transform3 m, float radians) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
      m[0][0], m[0][1] * cs - m[0][2] * sn, m[0][2] * cs + m[0][1] * sn,
      m[1][0], m[1][1] * cs - m[1][2] * sn, m[1][2] * cs + m[1][1] * sn,
      m[2][0], m[2][1] * cs - m[2][2] * sn, m[2][2] * cs + m[2][1] * sn,
      m[3][0], m[3][1] * cs - m[3][2] * sn, m[3][2] * cs + m[3][1] * sn);
  }

  public static Transform3 PostRotY(Transform3 m, float radians) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
      m[0][0] * cs - m[0][2] * sn, m[0][1], m[0][2] * cs + m[0][0] * sn,
      m[1][0] * cs - m[1][2] * sn, m[1][1], m[1][2] * cs + m[1][0] * sn,
      m[2][0] * cs - m[2][2] * sn, m[2][1], m[2][2] * cs + m[2][0] * sn,
      m[3][0] * cs - m[3][2] * sn, m[3][1], m[3][2] * cs + m[3][0] * sn);
  }

  public static Transform3 PostRotZ(Transform3 m, float radians) {
    float cs = (float)System.Math.Cos(radians);
    float sn = (float)System.Math.Sin(radians);
    return new Transform3(
      m[0][0] * cs - m[0][1] * sn, m[0][1] * cs + m[0][0] * sn, m[0][2],
      m[1][0] * cs - m[1][1] * sn, m[1][1] * cs + m[1][0] * sn, m[1][2],
      m[2][0] * cs - m[2][1] * sn, m[2][1] * cs + m[2][0] * sn, m[2][2],
      m[3][0] * cs - m[3][1] * sn, m[3][1] * cs + m[3][0] * sn, m[3][2]);
  }

  public static Vector3 PointTransform(Vector3 v, Transform3 m) {
    return new Vector3(
      v[0] * m[0][0] + v[1] * m[1][0] + v[2] * m[2][0] + m[3][0],
      v[0] * m[0][1] + v[1] * m[1][1] + v[2] * m[2][1] + m[3][1],
      v[0] * m[0][2] + v[1] * m[1][2] + v[2] * m[2][2] + m[3][2]);
  }

  public static Vector3 VectorTransform(Vector3 v, Transform3 m) {
    return new Vector3(
      v[0] * m[0][0] + v[1] * m[1][0] + v[2] * m[2][0],
      v[0] * m[0][1] + v[1] * m[1][1] + v[2] * m[2][1],
      v[0] * m[0][2] + v[1] * m[1][2] + v[2] * m[2][2]);
  }

  public static void Decompose(Transform3 t,
    out float scaleX, out float scaleY, out float scaleZ,
    out float shearXY, out float shearXZ, out float shearZY,
    out float rotateX, out float rotateY, out float rotateZ,
    out float transX, out float transY, out float transZ) {
    Matrix3.Decompose(t.GetUpper3x3(),
      out scaleX, out scaleY, out scaleZ,
      out shearXY, out shearXZ, out shearZY,
      out rotateX, out rotateY, out rotateZ);
    transX = t[3][0];
    transY = t[3][1];
    transZ = t[3][2];
  }

}

}

