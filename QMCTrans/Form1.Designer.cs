namespace QMCTrans
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
            this.FileList = new System.Windows.Forms.ListView();
            this.lv_FilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.AddFolderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.About = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileList
            // 
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_FilePath,
            this.lv_FileType,
            this.lv_Status});
            this.FileList.GridLines = true;
            this.FileList.Location = new System.Drawing.Point(12, 51);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(359, 460);
            this.FileList.TabIndex = 0;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            // 
            // lv_FilePath
            // 
            this.lv_FilePath.Text = "文件路径";
            this.lv_FilePath.Width = 218;
            // 
            // lv_FileType
            // 
            this.lv_FileType.Text = "文件类型";
            this.lv_FileType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lv_FileType.Width = 68;
            // 
            // lv_Status
            // 
            this.lv_Status.Text = "状态";
            this.lv_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lv_Status.Width = 67;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(77, 30);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "打开文件";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.onAddButtonClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(200, 12);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(77, 30);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "从列表删除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.OnDeleteClick);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(294, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(77, 30);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "转换";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.OnTransStart);
            // 
            // AddFolderButton
            // 
            this.AddFolderButton.Location = new System.Drawing.Point(106, 12);
            this.AddFolderButton.Name = "AddFolderButton";
            this.AddFolderButton.Size = new System.Drawing.Size(77, 30);
            this.AddFolderButton.TabIndex = 4;
            this.AddFolderButton.Text = "打开文件夹";
            this.AddFolderButton.UseVisualStyleBackColor = true;
            this.AddFolderButton.Click += new System.EventHandler(this.OnFolderClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 529);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "QQ音乐文件转换工具";
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(210, 517);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(160, 37);
            this.About.TabIndex = 6;
            this.About.Text = "关于";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.About);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddFolderButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "QMC转换器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ColumnHeader lv_FilePath;
        private System.Windows.Forms.ColumnHeader lv_FileType;
        private System.Windows.Forms.ColumnHeader lv_Status;
        private System.Windows.Forms.Button AddFolderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button About;
    }
}

