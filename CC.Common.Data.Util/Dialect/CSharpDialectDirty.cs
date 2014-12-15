using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  public class CSharpDialectDirty : ClassDialectInterface
  {
    private string data;
    private string properties;
    private string assignment;
    private string accessors;
    private string assignmentEmpty;
    private bool readOnly;

    #region ClassDialectInterface Members

    public void Create(string className)
    {
      readOnly = false;
      data = CSharpHelper.GetClassHeading(className, "CC.Generic.Classes", readOnly);

      properties = String.Empty;
      assignment = String.Empty;
      accessors = String.Empty;
      assignmentEmpty = String.Empty;
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

      properties += CSharpHelper.GetProperty(field.Name);
      assignment += CSharpHelper.GetAssignment(field.Name);
      accessors += CSharpHelper.GetAccessor(field.Name, readOnly);
      assignmentEmpty += CSharpHelper.GetAssignmentEmpty(field.Name);
    }

    public string ClassCode()
    {
      data = data.Replace("%PROPERTIES%", properties);
      data = data.Replace("%ASSIGNMENT%", assignment);
      data = data.Replace("%ACCESSORS%", accessors);
      data = data.Replace("%ASSIGNMENTEMPTY%", assignmentEmpty);

      return data;
    }

    #endregion
  }
}
