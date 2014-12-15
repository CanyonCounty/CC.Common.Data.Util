using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  public class PythonDialect : ClassDialectInterface
  {
    private string _class;
    private string _className;
    private string nl = Environment.NewLine;

    #region ClassDialectInterface Members
    public void Create(string className)
    {
      _className = className;
      _class = String.Format("class {0}:", _className) + nl;
      _class += @"  def __init__(self):
    '''All python variables can be defined as a string
    to begin with, but be used as an integer later'''" + nl;
    }

    public void AddFieldDef(FieldDefinition field, CustomTypeDelegate custom, bool lastField)
    {
      _class += String.Format("    self.{0} = ''", field.Class.Replace(" ", "")) + nl;
    }

    public string ClassCode()
    {
      _class += String.Format(@"  
  def __repr__(self):
    return '%s(%r)' % (self.__class__, self.__dict__)

if __name__ == '__main__':
  var = {0}()
  print var", _className);

      return _class;
    }

    #endregion
  }
}
