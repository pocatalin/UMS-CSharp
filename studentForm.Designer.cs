namespace PIProject
{
    partial class studentForm
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
            this.labelName = new MetroFramework.Controls.MetroLabel();
            this.mTGrades = new MetroFramework.Controls.MetroTile();
            this.mTAttendance = new MetroFramework.Controls.MetroTile();
            this.mTInfo = new MetroFramework.Controls.MetroTile();
            this.flowLayoutPanelInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelGrades = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelAttendance = new System.Windows.Forms.FlowLayoutPanel();
            this.mTBack = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.labelName.Location = new System.Drawing.Point(23, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(111, 25);
            this.labelName.Style = MetroFramework.MetroColorStyle.Orange;
            this.labelName.TabIndex = 0;
            this.labelName.Text = "metroLabel1";
            this.labelName.UseStyleColors = true;
            // 
            // mTGrades
            // 
            this.mTGrades.ActiveControl = null;
            this.mTGrades.ForeColor = System.Drawing.Color.White;
            this.mTGrades.Location = new System.Drawing.Point(23, 93);
            this.mTGrades.Name = "mTGrades";
            this.mTGrades.Size = new System.Drawing.Size(163, 50);
            this.mTGrades.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTGrades.TabIndex = 3;
            this.mTGrades.Text = "Grades";
            this.mTGrades.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTGrades.UseSelectable = true;
            // 
            // mTAttendance
            // 
            this.mTAttendance.ActiveControl = null;
            this.mTAttendance.BackColor = System.Drawing.Color.White;
            this.mTAttendance.ForeColor = System.Drawing.Color.White;
            this.mTAttendance.Location = new System.Drawing.Point(23, 149);
            this.mTAttendance.Name = "mTAttendance";
            this.mTAttendance.Size = new System.Drawing.Size(163, 50);
            this.mTAttendance.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTAttendance.TabIndex = 4;
            this.mTAttendance.Text = "Attendance";
            this.mTAttendance.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTAttendance.UseSelectable = true;
            // 
            // mTInfo
            // 
            this.mTInfo.ActiveControl = null;
            this.mTInfo.BackColor = System.Drawing.Color.Black;
            this.mTInfo.ForeColor = System.Drawing.Color.White;
            this.mTInfo.Location = new System.Drawing.Point(23, 205);
            this.mTInfo.Name = "mTInfo";
            this.mTInfo.Size = new System.Drawing.Size(163, 50);
            this.mTInfo.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTInfo.TabIndex = 5;
            this.mTInfo.Text = "Information";
            this.mTInfo.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTInfo.UseSelectable = true;
            // 
            // flowLayoutPanelInfo
            // 
            this.flowLayoutPanelInfo.Location = new System.Drawing.Point(192, 103);
            this.flowLayoutPanelInfo.Name = "flowLayoutPanelInfo";
            this.flowLayoutPanelInfo.Size = new System.Drawing.Size(733, 441);
            this.flowLayoutPanelInfo.TabIndex = 7;
            // 
            // flowLayoutPanelGrades
            // 
            this.flowLayoutPanelGrades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flowLayoutPanelGrades.Location = new System.Drawing.Point(192, 103);
            this.flowLayoutPanelGrades.Name = "flowLayoutPanelGrades";
            this.flowLayoutPanelGrades.Size = new System.Drawing.Size(733, 441);
            this.flowLayoutPanelGrades.TabIndex = 8;
            // 
            // flowLayoutPanelAttendance
            // 
            this.flowLayoutPanelAttendance.Location = new System.Drawing.Point(192, 103);
            this.flowLayoutPanelAttendance.Name = "flowLayoutPanelAttendance";
            this.flowLayoutPanelAttendance.Size = new System.Drawing.Size(735, 424);
            this.flowLayoutPanelAttendance.TabIndex = 9;
            // 
            // mTBack
            // 
            this.mTBack.ActiveControl = null;
            this.mTBack.ForeColor = System.Drawing.Color.White;
            this.mTBack.Location = new System.Drawing.Point(192, 47);
            this.mTBack.Name = "mTBack";
            this.mTBack.Size = new System.Drawing.Size(120, 50);
            this.mTBack.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTBack.TabIndex = 10;
            this.mTBack.Text = "Back";
            this.mTBack.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTBack.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTBack.UseSelectable = true;
            // 
            // studentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.flowLayoutPanelInfo);
            this.Controls.Add(this.flowLayoutPanelGrades);
            this.Controls.Add(this.mTBack);
            this.Controls.Add(this.flowLayoutPanelAttendance);
            this.Controls.Add(this.mTInfo);
            this.Controls.Add(this.mTAttendance);
            this.Controls.Add(this.mTGrades);
            this.Controls.Add(this.labelName);
            this.Name = "studentForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel labelName;
        private MetroFramework.Controls.MetroTile mTGrades;
        private MetroFramework.Controls.MetroTile mTAttendance;
        private MetroFramework.Controls.MetroTile mTInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGrades;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAttendance;
        private MetroFramework.Controls.MetroTile mTBack;
    }
}