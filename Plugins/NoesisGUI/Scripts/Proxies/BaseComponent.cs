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

public partial class BaseComponent {
  protected HandleRef swigCPtr;

  internal static BaseComponent CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new BaseComponent(cPtr, cMemoryOwn);
  }

  internal BaseComponent(IntPtr cPtr, bool cMemoryOwn) {
    Init(cPtr, cMemoryOwn, false);
  }

  internal static HandleRef getCPtr(BaseComponent obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~BaseComponent() {
    if (swigCPtr.Handle != IntPtr.Zero) {
      if (Noesis.Extend.Initialized) {
        Noesis.Extend.RemoveProxy(swigCPtr.Handle);
        Release();
      }
      swigCPtr = new HandleRef(null, IntPtr.Zero);
    }
  }

  internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.BaseComponent_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  internal static IntPtr GetDynamicType(IntPtr cPtr) {
    IntPtr ret = NoesisGUI_PINVOKE.BaseComponent_GetDynamicType(cPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private void AddReference() {
    NoesisGUI_PINVOKE.BaseComponent_AddReference(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  private void Release() {
    NoesisGUI_PINVOKE.BaseComponent_Release(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  internal int GetNumReferences() {
    int ret = NoesisGUI_PINVOKE.BaseComponent_GetNumReferences(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }


  internal static IntPtr Extend(string typeName) {
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_BaseComponent(Marshal.StringToHGlobalAnsi(typeName));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return nativeType;
  }
}

}

