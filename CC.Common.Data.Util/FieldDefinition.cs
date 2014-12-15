using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CC.Common.Data.Util
{

  public class FieldDefinition
  {
    private string _name;
    private int _size;
    private DataType _type;
    private bool _primary;
    private bool _null;

    public FieldDefinition(string fieldName, DataType dataType, int fieldSize)
    {
      _name = fieldName.Trim();

      // Try to title case
      TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
      _name = ti.ToTitleCase(_name.ToLower());
      // Replace common characters that I don't want
      _name = _name.Replace("_", "").Replace(" ", "").Replace("#", "").Replace("-", "").Replace("/", "");
      // make sure Id is ID - 'cause I like how that looks
      _name = _name.Replace("Id", "ID");

      _type = dataType;
      _size = fieldSize;
      _primary = false;
      _null = true;
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public int Size
    {
      get { return _size; }
      set { _size = value; }
    }

    public string Class { get; set; }

    public DataType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    public bool PrimaryKey
    {
      get { return _primary; }
      set
      {
        _primary = value;
        if (_primary)
          _null = false;
      }
    }

    public bool Null
    {
      get { return _null; }
      set { _null = value; }
    }

    public bool IsTextType
    {
      get
      {
        return (_type == DataType.Text || _type == DataType.Custom);
      }
    }

    public override string ToString()
    {
      return String.Format("{0} {1}{2}, {3} {4}",
        _name, _type,
        IsTextType ? "(" + _size + ")" : "",
        Null ? "Can Be Null" : "Can NOT Be Null",
        PrimaryKey ? "- Key Field" : "");
    }
  }
}
