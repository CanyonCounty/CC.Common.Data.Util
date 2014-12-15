using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  public class TextEqualsDialect : ClassDialectInterface
  {
    #region ClassDialectInterface Members
    string _data;
    public void Create(string className)
    {
      _data = "# Save this as " + className + ".map.txt" + Environment.NewLine;
      _data += "# Lines that start with a # are comments" + Environment.NewLine;
    }

    public void AddFieldDef(FieldDefinition field, CustomTypeDelegate custom, bool lastField)
    {
      _data += field.Name + "=" + Environment.NewLine;
    }

    public string ClassCode()
    {
      return _data;
    }

    #endregion
  }
}
