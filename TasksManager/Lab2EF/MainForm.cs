using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business_Logic_Layer;
using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;


namespace Lab2EF
{
    public partial class MainForm : Form
    {
        IDbCrud dbCrud;
        IReportsService reportsService;
        ITaskService taskService;

        //private List<TaskDTO> allTasks;
        //private List<TaskKindDTO> allTaskKinds;
        //private List<TaskStatusDTO> allTaskStatuses;

        //private readonly DbDataOperation db = new DbDataOperation();

        public MainForm(IDbCrud dbCrud_param, IReportsService reportsService_param, ITaskService taskService_param)
        {
            dbCrud = dbCrud_param;
            reportsService = reportsService_param;
            taskService = taskService_param;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // заполнение списков
            //allTasks = db.GetAllTasks();
            //allTaskKinds = db.GetAllTaskKinds();
            //allTaskKinds.Insert(0, new TaskKindDTO()); // добавление возможности выбрать вариант NULL
            //allTaskStatuses = db.GetAllTaskStatuses();
            //allTaskStatuses.Insert(0, new TaskStatusDTO()); // добавление возможности выбрать вариант NULL

            // загрузка данных в dataGridViewTasks во вкладке "Задачи"
            //db.Load();
            bindingSourceForTasks.DataSource = dbCrud.GetAllTasks();

            // заполнение TaskKindCombobox во вкладке "Задачи"
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["kindIdDataGridViewComboBoxColumn"]).DataSource = dbCrud.GetAllTaskKindsForCombobox();
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["kindIdDataGridViewComboBoxColumn"]).DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["kindIdDataGridViewComboBoxColumn"]).ValueMember = "Id";

            // заполнение TaskStatusCombobox во вкладке "Задачи"
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["statusIdDataGridViewComboBoxColumn"]).DataSource = dbCrud.GetAllTaskStatusesForCombobox();
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["statusIdDataGridViewComboBoxColumn"]).DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["statusIdDataGridViewComboBoxColumn"]).ValueMember = "Id";

            // загузка данных в dataGridViewTaskKindes во вкладке "Виды задач"
            bindingSourceForKinds.DataSource = dbCrud.GetAllTaskKinds();

            // загрузка данных в dataGridViewTaskStatuses во вкладке "Статусы задач"
            bindingSourceForStatuses.DataSource = dbCrud.GetAllTaskStatuses();

            // заполнение comboBoxTaskSelectionByType во вкладке "Выборка задачи по виду"
            comboBoxTaskSelectionByKind.DataSource = dbCrud.GetAllTaskKindsForCombobox();
            comboBoxTaskSelectionByKind.DisplayMember = "Name";
            comboBoxTaskSelectionByKind.ValueMember = "Id";

            // заполнение comboBox статусов задач в таблице во вкладке "Выборка задачи по виду"
            ((DataGridViewComboBoxColumn)dataGridViewTaskSelectionByKind.Columns["statusIdDataGridViewComboBox1Column"])
                .DataSource = dbCrud.GetAllTaskStatusesForCombobox();
            ((DataGridViewComboBoxColumn)dataGridViewTaskSelectionByKind.Columns["statusIdDataGridViewComboBox1Column"])
                .DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewTaskSelectionByKind.Columns["statusIdDataGridViewComboBox1Column"])
                .ValueMember = "Id";

            // заполнение comboBoxTaskStatusFor1stReport во вкладке "Выборка задачи по статусу"
            comboBoxTaskSelectionByStatus.DataSource = dbCrud.GetAllTaskStatusesForCombobox();
            comboBoxTaskSelectionByStatus.DisplayMember = "Name";
            comboBoxTaskSelectionByStatus.ValueMember = "Id";

            // заполнение comboBox видов задач в таблице во вкладке "Выборка задачи по статусу"
            ((DataGridViewComboBoxColumn)dataGridViewTaskSelectionByStatus.Columns["kindIdDataGridViewComboBox1Column"])
                .DataSource = dbCrud.GetAllTaskKindsForCombobox();
            ((DataGridViewComboBoxColumn)dataGridViewTaskSelectionByStatus.Columns["kindIdDataGridViewComboBox1Column"])
                .DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewTaskSelectionByStatus.Columns["kindIdDataGridViewComboBox1Column"])
                .ValueMember = "Id";

            // заполнение comboBox'ов видов задач и статусов задач во вкладке "Повторяющиеся задачи"
            ((DataGridViewComboBoxColumn)dataGridViewIsRepeatReport.Columns["kindIdDataGridViewComboBox2Column"])
                .DataSource = dbCrud.GetAllTaskKindsForCombobox();
            ((DataGridViewComboBoxColumn)dataGridViewIsRepeatReport.Columns["kindIdDataGridViewComboBox2Column"])
                .DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewIsRepeatReport.Columns["kindIdDataGridViewComboBox2Column"])
                .ValueMember = "Id";

            ((DataGridViewComboBoxColumn)dataGridViewIsRepeatReport.Columns["statusIdDataGridViewComboBox2Column"])
                .DataSource = dbCrud.GetAllTaskStatusesForCombobox();
            ((DataGridViewComboBoxColumn)dataGridViewIsRepeatReport.Columns["statusIdDataGridViewComboBox2Column"])
                .DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewIsRepeatReport.Columns["statusIdDataGridViewComboBox2Column"])
                .ValueMember = "Id";
        }

        #region Кнопки на вкладке «Задачи»
        public void buttonAddTask_Click(object sender, EventArgs e)
        {
            DialogAddTask formAddTask = new DialogAddTask(this, dbCrud);

            // вызов окна добавления задачи
            if (formAddTask.ShowDialog(this) == DialogResult.Cancel) return;
            // код завершится, если будет нажата кнопка buttonAddTaskCancel
            // код продолжится, если будет нажата кнопка buttonAddTaskOk

            dbCrud.CreateTask(formAddTask.task);

            bindingSourceForTasks.DataSource = dbCrud.GetAllTasks();
            //dataGridViewTasks.Refresh();
            dataGridViewTasks.Update();
        }

        private void buttonTaskEdit_Click(object sender, EventArgs e)
        {
            int index = GetSelectedRow(dataGridViewTasks);
            if (index != -1)
            {
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewTasks[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                

                TaskDTO t = dbCrud.GetAllTasks().Where(i => i.Id == id).FirstOrDefault();
                if (t != null)
                {
                    DialogAddTask f = new DialogAddTask(this, dbCrud);
                    f.Text = "Изменение задачи";

                    f.comboBoxAddTaskKind.DataSource = dbCrud.GetAllTaskKindsForCombobox();
                    f.comboBoxAddTaskKind.DisplayMember = "Name";
                    f.comboBoxAddTaskKind.ValueMember = "Id";
                    f.comboBoxAddTaskStatus.DataSource = dbCrud.GetAllTaskStatusesForCombobox();
                    f.comboBoxAddTaskStatus.DisplayMember = "Name";
                    f.comboBoxAddTaskStatus.ValueMember = "Id";

                    f.textBoxAddTaskName.Text = t.Name;
                    f.textBoxAddTaskDescription.Text = t.Description;
                    f.comboBoxAddTaskKind.SelectedIndex = (t.KindId == null) ? 0 : (int) t.KindId;
                    f.comboBoxAddTaskStatus.SelectedIndex = (t.StatusId == null) ? 0 : (int) t.StatusId;

                    if (t.BeginDate != null)
                        f.dateTimePickerBeginDate.Value = (DateTime)t.BeginDate;
                    else
                        f.checkBoxBeginDate.Checked = true;

                    if (t.BeginTime != null)
                        f.dateTimePickerBeginTime.Value = (DateTime)(new DateTime(1970, 01, 01) /*t.BeginDate*/ + t.BeginTime);
                    else
                        f.checkBoxBeginTime.Checked = true;

                    if (t.EndDate != null)
                        f.dateTimePickerEndDate.Value = (DateTime)(t.EndDate);
                    else
                        f.checkBoxEndDate.Checked = true;

                    if (t.EndTime != null)
                        f.dateTimePickerEndTime.Value = (DateTime)(new DateTime(1970, 01, 01) /*t.BeginDate*/ + t.EndTime);
                    else
                        f.checkBoxEndTime.Checked = true;

                    f.checkBoxIsRepeat.Checked = t.IsRepeat;

                    if (f.checkBoxIsRepeat.Checked)
                    {
                        f.numericUpDown1Days.Value = (t.RepeatIntervalDays == null)? 0 : (decimal)t.RepeatIntervalDays;
                        f.numericUpDown1Weeks.Value = (t.RepeatIntervalWeeks == null)? 0 : (decimal)t.RepeatIntervalWeeks;
                        f.numericUpDown1Months.Value = (t.RepeatIntervalMonths == null)? 0 : (decimal)t.RepeatIntervalMonths;
                        f.numericUpDown1Years.Value = (t.RepeatIntervalYears == null)? 0 : (decimal)t.RepeatIntervalYears;
                    }



                    DialogResult result = f.ShowDialog();

                    if (result == DialogResult.Cancel)
                        return;

                    t.Name = f.textBoxAddTaskName.Text;
                    t.Description = f.textBoxAddTaskDescription.Text;

                    if (f.comboBoxAddTaskKind.SelectedIndex != 0)
                        t.KindId = f.comboBoxAddTaskKind.SelectedIndex;
                    else
                        t.KindId = null;

                    if (f.comboBoxAddTaskStatus.SelectedIndex != 0)
                        t.StatusId = f.comboBoxAddTaskStatus.SelectedIndex;
                    else
                        t.StatusId = null;

                    if (!f.checkBoxBeginDate.Checked)
                    {
                        t.BeginDate = f.dateTimePickerBeginDate.Value.Date;
                    }
                    else
                    {
                        t.BeginDate = null;
                    }

                    if (!f.checkBoxBeginTime.Checked)
                    {
                        t.BeginTime = f.dateTimePickerBeginTime.Value.TimeOfDay;
                    }
                    else
                    {
                        t.BeginTime = null;
                    }

                    if (!f.checkBoxEndDate.Checked)
                    {
                        t.EndDate = f.dateTimePickerEndDate.Value.Date;
                    }
                    else
                    {
                        t.EndDate = null;
                    }

                    if (!f.checkBoxEndTime.Checked)
                    {
                        t.EndTime = f.dateTimePickerEndTime.Value.TimeOfDay;
                    }
                    else
                    {
                        t.EndTime = null;
                    }

                    t.IsRepeat = f.checkBoxIsRepeat.Checked;

                    if (t.IsRepeat)
                    {
                        t.RepeatIntervalDays = (int?)f.numericUpDown1Days.Value;
                        t.RepeatIntervalWeeks = (int?)f.numericUpDown1Weeks.Value;
                        t.RepeatIntervalMonths = (int?)f.numericUpDown1Months.Value;
                        t.RepeatIntervalYears = (int?)f.numericUpDown1Years.Value;
                    }
                    else
                    {
                        t.RepeatIntervalDays = null;
                        t.RepeatIntervalWeeks = null;
                        t.RepeatIntervalMonths = null;
                        t.RepeatIntervalYears = null;
                    }

                    dbCrud.UpdateTask(t);
                    bindingSourceForTasks.DataSource = dbCrud.GetAllTasks();
                    dataGridViewTasks.Update();
                    //MessageBox.Show("Объект обновлен");
                }
            }
            else
            {
                MessageBox.Show("Ни один объект не выбран!");
            }
        }

        private void buttonTaskDelete_Click(object sender, EventArgs e)
        {
            int index = GetSelectedRow(dataGridViewTasks);
            if (index != -1)
            {
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewTasks[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                dbCrud.DeleteTask(id);
                bindingSourceForTasks.DataSource = dbCrud.GetAllTasks();
            }
        }

        private void buttonTaskUpdate_Click(object sender, EventArgs e)
        {
            bindingSourceForTasks.DataSource = dbCrud.GetAllTasks();
            dataGridViewTasks.Refresh();
            dataGridViewTasks.Update();

            // FillTaskKindComboboxInTaskTab
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["kindIdDataGridViewComboBoxColumn"]).DataSource = dbCrud.GetAllTaskKinds();
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["kindIdDataGridViewComboBoxColumn"]).DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["kindIdDataGridViewComboBoxColumn"]).ValueMember = "Id";

            // FillTaskStatusComboboxInTaskTab
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["statusIdDataGridViewComboBoxColumn"]).DataSource = dbCrud.GetAllTaskStatuses();
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["statusIdDataGridViewComboBoxColumn"]).DisplayMember = "Name";
            ((DataGridViewComboBoxColumn)dataGridViewTasks.Columns["statusIdDataGridViewComboBoxColumn"]).ValueMember = "Id";
        }

        //private void buttonSaveTasks_Click(object sender, EventArgs e)
        //{
        //    if (Validate())
        //    {
        //        dbCrud.Save();
        //        bindingSourceForTasks.DataSource = dbCrud.GetAllTasks();
        //        dataGridViewTasks.Refresh();
        //    }
        //}
        #endregion

        #region Кнопки на вкладке «Выборка задачи по виду»
        private void buttonTaskSelectionByKind_Click(object sender, EventArgs e)
        {
            dataGridViewTaskSelectionByKind.DataSource = reportsService.ReportSelectionByKind(comboBoxTaskSelectionByKind.SelectedIndex);
        }
        #endregion

        #region Кнопки на вкладке «Выборка задачи по статусу»
        private void buttonTaskSelectionByStatus_Click(object sender, EventArgs e)
        {
            dataGridViewTaskSelectionByStatus.DataSource = reportsService.ReportSelectionByStatus(comboBoxTaskSelectionByStatus.SelectedIndex);
        }
        #endregion

        #region Кнопки на вкладке «Повторяющиеся задачи»
        private void buttonIsRepeatReport_Click(object sender, EventArgs e)
        {
            dataGridViewIsRepeatReport.DataSource = reportsService.ReportSelectionByRepeatability(!radioButton1_IsRepeatReport.Checked);
        }
        #endregion

        // вспомогательные методы
        private int GetSelectedRow(DataGridView dataGridView)
        {
            int index = -1;
            if (dataGridView.SelectedRows.Count > 0 || dataGridView.SelectedCells.Count == 1)
            {
                if (dataGridView.SelectedRows.Count > 0)
                    index = dataGridView.SelectedRows[0].Index;
                else index = dataGridView.SelectedCells[0].RowIndex;
            }
            return index;
        }
    }
}