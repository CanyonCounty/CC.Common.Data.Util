using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Common.Data.Util.Dialect;

namespace CC.Common.Data.Util
{
  public class TableBuilder
  {
    // Takes the FieldDefinitions and uses a Dialect to generate the SQL statement
    private TableDialectInterface _dialect;
    private FieldDefinitions _fields;
    private string _tableName;
    private CustomTypeDelegate _custom;

    public TableBuilder(string tableName, FieldDefinitions fields, TableDialectInterface dialect)
    {
      _tableName = tableName;
      _fields = fields;
      _dialect = dialect;
      _custom = null;
    }

    public void SetCustomTypeDelegate(CustomTypeDelegate custom)
    {
      _custom = custom;
    }

    private string GetFieldString(FieldDefinition field)
    {
      string root = _dialect.Indent() + _dialect.FieldDef(field, _custom);
      // Should this go to dialect?
      root += field.Null ? " null" : " not null";
      if (field.PrimaryKey) root += " primary key";
      return root;
    }

    private string Generate()
    {
      string ret = String.Empty;
      if (_fields.Count > 0)
      {
        ret += _dialect.Create(_tableName);
        for (int i = 0; i < _fields.Count - 1; i++)
        {
          ret += GetFieldString(_fields[i]) + _dialect.FieldSeperator();
        }

        ret += GetFieldString(_fields[_fields.Count - 1]) + _dialect.Newline();
        ret += _dialect.Close();
      }
      else
      {
        ret = "-- No field definitions were passed in - nothing to do!";
      }
      return ret;
    }

    private string GenerateBuilder()
    {
      StringBuilder ret = new StringBuilder();
      if (_fields.Count > 0)
      {
        ret.Append(_dialect.Create(_tableName));
        for (int i = 0; i < _fields.Count - 1; i++)
        {
          ret.Append(GetFieldString(_fields[i]) + _dialect.FieldSeperator());
        }

        ret.Append(GetFieldString(_fields[_fields.Count - 1]) + _dialect.Newline());
        ret.Append(_dialect.Close());
      }
      else
      {
        ret.Append("-- No field definitions were passed in - nothing to do!");
      }
      return ret.ToString();
    }

    public override string ToString()
    {
      // Doesn't seem to matter String vs StringBuilder
      // both take up gobs of memory
      return GenerateBuilder();
    }
  }
}
