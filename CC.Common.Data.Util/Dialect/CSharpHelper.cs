using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util.Dialect
{
  internal static class CSharpHelper
  {
    #region Private Methods
    private static string ToTitleCase(string mText)
    {
      string rText = "";
      try
      {
        System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
        rText = TextInfo.ToTitleCase(mText.ToLower());
      }
      catch
      {
        rText = mText;
      }
      return rText;
    }

    internal static string GetClassHeading(string className, string nameSpace, bool readOnly)
    {
      string ret = String.Empty;
      if (readOnly)
        ret = _classTemplateRO.Replace("%CLASSNAME%", className).Replace("%NAMESPACE%", nameSpace);
      else
        ret = _classTemplate.Replace("%CLASSNAME%", className).Replace("%NAMESPACE%", nameSpace);

      return ret;
    }

    private static string GetAccessorName(string fieldName)
    {
      string ret = fieldName;
      ret = ret.Replace("_", " ").Replace("'", "").Replace("(", "").Replace(")", "");
      ret = ToTitleCase(ret).Replace(" ", "");
      return ret;
    }

    private static string GetPropertyName(string fieldName)
    {
      string ret = GetAccessorName(fieldName);
      string first = ret[0].ToString().ToLower();
      ret = "_" + first + ret.Substring(1);

      return ret;
    }

    internal static string GetProperty(string fieldName)
    {
      return "    private string " + GetPropertyName(fieldName) + ";" + Environment.NewLine;
    }

    internal static string GetAssignment(string fieldName)
    {
      string ret = "      " + GetPropertyName(fieldName) + " = row[\"" + fieldName + "\"].ToString();" + Environment.NewLine;
      return ret;
    }

    internal static string GetAssignmentEmpty(string fieldName)
    {
      string ret = "      " + GetPropertyName(fieldName) + " = String.Empty;" + Environment.NewLine;
      return ret;
    }

    internal static string GetAccessor(string fieldName, bool readOnly)
    {
      string ret = String.Empty;
      if (readOnly)
        ret = _accessorTemplateRO.Replace("%NAME%", GetAccessorName(fieldName)).Replace("%FIELD%", GetPropertyName(fieldName));
      else
        ret = _accessorTemplate.Replace("%NAME%", GetAccessorName(fieldName)).Replace("%FIELD%", GetPropertyName(fieldName));

      return ret;
    }
    #endregion

    #region Templates
    private static string _accessorTemplateRO = @"
    public String %NAME%
    {
      get { return %FIELD%; }
      set { }
    }
  ";

    private static string _classTemplateRO = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace %NAMESPACE%
{
  public class %CLASSNAME%List : List<%CLASSNAME%> { }
  public class %CLASSNAME%
  {
%PROPERTIES%    private string _error;

    public %CLASSNAME%() : this(String.Empty) { }
    
    public %CLASSNAME%(string error)
    {
%ASSIGNMENTEMPTY%      _error = error;
    }

    public %CLASSNAME%(DataRow row)
    {
%ASSIGNMENT%      _error = String.Empty;
    }
    
%ACCESSORS%
    public String Error
    {
      get { return _error; }
      set { }
    }
  }
}";

    private static string _accessorTemplate = @"
    public String %NAME%
    {
      get { return %FIELD%; }
      set 
      { 
        if (!%FIELD%.Equals(value))
        {
          %FIELD% = value;
          _dirty = true;
        }
      }
    }
  ";

    private static string _classTemplate = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace %NAMESPACE%
{
  public class %CLASSNAME%List : List<%CLASSNAME%> { }
  public class %CLASSNAME%
  {
%PROPERTIES%    private string _error;
    private bool _dirty;

    public %CLASSNAME%() : this(String.Empty) { }
    
    public %CLASSNAME%(string error)
    {
%ASSIGNMENTEMPTY%      _error = error;
      _dirty = false;
    }

    public %CLASSNAME%(DataRow row)
    {
%ASSIGNMENT%      _error = String.Empty;
      _dirty = false;
    }
    
%ACCESSORS%
    public String Error
    {
      get { return _error; }
      set { }
    }
    
    public bool IsDirty
    {
      get { return _dirty; }
    }

  }
}";

    #endregion
  }
}
