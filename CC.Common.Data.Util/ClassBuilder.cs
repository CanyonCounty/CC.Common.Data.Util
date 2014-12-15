using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Common.Data.Util.Dialect;

namespace CC.Common.Data.Util
{
// Similar to TableBuilder, but it will create a class and not SQL
  public class ClassBuilder
  {
    // Takes the FieldDefinitions and uses a Dialect to generate the SQL statement
    private ClassDialectInterface _dialect;
    private FieldDefinitions _fields;
    private string _className;
    private CustomTypeDelegate _custom;
    private Dictionary<string, string> _names;

    // I think I'll just call the Generate method and let the Dialects handle everything
    public ClassBuilder(string className, FieldDefinitions fields, ClassDialectInterface dialect) : this(className, fields, dialect, null) { }

    public ClassBuilder(string className, FieldDefinitions fields, ClassDialectInterface dialect, Dictionary<string, string> names)
    {
      _fields = fields;
      _dialect = dialect;
      _className = className;
      _names = names;
      _custom = null;
    }

    public void SetCustomTypeDelegate(CustomTypeDelegate custom)
    {
      _custom = custom;
    }

    public string Generate(Dictionary<string, string> map)
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

    public override string ToString()
    {
      // Doesn't seem to matter String vs StringBuilder
      // both take up gobs of memory
      return Generate(_names);
    }
  }
}
