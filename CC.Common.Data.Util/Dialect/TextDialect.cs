using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  public class TextDialect : ClassDialectInterface
  {
    #region ClassDialectInterface Members
    string _data;
    public void Create(string className)
    {
      _data = "# Fields for " + className + Environment.NewLine;
    }

    public void AddFieldDef(FieldDefinition field, CustomTypeDelegate custom, bool lastField)
    {
      if (field.IsTextType)
        _data += String.Format("{0,-20} | {1,-10} | ({2,-1})", field.Name, field.Type, field.Size);
      else
        _data += String.Format("{0,-20} | {1,-10} |", field.Name, field.Type);

      //_data += field.Name + "\t" + field.Type;
      //if (field.IsTextType) _data += " (" + field.Size + ")";
      _data += Environment.NewLine;
    }

    public string ClassCode()
    {
      return _data;
    }

    #endregion
  }
}
