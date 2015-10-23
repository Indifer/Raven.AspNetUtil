namespace ASPNET.MachineKeyUtil.WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtMachineKey1 = new System.Windows.Forms.TextBox();
            this.lblMachineKey1 = new System.Windows.Forms.Label();
            this.txtMachineKey2 = new System.Windows.Forms.TextBox();
            this.lblMachineKey2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(40, 485);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtMachineKey1
            // 
            this.txtMachineKey1.Location = new System.Drawing.Point(40, 59);
            this.txtMachineKey1.Multiline = true;
            this.txtMachineKey1.Name = "txtMachineKey1";
            this.txtMachineKey1.ReadOnly = true;
            this.txtMachineKey1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMachineKey1.Size = new System.Drawing.Size(641, 172);
            this.txtMachineKey1.TabIndex = 1;
            // 
            // lblMachineKey1
            // 
            this.lblMachineKey1.AutoSize = true;
            this.lblMachineKey1.Location = new System.Drawing.Point(38, 34);
            this.lblMachineKey1.Name = "lblMachineKey1";
            this.lblMachineKey1.Size = new System.Drawing.Size(143, 12);
            this.lblMachineKey1.TabIndex = 2;
            this.lblMachineKey1.Text = "ASP.Net 1.1 machineKey:";
            // 
            // txtMachineKey2
            // 
            this.txtMachineKey2.Location = new System.Drawing.Point(40, 275);
            this.txtMachineKey2.Multiline = true;
            this.txtMachineKey2.Name = "txtMachineKey2";
            this.txtMachineKey2.ReadOnly = true;
            this.txtMachineKey2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMachineKey2.Size = new System.Drawing.Size(641, 172);
            this.txtMachineKey2.TabIndex = 1;
            // 
            // lblMachineKey2
            // 
            this.lblMachineKey2.AutoSize = true;
            this.lblMachineKey2.Location = new System.Drawing.Point(38, 250);
            this.lblMachineKey2.Name = "lblMachineKey2";
            this.lblMachineKey2.Size = new System.Drawing.Size(143, 12);
            this.lblMachineKey2.TabIndex = 2;
            this.lblMachineKey2.Text = "ASP.Net 2.0 machineKey:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 555);
            this.Controls.Add(this.lblMachineKey2);
            this.Controls.Add(this.lblMachineKey1);
            this.Controls.Add(this.txtMachineKey2);
            this.Controls.Add(this.txtMachineKey1);
            this.Controls.Add(this.btnCreate);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtMachineKey1;
        private System.Windows.Forms.Label lblMachineKey1;
        private System.Windows.Forms.TextBox txtMachineKey2;
        private System.Windows.Forms.Label lblMachineKey2;
    }
}

