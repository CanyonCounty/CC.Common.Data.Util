using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util
{
  public delegate DataType CustomTypeDelegate(FieldDefinition field);

  public class CustomTypeDelegateException: Exception
  {
    public CustomTypeDelegateException() { }
    public CustomTypeDelegateException(string message) : base(message) { }
  }
}
