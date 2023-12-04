using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Data_Access_Layer.EF;
using Business_Logic_Layer;
using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Interfaces;

namespace Lab2EF
{
    public partial class DialogAddTask : Form
    {
        private MainForm MainForm;
        public TaskDTO task;

        public DialogAddTask(MainForm mainForm, IDbCrud dbCrud)
        {
            InitializeComponent();
            MainForm = mainForm;

            comboBoxAddTaskStatus.DataSource = dbCrud.GetAllTaskStatusesForCombobox();
            comboBoxAddTaskStatus.ValueMember = "Id";
            comboBoxAddTaskStatus.DisplayMember = "Name";

            comboBoxAddTaskKind.DataSource = dbCrud.GetAllTaskKindsForCombobox();
            comboBoxAddTaskKind.ValueMember = "Id";
            comboBoxAddTaskKind.DisplayMember = "Name";
        }

        private void buttonAddTaskOk_Click(object sender, EventArgs e)
        {
            task = new TaskDTO();

            task.Name = textBoxAddTaskName.Text;
            task.Description = textBoxAddTaskDescription.Text;

            if (comboBoxAddTaskStatus.SelectedIndex != 0 && comboBoxAddTaskStatus.SelectedIndex != -1)
            {
                task.StatusId = comboBoxAddTaskStatus.SelectedIndex;
            }

            if (comboBoxAddTaskKind.SelectedIndex != 0 && comboBoxAddTaskKind.SelectedIndex != -1)
            {
                task.KindId = comboBoxAddTaskKind.SelectedIndex;
            }

            if(!checkBoxBeginDate.Checked)
                task.BeginDate = dateTimePickerBeginDate.Value.Date;
            if(!checkBoxBeginTime.Checked)
                task.BeginTime = dateTimePickerBeginTime.Value.TimeOfDay;
            if(!checkBoxEndDate.Checked)
                task.EndDate = dateTimePickerEndDate.Value.Date;
            if(!checkBoxEndTime.Checked)
                task.EndTime = dateTimePickerEndTime.Value.TimeOfDay;

            task.IsRepeat = checkBoxIsRepeat.Checked;
            if (task.IsRepeat)
            {
                task.RepeatIntervalDays = (int?)numericUpDown1Days.Value;
                task.RepeatIntervalWeeks = (int?)numericUpDown1Weeks.Value;
                task.RepeatIntervalMonths = (int?)numericUpDown1Months.Value;
                task.RepeatIntervalYears = (int?)numericUpDown1Years.Value;

                //switch (comboBoxAddTaskInvervalType.SelectedIndex)
                //{
                //    case 0: // в днях
                //        task.RepeatIntervalDays = (int)numericUpDownAddTaskInterval.Value;
                //        break;
                //    case 1: // в неделях
                //        task.RepeatIntervalWeeks = (int)numericUpDownAddTaskInterval.Value;
                //        break;
                //    case 2: // в месяцах
                //        task.RepeatIntervalMonths = (int)numericUpDownAddTaskInterval.Value;
                //        break;
                //    case 3: // в годах
                //        task.RepeatIntervalYears = (int)numericUpDownAddTaskInterval.Value;
                //        break;
                //}
            }
        }
    }
}
