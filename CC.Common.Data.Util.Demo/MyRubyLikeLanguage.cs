using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Common.Data.Util.Dialect;

namespace CC.Common.Data.Util.Demo
{
  public class MyRubyLikeLanguage: ClassDialectInterface
  {
    private string data;
    private string _className;
    private List<FieldDefinition> _fields;

    #region ClassDialectInterface Members

    public void Create(string className)
    {
      _className = className;
      _fields = new List<FieldDefinition>();
      data = "class " + className + Environment.NewLine;
    }

    public void AddFieldDef(FieldDefinition field, CustomTypeDelegate custom, bool lastField)
    {
      if (field.Type == DataType.Custom)
      {
        if (custom != null)
          field.Type = custom(field);
        else
          throw new CustomTypeDelegateException(String.Format("Field '{0}' has a DataType of Custom and you haven't told me what to do about it (CustomTypeDelegate not set)", field.Name));
      }

      data += "  attr_accessor :" + field.Name + Environment.NewLine;
      _fields.Add(field);
    }

    public string ClassCode()
    {
      data += "end" + Environment.NewLine + Environment.NewLine;
      data += "if __FILE__ == $0" + Environment.NewLine;
      data += "  c = " + _className + ".new" + Environment.NewLine;
      foreach (FieldDefinition field in _fields)
        data += "  c." + field.Name + " = '" + field.Name + " value'" + Environment.NewLine;

      data += "end" + Environment.NewLine + Environment.NewLine;
      data += "c.instance_variables.map { |e| puts \"#{e} =  '#{c.instance_variable_get(e)}'\" }";
      return data;
    }

    #endregion
  }
}
