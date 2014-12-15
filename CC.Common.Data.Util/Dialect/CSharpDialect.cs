using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  public class CSharpDialect : ClassDialectInterface
  {
    private string _class;
    private string _className;
    private string _constructor;
    private int _len;
    private string nl = Environment.NewLine;

    #region ClassDialectInterface Members

    public void Create(string className)
    {
      // This can all be handled in ClassCode
      _className = className;
      _constructor = "";
      _class = "/// <summary>" + nl;
      _class += String.Format("/// {0} class", _className) + nl;
      _class += "/// </summary>" + nl;
      _class += String.Format("public class {0}", _className) + nl;
      _class += "{" + nl;
    }

    public void AddFieldDef(FieldDefinition field, CustomTypeDelegate custom, bool lastField)
    {
      string ret = String.Empty;
      if (field.Type == DataType.Custom)
      {
        if (custom != null)
          field.Type = custom(field);
        else
          throw new CustomTypeDelegateException(String.Format("Field '{0}' has a DataType of Custom and you haven't told me what to do about it (CustomTypeDelegate not set)", field.Name));
      }

      // Now we should have the correct field information
      string fieldType1 = "string";
      string fieldType2 = "String";
      switch (field.Type)
      {
        case DataType.Date:
          fieldType1 = "DateTime";
          fieldType2 = "DateTime";
          break;
        case DataType.Text:
          fieldType1 = "string";
          fieldType2 = "String";
          break;
        default:
          ret = String.Format("Code missing for " + field.Type);
          break;
      }

      _class += String.Format("  private {0} _{1};", fieldType1, field.Name) + nl;
      _class += String.Format("  public {0} {1}", fieldType2, field.Name) + nl;
      _class += "  {" + nl;
      _class += String.Format("    get {{ return _{0}; }}", field.Name) + nl;
      _class += String.Format("    set {{ _{0} = value; }}", field.Name) + nl;
      _class += "  }" + nl + nl;

      string conadd = String.Format("{0} {1}{2}", fieldType1, field.Name, lastField ? " " : ", ");
      _len += conadd.Length;
      _constructor += conadd;
      if (_len > 70)
      {
        _constructor += nl + "    ";
        _len = 0;
      }
    }

    public string ClassCode()
    {
      // Constructor?

      _class += String.Format("  public {0} ({1})", _className, _constructor) + nl;
      _class += "  {" + nl + "    // Add Constructor Logic here" + nl + nl + "  }" + nl;
      _class += "}";

      return _class;
    }

    #endregion
  }
}
