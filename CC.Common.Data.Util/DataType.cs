using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util
{
  public enum DataType
  {
    // The only types I need to concern myself with now...
    Text,
    Date,
    Bytes,
    Integer,
    Float,
    Currency,
    Time,
    DateTime,
    Memo,
    Custom = 999, // "Magical" thing here
  }
}
