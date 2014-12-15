using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Common.Data.Util;
using CC.Common.Data.Util.Dialect;

namespace CC.Common.Data.Util.Demo
{
  public partial class frmMain : Form
  {
    private FieldDefinitions _fields;

    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      _fields = new FieldDefinitions();
    }

    private DataType CustomTypeDelegate(FieldDefinition field)
    {
      return DataType.Text;
    }

    private void btnDefine_Click(object sender, EventArgs e)
    {
      _fields.Add(new FieldDefinition("My_table_id", DataType.Integer, 0));
      _fields.Add(new FieldDefinition("my_field", DataType.Custom, 50, primary: false));
      _fields.Add(new FieldDefinition("another_field", DataType.Text, 150, true));
      _fields.Add(new FieldDefinition("another_field", DataType.Memo, 150, true));
      _fields.Add(new FieldDefinition("a_date_field", DataType.Date, 0));
      _fields.Add(new FieldDefinition("a_date_field", DataType.Date, 0));
      _fields.Add(new FieldDefinition("SIGNATURE OF VOTER", DataType.Text, 150, true));
      //Not Been Issued either DL # or SSN Flag
      _fields.Add(new FieldDefinition("Not Been Issued either DL # or SSN Flag", DataType.Text, 150, true));
      btnGenClass.Enabled = true;
      btnGenSQL.Enabled = true;

      lstFields.Items.Clear();
      foreach (FieldDefinition field in _fields)
      {
        lstFields.Items.Add(field.ToString());
      }
    }

    private void btnGenSQL_Click(object sender, EventArgs e)
    {
      TableBuilder builder = new TableBuilder("MyTable", _fields, new SQLServerDialect());
      builder.SetCustomTypeDelegate(CustomTypeDelegate);
      txtOutput.Text = builder.ToString();
    }

    private void btnGenClass_Click(object sender, EventArgs e)
    {
      ClassBuilder builder = new ClassBuilder("MyTable", _fields, new CSharpDialect());
      builder.SetCustomTypeDelegate(CustomTypeDelegate);
      txtOutput.Text = builder.ToString();
    }
  }
}
