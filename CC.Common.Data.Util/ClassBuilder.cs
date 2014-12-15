using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Common.Data.Util.Dialect;

namespace CC.Common.Data.Util
{
  /// <summary>
  /// Takes FieldDefinitions and converts it into a class
  /// </summary>
  public class ClassBuilder
  {
    private ClassDialectInterface _dialect;
    private FieldDefinitions _fields;
    private string _className;
    private CustomTypeDelegate _custom;
    private Dictionary<string, string> _names;

    /// <summary>
    /// Class Builder
    /// </summary>
    /// <param name="className">The class name</param>
    /// <param name="fields">List of FieldDefinition</param>
    /// <param name="dialect">The dialect to create</param>
    public ClassBuilder(string className, FieldDefinitions fields, ClassDialectInterface dialect)
      : this(className, fields, dialect, null) { }

    /// <summary>
    /// Class Builder with optional dictionary of new names
    /// </summary>
    /// <param name="className">The class name</param>
    /// <param name="fields">List of FieldDefinition</param>
    /// <param name="dialect">The dialect to create</param>
    /// <param name="names">A dictionary to rename fields too (python dialect uses it)</param>
    public ClassBuilder(string className, FieldDefinitions fields, ClassDialectInterface dialect, Dictionary<string, string> names)
    {
      _fields = fields;
      _dialect = dialect;
      _className = className;
      _names = names;
      _custom = null;
    }

    /// <summary>
    /// Set the custom type delegate. This can be used to determine the type at runtime
    /// </summary>
    /// <param name="custom"></param>
    public void SetCustomTypeDelegate(CustomTypeDelegate custom)
    {
      _custom = custom;
    }

    private string Generate(Dictionary<string, string> map)
    {
      for (int i = 0; i < _fields.Count; i++)
      {
        string key = _fields[i].Name;
        if (map != null)
        {
          if (map.ContainsKey(key) && (!String.IsNullOrEmpty(map[key])))
            _fields[i].Class = map[key];
          else
            _fields[i].Class = _fields[i].Name;
        }
        else
          _fields[i].Class = _fields[i].Name;
      }

      String ret = String.Empty;
      if (_fields.Count > 0)
      {
        _dialect.Create(_className);
        for (int i = 0; i < _fields.Count; i++)
        {
          _dialect.AddFieldDef(_fields[i], _custom, (i == _fields.Count - 1));
        }
        ret = _dialect.ClassCode();
      }
      else
      {
        ret = "-- No field definitions were passed in - nothing to do!";
      }
      return ret;
    }

    /// <summary>
    /// String representation of the class
    /// </summary>
    /// <returns>The code for the class</returns>
    public override string ToString()
    {
      // Doesn't seem to matter String vs StringBuilder
      // both take up gobs of memory
      return Generate(_names);
    }
  }
}
