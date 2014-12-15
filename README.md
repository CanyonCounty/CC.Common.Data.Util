CC.Common.Data.Util
===================

Creates Classes and Tables based on a simple definition

Taking a field definition like so

Table: MyTable
FieldName|Type|Size|not null|primary
---------|----|----|--------|-------
My ID|int|4|X|X
My Key|text|40||
My Value|text|100||

Creating a SQL Server create statement
```
create table MyTable (
  [MyID] int not null primaty key,
  [MyKey] varchar(40) null,
  [MyValue] varchar(100) null
)
```

Creating a C# Class
```
/// <summary>
/// MyTable class
/// </summary>
public class MyTable
{
  private string _MyID;
  public String MyID
  {
    get { return _MyID; }
    set { _MyID = value; }
  }

  private string _MyKey;
  public String MyKey
  {
    get { return _MyKey; }
    set { _MyKey = value; }
  }

  private string _MyValue;
  public String MyValue
  {
    get { return _MyValue; }
    set { _MyValue = value; }
  }

  public MyTable (string MyID, string MyKey, string MyValue )
  {
    // Add Constructor Logic here

  }
}
```