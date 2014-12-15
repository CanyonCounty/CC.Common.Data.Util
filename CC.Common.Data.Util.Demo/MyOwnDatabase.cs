using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Common.Data.Util.Dialect;

namespace CC.Common.Data.Util.Demo
{
  public class MyOwnDatabase : TableDialectInterface
  {
    public string Create(string tablename)
    {
      return String.Format("create massive table {0} ({1}", tablename, Newline());
    }

    public string Close()
    {
      return ")" + Newline();
    }

    public string FieldSeperator()
    {
      return ";" + Newline();
    }

    public string FieldDef(FieldDefinition field, CustomTypeDelegate custom)
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
      switch (field.Type)
      {
        case DataType.Integer:
          ret = String.Format("{0} bigint", ValidFieldName(field.Name));
          break;
        case DataType.Date:
          ret = String.Format("{0} datetime", ValidFieldName(field.Name));
          break;
        case DataType.Text:
          ret = String.Format("{0} nvarchar({1})", ValidFieldName(field.Name), field.Size);
          break;
        default:
          ret = String.Format("Code missing for " + field.Type);
          break;
      }

      return ret;
    }

    public string Newline()
    {
      return Environment.NewLine;
    }

    public string Indent()
    {
      return "  ";
    }

    public string ValidFieldName(string fieldName)
    {
      return "<" + fieldName + ">";
    }
  }
}
