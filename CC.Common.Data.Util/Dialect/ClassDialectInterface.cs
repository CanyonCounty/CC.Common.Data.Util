using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  public interface ClassDialectInterface
  {
    // Since classes are a totally different beast this is much simpiler
    // Called to start a class
    void Create(string className);
    // Called for each definition
    void AddFieldDef(FieldDefinition field, CustomTypeDelegate custom, bool lastField);
    // Called to return the generated code
    string ClassCode();
  }
}
