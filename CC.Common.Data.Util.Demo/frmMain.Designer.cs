namespace CC.Common.Data.Util.Demo
{
partial class frmMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnDefine = new System.Windows.Forms.Button();
      this.btnGenSQL = new System.Windows.Forms.Button();
      this.splitMain = new System.Windows.Forms.SplitContainer();
      this.lstFields = new System.Windows.Forms.ListBox();
      this.txtOutput = new System.Windows.Forms.TextBox();
      this.btnGenClass = new System.Windows.Forms.Button();
      this.cboClasses = new System.Windows.Forms.ComboBox();
      this.cboTables = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
      this.splitMain.Panel1.SuspendLayout();
      this.splitMain.Panel2.SuspendLayout();
      this.splitMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnDefine
      // 
      this.btnDefine.Location = new System.Drawing.Point(12, 12);
      this.btnDefine.Name = "btnDefine";
      this.btnDefine.Size = new System.Drawing.Size(107, 23);
      this.btnDefine.TabIndex = 0;
      this.btnDefine.Text = "Define Fields";
      this.btnDefine.UseVisualStyleBackColor = true;
      this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
      // 
      // btnGenSQL
      // 
      this.btnGenSQL.Enabled = false;
      this.btnGenSQL.Location = new System.Drawing.Point(125, 12);
      this.btnGenSQL.Name = "btnGenSQL";
      this.btnGenSQL.Size = new System.Drawing.Size(107, 23);
      this.btnGenSQL.TabIndex = 1;
      this.btnGenSQL.Text = "Generate SQL";
      this.btnGenSQL.UseVisualStyleBackColor = true;
      this.btnGenSQL.Click += new System.EventHandler(this.btnGenSQL_Click);
      // 
      // splitMain
      // 
      this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitMain.Location = new System.Drawing.Point(12, 70);
      this.splitMain.Name = "splitMain";
      this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitMain.Panel1
      // 
      this.splitMain.Panel1.Controls.Add(this.lstFields);
      // 
      // splitMain.Panel2
      // 
      this.splitMain.Panel2.Controls.Add(this.txtOutput);
      this.splitMain.Size = new System.Drawing.Size(558, 308);
      this.splitMain.SplitterDistance = 153;
      this.splitMain.TabIndex = 4;
      // 
      // lstFields
      // 
      this.lstFields.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstFields.FormattingEnabled = true;
      this.lstFields.Location = new System.Drawing.Point(0, 0);
      this.lstFields.Name = "lstFields";
      this.lstFields.Size = new System.Drawing.Size(558, 153);
      this.lstFields.TabIndex = 8;
      // 
      // txtOutput
      // 
      this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtOutput.Location = new System.Drawing.Point(0, 0);
      this.txtOutput.Multiline = true;
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtOutput.Size = new System.Drawing.Size(558, 151);
      this.txtOutput.TabIndex = 10;
      // 
      // btnGenClass
      // 
      this.btnGenClass.Enabled = false;
      this.btnGenClass.Location = new System.Drawing.Point(125, 41);
      this.btnGenClass.Name = "btnGenClass";
      this.btnGenClass.Size = new System.Drawing.Size(107, 23);
      this.btnGenClass.TabIndex = 5;
      this.btnGenClass.Text = "Generate Class";
      this.btnGenClass.UseVisualStyleBackColor = true;
      this.btnGenClass.Click += new System.EventHandler(this.btnGenClass_Click);
      // 
      // cboClasses
      // 
      this.cboClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cboClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboClasses.FormattingEnabled = true;
      this.cboClasses.Location = new System.Drawing.Point(238, 43);
      this.cboClasses.Name = "cboClasses";
      this.cboClasses.Size = new System.Drawing.Size(332, 21);
      this.cboClasses.TabIndex = 6;
      // 
      // cboTables
      // 
      this.cboTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cboTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboTables.FormattingEnabled = true;
      this.cboTables.Location = new System.Drawing.Point(238, 14);
      this.cboTables.Name = "cboTables";
      this.cboTables.Size = new System.Drawing.Size(332, 21);
      this.cboTables.TabIndex = 7;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(582, 390);
      this.Controls.Add(this.cboTables);
      this.Controls.Add(this.cboClasses);
      this.Controls.Add(this.btnGenClass);
      this.Controls.Add(this.splitMain);
      this.Controls.Add(this.btnGenSQL);
      this.Controls.Add(this.btnDefine);
      this.Name = "frmMain";
      this.Text = "CC.Common.Data.Util.Demo";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.splitMain.Panel1.ResumeLayout(false);
      this.splitMain.Panel2.ResumeLayout(false);
      this.splitMain.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
      this.splitMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnDefine;
    private System.Windows.Forms.Button btnGenSQL;
    private System.Windows.Forms.SplitContainer splitMain;
    private System.Windows.Forms.ListBox lstFields;
    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.Button btnGenClass;
    private System.Windows.Forms.ComboBox cboClasses;
    private System.Windows.Forms.ComboBox cboTables;
  }
}

