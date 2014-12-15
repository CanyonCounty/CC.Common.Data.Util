using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util
{
  public class FieldDefinitions : List<FieldDefinition>
  {
    public new void Add(FieldDefinition value)
    {
      if (base.Find(x => x.Name.ToUpper().Equals(value.Name.ToUpper())) == null)
        base.Add(value);
    }
  }
}
