namespace _服务器
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.btn_StartListen = new System.Windows.Forms.Button();
            this.cbx_ClientSelect = new System.Windows.Forms.ComboBox();
            this.txt_RecvMsg = new System.Windows.Forms.TextBox();
            this.txt_SendRecord = new System.Windows.Forms.TextBox();
            this.txt_InputMsg = new System.Windows.Forms.TextBox();
            this.btn_SendMsg = new System.Windows.Forms.Button();
            this.btn_Shake = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txt_IP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(80, 135);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(95, 21);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP地址：";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(334, 135);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(94, 21);
            this.label_Port.TabIndex = 2;
            this.label_Port.Text = "端口号：";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(420, 132);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(115, 31);
            this.txt_Port.TabIndex = 3;
            this.txt_Port.Text = "50000";
            // 
            // btn_StartListen
            // 
            this.btn_StartListen.Location = new System.Drawing.Point(654, 125);
            this.btn_StartListen.Name = "btn_StartListen";
            this.btn_StartListen.Size = new System.Drawing.Size(105, 41);
            this.btn_StartListen.TabIndex = 4;
            this.btn_StartListen.Text = "开始监听";
            this.btn_StartListen.UseVisualStyleBackColor = true;
            // 
            // cbx_ClientSelect
            // 
            this.cbx_ClientSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ClientSelect.FormattingEnabled = true;
            this.cbx_ClientSelect.Location = new System.Drawing.Point(785, 133);
            this.cbx_ClientSelect.Name = "cbx_ClientSelect";
            this.cbx_ClientSelect.Size = new System.Drawing.Size(175, 29);
            this.cbx_ClientSelect.TabIndex = 5;
            // 
            // txt_RecvMsg
            // 
            this.txt_RecvMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_RecvMsg.Location = new System.Drawing.Point(80, 180);
            this.txt_RecvMsg.Multiline = true;
            this.txt_RecvMsg.Name = "txt_RecvMsg";
            this.txt_RecvMsg.ReadOnly = true;
            this.txt_RecvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_RecvMsg.Size = new System.Drawing.Size(1040, 255);
            this.txt_RecvMsg.TabIndex = 6;
            // 
            // txt_SendRecord
            // 
            this.txt_SendRecord.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_SendRecord.Location = new System.Drawing.Point(80, 465);
            this.txt_SendRecord.Multiline = true;
            this.txt_SendRecord.Name = "txt_SendRecord";
            this.txt_SendRecord.ReadOnly = true;
            this.txt_SendRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_SendRecord.Size = new System.Drawing.Size(1040, 255);
            this.txt_SendRecord.TabIndex = 7;
            // 
            // txt_InputMsg
            // 
            this.txt_InputMsg.Location = new System.Drawing.Point(80, 825);
            this.txt_InputMsg.Name = "txt_InputMsg";
            this.txt_InputMsg.Size = new System.Drawing.Size(745, 31);
            this.txt_InputMsg.TabIndex = 8;
            // 
            // btn_SendMsg
            // 
            this.btn_SendMsg.Location = new System.Drawing.Point(855, 816);
            this.btn_SendMsg.Name = "btn_SendMsg";
            this.btn_SendMsg.Size = new System.Drawing.Size(105, 45);
            this.btn_SendMsg.TabIndex = 9;
            this.btn_SendMsg.Text = "发送消息";
            this.btn_SendMsg.UseVisualStyleBackColor = true;
            // 
            // btn_Shake
            // 
            this.btn_Shake.Location = new System.Drawing.Point(984, 815);
            this.btn_Shake.Name = "btn_Shake";
            this.btn_Shake.Size = new System.Drawing.Size(108, 46);
            this.btn_Shake.TabIndex = 10;
            this.btn_Shake.Text = "震动";
            this.btn_Shake.UseVisualStyleBackColor = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1180, 38);
            this.bindingNavigator1.TabIndex = 11;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(40, 32);
            this.bindingNavigatorAddNewItem.Text = "新添";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(53, 32);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(40, 32);
            this.bindingNavigatorDeleteItem.Text = "删除";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(40, 32);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(40, 32);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 34);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(40, 32);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(40, 32);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(159, 132);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(155, 31);
            this.txt_IP.TabIndex = 1;
            this.txt_IP.Text = "10.18.128.190";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 880);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.btn_Shake);
            this.Controls.Add(this.btn_SendMsg);
            this.Controls.Add(this.txt_InputMsg);
            this.Controls.Add(this.txt_SendRecord);
            this.Controls.Add(this.txt_RecvMsg);
            this.Controls.Add(this.cbx_ClientSelect);
            this.Controls.Add(this.btn_StartListen);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label_IP);
            this.Name = "Form1";
            this.Text = "服务器";
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // 所有控件全局声明，和上面一一对应
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Button btn_StartListen;
        private System.Windows.Forms.ComboBox cbx_ClientSelect;
        private System.Windows.Forms.TextBox txt_RecvMsg;
        private System.Windows.Forms.TextBox txt_SendRecord;
        private System.Windows.Forms.TextBox txt_InputMsg;
        private System.Windows.Forms.Button btn_SendMsg;
        private System.Windows.Forms.Button btn_Shake;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox txt_IP;
    }
}