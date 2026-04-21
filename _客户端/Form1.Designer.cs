namespace _客户端
{
    partial class Form1
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
            this.labelIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtRecvShow = new System.Windows.Forms.TextBox();
            this.txtSendInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(180, 210);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(95, 21);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "IP地址：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(248, 207);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(160, 31);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "10.18.128.190";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(430, 210);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(94, 21);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "端口号：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(498, 207);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(120, 31);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "50000";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(662, 200);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 41);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // txtRecvShow
            // 
            this.txtRecvShow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRecvShow.Location = new System.Drawing.Point(180, 270);
            this.txtRecvShow.Multiline = true;
            this.txtRecvShow.Name = "txtRecvShow";
            this.txtRecvShow.ReadOnly = true;
            this.txtRecvShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecvShow.Size = new System.Drawing.Size(1100, 220);
            this.txtRecvShow.TabIndex = 5;
            // 
            // txtSendInput
            // 
            this.txtSendInput.Location = new System.Drawing.Point(180, 520);
            this.txtSendInput.Multiline = true;
            this.txtSendInput.Name = "txtSendInput";
            this.txtSendInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendInput.Size = new System.Drawing.Size(1100, 220);
            this.txtSendInput.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1170, 760);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(110, 40);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 855);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendInput);
            this.Controls.Add(this.txtRecvShow);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.labelIP);
            this.Name = "Form1";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtRecvShow;
        private System.Windows.Forms.TextBox txtSendInput;
        private System.Windows.Forms.Button btnSend;
    }
}