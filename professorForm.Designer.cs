namespace PIProject
{
    partial class professorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelName = new MetroFramework.Controls.MetroLabel();
            this.metroGridGrades = new MetroFramework.Controls.MetroGrid();
            this.metroComboBoxGrades = new MetroFramework.Controls.MetroComboBox();
            this.flowLayoutPanelViewGrades = new System.Windows.Forms.FlowLayoutPanel();
            this.metroComboBoxAttendance = new MetroFramework.Controls.MetroComboBox();
            this.flowLayoutPanelAttedance = new System.Windows.Forms.FlowLayoutPanel();
            this.mtGrades = new MetroFramework.Controls.MetroButton();
            this.mtAttendance = new MetroFramework.Controls.MetroButton();
            this.mtData = new MetroFramework.Controls.MetroButton();
            this.mtBack = new MetroFramework.Controls.MetroButton();
            this.metroGrid = new MetroFramework.Controls.MetroGrid();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.labelName.Location = new System.Drawing.Point(23, 14);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(111, 25);
            this.labelName.Style = MetroFramework.MetroColorStyle.Green;
            this.labelName.TabIndex = 0;
            this.labelName.Text = "metroLabel1";
            this.labelName.UseStyleColors = true;
            // 
            // metroGridGrades
            // 
            this.metroGridGrades.AllowUserToResizeRows = false;
            this.metroGridGrades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGridGrades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGridGrades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridGrades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGridGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGridGrades.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGridGrades.EnableHeadersVisualStyles = false;
            this.metroGridGrades.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGridGrades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridGrades.Location = new System.Drawing.Point(215, 63);
            this.metroGridGrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroGridGrades.Name = "metroGridGrades";
            this.metroGridGrades.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridGrades.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGridGrades.RowHeadersWidth = 51;
            this.metroGridGrades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGridGrades.RowTemplate.Height = 24;
            this.metroGridGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGridGrades.Size = new System.Drawing.Size(762, 464);
            this.metroGridGrades.Style = MetroFramework.MetroColorStyle.Green;
            this.metroGridGrades.TabIndex = 10;
            this.metroGridGrades.UseStyleColors = true;
            // 
            // metroComboBoxGrades
            // 
            this.metroComboBoxGrades.FormattingEnabled = true;
            this.metroComboBoxGrades.ItemHeight = 24;
            this.metroComboBoxGrades.Location = new System.Drawing.Point(581, 14);
            this.metroComboBoxGrades.Margin = new System.Windows.Forms.Padding(4);
            this.metroComboBoxGrades.Name = "metroComboBoxGrades";
            this.metroComboBoxGrades.Size = new System.Drawing.Size(186, 30);
            this.metroComboBoxGrades.TabIndex = 14;
            this.metroComboBoxGrades.UseSelectable = true;
            // 
            // flowLayoutPanelViewGrades
            // 
            this.flowLayoutPanelViewGrades.Location = new System.Drawing.Point(733, 110);
            this.flowLayoutPanelViewGrades.Name = "flowLayoutPanelViewGrades";
            this.flowLayoutPanelViewGrades.Size = new System.Drawing.Size(186, 417);
            this.flowLayoutPanelViewGrades.TabIndex = 15;
            // 
            // metroComboBoxAttendance
            // 
            this.metroComboBoxAttendance.FormattingEnabled = true;
            this.metroComboBoxAttendance.ItemHeight = 24;
            this.metroComboBoxAttendance.Location = new System.Drawing.Point(482, 69);
            this.metroComboBoxAttendance.Name = "metroComboBoxAttendance";
            this.metroComboBoxAttendance.Size = new System.Drawing.Size(186, 30);
            this.metroComboBoxAttendance.TabIndex = 17;
            this.metroComboBoxAttendance.UseSelectable = true;
            // 
            // flowLayoutPanelAttedance
            // 
            this.flowLayoutPanelAttedance.Location = new System.Drawing.Point(334, 105);
            this.flowLayoutPanelAttedance.Name = "flowLayoutPanelAttedance";
            this.flowLayoutPanelAttedance.Size = new System.Drawing.Size(186, 417);
            this.flowLayoutPanelAttedance.TabIndex = 18;
            // 
            // mtGrades
            // 
            this.mtGrades.Location = new System.Drawing.Point(23, 63);
            this.mtGrades.Name = "mtGrades";
            this.mtGrades.Size = new System.Drawing.Size(120, 40);
            this.mtGrades.Style = MetroFramework.MetroColorStyle.Green;
            this.mtGrades.TabIndex = 19;
            this.mtGrades.Text = "Grades";
            this.mtGrades.UseSelectable = true;
            this.mtGrades.UseStyleColors = true;
            // 
            // mtAttendance
            // 
            this.mtAttendance.Location = new System.Drawing.Point(23, 109);
            this.mtAttendance.Name = "mtAttendance";
            this.mtAttendance.Size = new System.Drawing.Size(120, 40);
            this.mtAttendance.Style = MetroFramework.MetroColorStyle.Green;
            this.mtAttendance.TabIndex = 20;
            this.mtAttendance.Text = "Attedance";
            this.mtAttendance.UseSelectable = true;
            this.mtAttendance.UseStyleColors = true;
            // 
            // mtData
            // 
            this.mtData.Location = new System.Drawing.Point(23, 155);
            this.mtData.Name = "mtData";
            this.mtData.Size = new System.Drawing.Size(120, 40);
            this.mtData.Style = MetroFramework.MetroColorStyle.Green;
            this.mtData.TabIndex = 21;
            this.mtData.Text = "Data";
            this.mtData.UseSelectable = true;
            this.mtData.UseStyleColors = true;
            // 
            // mtBack
            // 
            this.mtBack.Location = new System.Drawing.Point(149, 63);
            this.mtBack.Name = "mtBack";
            this.mtBack.Size = new System.Drawing.Size(60, 40);
            this.mtBack.Style = MetroFramework.MetroColorStyle.Green;
            this.mtBack.TabIndex = 22;
            this.mtBack.Text = "Back";
            this.mtBack.UseSelectable = true;
            this.mtBack.UseStyleColors = true;
            // 
            // metroGrid
            // 
            this.metroGrid.AllowUserToResizeRows = false;
            this.metroGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid.EnableHeadersVisualStyles = false;
            this.metroGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.Location = new System.Drawing.Point(215, 63);
            this.metroGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroGrid.Name = "metroGrid";
            this.metroGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid.RowHeadersWidth = 51;
            this.metroGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid.RowTemplate.Height = 24;
            this.metroGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid.Size = new System.Drawing.Size(762, 464);
            this.metroGrid.Style = MetroFramework.MetroColorStyle.Green;
            this.metroGrid.TabIndex = 23;
            this.metroGrid.UseStyleColors = true;
            // 
            // professorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.metroGrid);
            this.Controls.Add(this.mtAttendance);
            this.Controls.Add(this.metroComboBoxGrades);
            this.Controls.Add(this.flowLayoutPanelAttedance);
            this.Controls.Add(this.flowLayoutPanelViewGrades);
            this.Controls.Add(this.mtBack);
            this.Controls.Add(this.mtData);
            this.Controls.Add(this.mtGrades);
            this.Controls.Add(this.metroComboBoxAttendance);
            this.Controls.Add(this.metroGridGrades);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "professorForm";
            this.Padding = new System.Windows.Forms.Padding(20, 74, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Green;
            ((System.ComponentModel.ISupportInitialize)(this.metroGridGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel labelName;
        private MetroFramework.Controls.MetroGrid metroGridGrades;
        private MetroFramework.Controls.MetroComboBox metroComboBoxGrades;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelViewGrades;
        private MetroFramework.Controls.MetroComboBox metroComboBoxAttendance;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAttedance;
        private MetroFramework.Controls.MetroButton mtGrades;
        private MetroFramework.Controls.MetroButton mtAttendance;
        private MetroFramework.Controls.MetroButton mtData;
        private MetroFramework.Controls.MetroButton mtBack;
        private MetroFramework.Controls.MetroGrid metroGrid;
    }
}