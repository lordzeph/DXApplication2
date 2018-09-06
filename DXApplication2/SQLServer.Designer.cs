namespace DXApplication2
{
    partial class SQLServer
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
            this.usert = new System.Windows.Forms.TextBox();
            this.passt = new System.Windows.Forms.TextBox();
            this.sqluser = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SerList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.SerList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // usert
            // 
            this.usert.Location = new System.Drawing.Point(86, 91);
            this.usert.Name = "usert";
            this.usert.Size = new System.Drawing.Size(100, 21);
            this.usert.TabIndex = 1;
            // 
            // passt
            // 
            this.passt.Location = new System.Drawing.Point(86, 133);
            this.passt.Name = "passt";
            this.passt.Size = new System.Drawing.Size(100, 21);
            this.passt.TabIndex = 2;
            // 
            // sqluser
            // 
            this.sqluser.AutoSize = true;
            this.sqluser.Location = new System.Drawing.Point(77, 68);
            this.sqluser.Name = "sqluser";
            this.sqluser.Size = new System.Drawing.Size(62, 17);
            this.sqluser.TabIndex = 3;
            this.sqluser.Text = "SqlUser";
            this.sqluser.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pass";
            // 
            // SerList
            // 
            this.SerList.Location = new System.Drawing.Point(86, 21);
            this.SerList.Name = "SerList";
            this.SerList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SerList.Size = new System.Drawing.Size(100, 20);
            this.SerList.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(232, 130);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // SQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 187);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.SerList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqluser);
            this.Controls.Add(this.passt);
            this.Controls.Add(this.usert);
            this.Name = "SQLServer";
            this.Text = "SQLServer";
            this.Load += new System.EventHandler(this.SQLServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SerList.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usert;
        private System.Windows.Forms.TextBox passt;
        private System.Windows.Forms.CheckBox sqluser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit SerList;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}