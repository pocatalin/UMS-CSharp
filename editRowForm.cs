using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIProject
{
    public partial class editRowForm : MetroForm
    {
        private UMSContext dbContext = new UMSContext();
        private DataTable dataTable;
        private DataGridViewRow selectedRow;
        private DataGridView selectedgrid;
        private adminForm adminform;
        private string tableName;
        public Dictionary<string, string> EditedValues { get; private set; }

        public editRowForm(string tableName, DataGridViewRow selectedRow, DataTable dataTable, adminForm adminform,DataGridView selectedgrid)
        {
            InitializeComponent();
            Text = $"Edit Row - {tableName}";

            this.dataTable = dataTable;
            this.tableName = tableName;
            this.selectedRow = selectedRow;
            this.selectedgrid = selectedgrid;
            fLPanel.Dock = DockStyle.Fill;
            Controls.Add(fLPanel);
            mtbSave.Click += mtbSave_Click;
            this.adminform = adminform;

            InitializeControls(tableName, selectedRow, fLPanel);
        }


        private void mtbSave_Click(object sender, EventArgs e)
        {
            EditedValues = new Dictionary<string, string>();

            if (selectedRow != null)
            {
                foreach (Control control in fLPanel.Controls)
                {
                    if (control is TableLayoutPanel tableLayoutPanel)
                    {
                        if (tableLayoutPanel.Controls.Count == 2 && tableLayoutPanel.Controls[1] is MetroTextBox textBox)
                        {
                            string columnName = tableLayoutPanel.Controls[0].Text;
                            string columnValue = textBox.Text;

                            EditedValues.Add(columnName, columnValue);
                        }
                    }
                }
                DataTable editedDataSet = ConvertToDataTable();
                adminform.UpdateDataTable(tableName, selectedRow.Index, editedDataSet.Rows[0].ItemArray,selectedgrid);

            }

            this.Close();
        }


        private DataTable ConvertToDataTable()
        {
            DataTable editedDataSet = new DataTable();

            foreach (var entry in EditedValues)
            {
                editedDataSet.Columns.Add(entry.Key, typeof(string));
            }
            DataRow row = editedDataSet.NewRow();
            foreach (var entry in EditedValues)
            {
                row[entry.Key] = entry.Value;
            }
            editedDataSet.Rows.Add(row);

            return editedDataSet;
        }



        private void InitializeControls(string tableName, DataGridViewRow selectedRow, FlowLayoutPanel fLPanel)
        {
            for (int i = 0; i < selectedRow.Cells.Count; i++)
            {
                DataGridViewCell cell = selectedRow.Cells[i];
                string columnName = cell.OwningColumn.HeaderText;
                object value = cell.Value;

                CreateLabelAndTextbox(columnName, value?.ToString(), fLPanel);
            }
        }

        private void CreateLabelAndTextbox(string labelText, string textboxText, FlowLayoutPanel fLPanel)
        {
            int maxWidth = 60;

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.AutoSize = true;

            MetroLabel label = new MetroLabel();
            label.Text = labelText;
            label.AutoSize = true;
            label.Dock = DockStyle.Left;

            int labelWidth = Math.Min(TextRenderer.MeasureText(label.Text, label.Font).Width, maxWidth / 2);
            label.Width = labelWidth;

            MetroTextBox textBox = new MetroTextBox();
            textBox.Text = textboxText;
            textBox.ReadOnly = false;
            textBox.Width = 175;
            textBox.Dock = DockStyle.Fill;

            panel.Controls.Add(label);
            panel.Controls.Add(textBox);

            fLPanel.Controls.Add(panel);
        }
    }
}