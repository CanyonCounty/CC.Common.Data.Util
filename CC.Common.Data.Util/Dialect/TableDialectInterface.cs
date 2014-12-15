using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  public interface TableDialectInterface
  {
    // For the "create table #tablename
    string Create(string tablename);
    // For the closing paren and option information (mysql isam table etc..)
    string Close();
    string FieldDef(FieldDefinition field, CustomTypeDelegate custom);
    string FieldSeperator();
    string Newline();
    string Indent();
    string ValidFieldName(string fieldName);
  }
}
