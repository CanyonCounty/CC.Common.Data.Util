﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Common.Data.Util.Dialect;
using System.Reflection;

namespace CC.Common.Data.Util
{
  /// <summary>
  /// Helper class to load up the contained dialects
  /// </summary>
  public static class DialectLoader
  {
    private static List<string> _tableDialects;
    private static List<string> _classDialects;
    private static Assembly _localAssembly;
    private static Assembly _foreignAssembly;

    /// <summary>
    /// Loads Dialects Internal to our assembly
    /// </summary>
    private static void LoadLocalDialects()
    {
      _localAssembly = Assembly.GetExecutingAssembly();
      Type[] types = _localAssembly.GetTypes();
      foreach (Type type in types)
      {
        Type classType = type.GetInterface("ClassDialectInterface");
        if (classType != null)
        {
          if (!type.IsAbstract)
            _classDialects.Add(type.FullName);
        }

        Type tableType = type.GetInterface("TableDialectInterface");
        if (tableType != null)
        {
          if (!type.IsAbstract)
            _tableDialects.Add(type.FullName);
        }
      }
    }

    /// <summary>
    /// Loads Dialects that could be defined in the calling assembly
    /// </summary>
    private static void LoadForeignDialects()
    {
      _foreignAssembly = Assembly.GetEntryAssembly();
      Type[] types = _foreignAssembly.GetTypes();
      foreach (Type type in types)
      {
        Type classType = type.GetInterface("ClassDialectInterface");
        if (classType != null)
        {
          if (!type.IsAbstract)
            _classDialects.Add(type.FullName);
        }

        Type tableType = type.GetInterface("TableDialectInterface");
        if (tableType != null)
        {
          if (!type.IsAbstract)
            _tableDialects.Add(type.FullName);
        }
      }
    }

    private static void LoadDialects()
    {
      _tableDialects = new List<string>();
      _classDialects = new List<string>();

      LoadLocalDialects();
      LoadForeignDialects();

      _tableDialects.Sort();
      _classDialects.Sort();
    }

    public static List<string> TableDialects()
    {
      LoadDialects();
      return _tableDialects;
    }

    public static List<string> ClassDialects()
    {
      LoadDialects();
      return _classDialects;
    }

    public static ClassDialectInterface GetClassDialect(string classDialectName)
    {
      ClassDialectInterface ret = (ClassDialectInterface)_localAssembly.CreateInstance(classDialectName);
      if (ret == null)
        ret = (ClassDialectInterface)_foreignAssembly.CreateInstance(classDialectName);
      if (ret == null)
        throw new Exception(String.Format("Table Dialect {0} is not found", classDialectName));
      return ret;
    }

    public static TableDialectInterface GetTableDialect(string tableDialectName)
    {
      TableDialectInterface ret = (TableDialectInterface)_localAssembly.CreateInstance(tableDialectName);
      if (ret == null)
        ret = (TableDialectInterface)_foreignAssembly.CreateInstance(tableDialectName);
      if (ret == null)
        throw new Exception(String.Format("Table Dialect {0} is not found", tableDialectName));
      return ret;
    }
  }
}
