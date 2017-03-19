namespace Triangulation_
{
    partial class Triangulation_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Triangulation_Form));
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.trianglePictureBox = new System.Windows.Forms.PictureBox();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.triangleButton = new System.Windows.Forms.Button();
            this.paintButton = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.brightnessLimit = new System.Windows.Forms.NumericUpDown();
            this.fragmentationLimit = new System.Windows.Forms.NumericUpDown();
            this.redPictureBox = new System.Windows.Forms.PictureBox();
            this.pointPictureBox = new System.Windows.Forms.PictureBox();
            this.simButton = new System.Windows.Forms.Button();
            this.brightnessTextBox = new System.Windows.Forms.TextBox();
            this.zoomCoeff = new System.Windows.Forms.NumericUpDown();
            this.greenPictureBox = new System.Windows.Forms.PictureBox();
            this.bluePictureBox = new System.Windows.Forms.PictureBox();
            this.processButton = new System.Windows.Forms.Button();
            this.limitTextBox = new System.Windows.Forms.TextBox();
            this.limitButton = new System.Windows.Forms.Button();
            this.zoomCoeffTrackBar = new System.Windows.Forms.TrackBar();
            this.segmentPictureBox = new System.Windows.Forms.PictureBox();
            this.antiAliasСheckBox = new System.Windows.Forms.CheckBox();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.toolTipMainForm = new System.Windows.Forms.ToolTip(this.components);
            this.skoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trianglePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentationLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomCoeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomCoeffTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Image = global::Triangulation_.Properties.Resources.otherButton1;
            this.saveButton.Location = new System.Drawing.Point(20, 779);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 35);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.toolTipMainForm.SetToolTip(this.saveButton, "Сохранить результат");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.BackgroundImage = global::Triangulation_.Properties.Resources.openButton1;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openButton.ForeColor = System.Drawing.Color.Black;
            this.openButton.Location = new System.Drawing.Point(18, 18);
            this.openButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(112, 35);
            this.openButton.TabIndex = 4;
            this.openButton.Text = "Открыть";
            this.toolTipMainForm.SetToolTip(this.openButton, "Открыть новое изображение");
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPictureBox.Location = new System.Drawing.Point(1313, 18);
            this.resultPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(383, 393);
            this.resultPictureBox.TabIndex = 3;
            this.resultPictureBox.TabStop = false;
            // 
            // trianglePictureBox
            // 
            this.trianglePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trianglePictureBox.Location = new System.Drawing.Point(922, 18);
            this.trianglePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trianglePictureBox.Name = "trianglePictureBox";
            this.trianglePictureBox.Size = new System.Drawing.Size(383, 393);
            this.trianglePictureBox.TabIndex = 2;
            this.trianglePictureBox.TabStop = false;
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalPictureBox.Location = new System.Drawing.Point(140, 18);
            this.originalPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(383, 393);
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            this.toolTipMainForm.SetToolTip(this.originalPictureBox, "Исходное изображение (выберите сегмент)");
            // 
            // triangleButton
            // 
            this.triangleButton.BackgroundImage = global::Triangulation_.Properties.Resources.otherButton1;
            this.triangleButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.triangleButton.Location = new System.Drawing.Point(18, 139);
            this.triangleButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(112, 35);
            this.triangleButton.TabIndex = 7;
            this.triangleButton.Text = "Трианг.";
            this.toolTipMainForm.SetToolTip(this.triangleButton, "Произвести триангуляцию по заданному набору точек");
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // paintButton
            // 
            this.paintButton.BackgroundImage = global::Triangulation_.Properties.Resources.otherButton1;
            this.paintButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paintButton.Location = new System.Drawing.Point(18, 184);
            this.paintButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.paintButton.Name = "paintButton";
            this.paintButton.Size = new System.Drawing.Size(112, 35);
            this.paintButton.TabIndex = 8;
            this.paintButton.Text = "Закрасить";
            this.toolTipMainForm.SetToolTip(this.paintButton, "Произвести закраску построенной триангуляции");
            this.paintButton.UseVisualStyleBackColor = true;
            this.paintButton.Click += new System.EventHandler(this.paintButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.BackgroundImage = global::Triangulation_.Properties.Resources.otherButton1;
            this.cleanButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cleanButton.Location = new System.Drawing.Point(20, 734);
            this.cleanButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(112, 35);
            this.cleanButton.TabIndex = 9;
            this.cleanButton.Text = "Очистить";
            this.toolTipMainForm.SetToolTip(this.cleanButton, "Произвести очистку всех полей формы за исключением исходного изображения");
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Имя файла";
            // 
            // brightnessLimit
            // 
            this.brightnessLimit.BackColor = System.Drawing.Color.PaleGreen;
            this.brightnessLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brightnessLimit.Location = new System.Drawing.Point(18, 103);
            this.brightnessLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.brightnessLimit.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.brightnessLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brightnessLimit.Name = "brightnessLimit";
            this.brightnessLimit.Size = new System.Drawing.Size(112, 26);
            this.brightnessLimit.TabIndex = 10;
            this.toolTipMainForm.SetToolTip(this.brightnessLimit, "Дельта");
            this.brightnessLimit.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // fragmentationLimit
            // 
            this.fragmentationLimit.BackColor = System.Drawing.Color.PaleTurquoise;
            this.fragmentationLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fragmentationLimit.Location = new System.Drawing.Point(18, 63);
            this.fragmentationLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fragmentationLimit.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.fragmentationLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fragmentationLimit.Name = "fragmentationLimit";
            this.fragmentationLimit.Size = new System.Drawing.Size(112, 26);
            this.fragmentationLimit.TabIndex = 11;
            this.fragmentationLimit.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // redPictureBox
            // 
            this.redPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redPictureBox.Location = new System.Drawing.Point(531, 421);
            this.redPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.redPictureBox.Name = "redPictureBox";
            this.redPictureBox.Size = new System.Drawing.Size(383, 393);
            this.redPictureBox.TabIndex = 13;
            this.redPictureBox.TabStop = false;
            // 
            // pointPictureBox
            // 
            this.pointPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pointPictureBox.Location = new System.Drawing.Point(531, 18);
            this.pointPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pointPictureBox.Name = "pointPictureBox";
            this.pointPictureBox.Size = new System.Drawing.Size(383, 393);
            this.pointPictureBox.TabIndex = 14;
            this.pointPictureBox.TabStop = false;
            // 
            // simButton
            // 
            this.simButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.simButton.Image = global::Triangulation_.Properties.Resources.otherButton1;
            this.simButton.Location = new System.Drawing.Point(18, 274);
            this.simButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simButton.Name = "simButton";
            this.simButton.Size = new System.Drawing.Size(112, 35);
            this.simButton.TabIndex = 15;
            this.simButton.Text = "Упростить";
            this.toolTipMainForm.SetToolTip(this.simButton, "Объединить квадраты с (примерно одинаковыми) яркостями, различающимися на дельту," +
        " в более крупные квадраты-области");
            this.simButton.UseVisualStyleBackColor = true;
            this.simButton.Click += new System.EventHandler(this.simButtonClick);
            // 
            // brightnessTextBox
            // 
            this.brightnessTextBox.Location = new System.Drawing.Point(18, 822);
            this.brightnessTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.brightnessTextBox.Name = "brightnessTextBox";
            this.brightnessTextBox.Size = new System.Drawing.Size(268, 26);
            this.brightnessTextBox.TabIndex = 17;
            this.toolTipMainForm.SetToolTip(this.brightnessTextBox, "Диапазоны яркостей, по которым будет произведена проверка принадлежности яркости " +
        "пикселей каждому из диапазонов");
            this.brightnessTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.brightnessTextBox_MouseClick);
            // 
            // zoomCoeff
            // 
            this.zoomCoeff.BackColor = System.Drawing.Color.White;
            this.zoomCoeff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomCoeff.Location = new System.Drawing.Point(18, 319);
            this.zoomCoeff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zoomCoeff.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zoomCoeff.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomCoeff.Name = "zoomCoeff";
            this.zoomCoeff.Size = new System.Drawing.Size(112, 26);
            this.zoomCoeff.TabIndex = 18;
            this.toolTipMainForm.SetToolTip(this.zoomCoeff, "Коэффициент увеличения выбранного сегмента");
            this.zoomCoeff.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.zoomCoeff.ValueChanged += new System.EventHandler(this.zoomCoeff_ValueChanged);
            // 
            // greenPictureBox
            // 
            this.greenPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenPictureBox.Location = new System.Drawing.Point(922, 421);
            this.greenPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.greenPictureBox.Name = "greenPictureBox";
            this.greenPictureBox.Size = new System.Drawing.Size(383, 393);
            this.greenPictureBox.TabIndex = 19;
            this.greenPictureBox.TabStop = false;
            // 
            // bluePictureBox
            // 
            this.bluePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bluePictureBox.Location = new System.Drawing.Point(1313, 421);
            this.bluePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bluePictureBox.Name = "bluePictureBox";
            this.bluePictureBox.Size = new System.Drawing.Size(383, 393);
            this.bluePictureBox.TabIndex = 20;
            this.bluePictureBox.TabStop = false;
            // 
            // processButton
            // 
            this.processButton.BackgroundImage = global::Triangulation_.Properties.Resources.otherButton1;
            this.processButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.processButton.Location = new System.Drawing.Point(18, 229);
            this.processButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(112, 35);
            this.processButton.TabIndex = 21;
            this.processButton.Text = "Обработать";
            this.toolTipMainForm.SetToolTip(this.processButton, resources.GetString("processButton.ToolTip"));
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // limitTextBox
            // 
            this.limitTextBox.Location = new System.Drawing.Point(18, 862);
            this.limitTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.limitTextBox.Name = "limitTextBox";
            this.limitTextBox.Size = new System.Drawing.Size(216, 26);
            this.limitTextBox.TabIndex = 22;
            this.toolTipMainForm.SetToolTip(this.limitTextBox, "Диапазон яркостей, по коротому будут выведены пиксели, принадлежащие именно указа" +
        "нному диапазону (необходимо ввести 2 значения)");
            this.limitTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.limitTextBox_MouseClick);
            // 
            // limitButton
            // 
            this.limitButton.BackgroundImage = global::Triangulation_.Properties.Resources.otherButton1;
            this.limitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.limitButton.Location = new System.Drawing.Point(244, 862);
            this.limitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.limitButton.Name = "limitButton";
            this.limitButton.Size = new System.Drawing.Size(44, 31);
            this.limitButton.TabIndex = 23;
            this.limitButton.Text = "ok";
            this.toolTipMainForm.SetToolTip(this.limitButton, "Принять данные на обработку");
            this.limitButton.UseVisualStyleBackColor = true;
            this.limitButton.Click += new System.EventHandler(this.limitButton_Click);
            // 
            // zoomCoeffTrackBar
            // 
            this.zoomCoeffTrackBar.Location = new System.Drawing.Point(18, 353);
            this.zoomCoeffTrackBar.Maximum = 15;
            this.zoomCoeffTrackBar.Minimum = 1;
            this.zoomCoeffTrackBar.Name = "zoomCoeffTrackBar";
            this.zoomCoeffTrackBar.Size = new System.Drawing.Size(112, 69);
            this.zoomCoeffTrackBar.TabIndex = 24;
            this.toolTipMainForm.SetToolTip(this.zoomCoeffTrackBar, "Коэффициент увеличения выбранного сегмента");
            this.zoomCoeffTrackBar.Value = 2;
            this.zoomCoeffTrackBar.Scroll += new System.EventHandler(this.zoomCoeffTrackBar_Scroll);
            // 
            // segmentPictureBox
            // 
            this.segmentPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.segmentPictureBox.Location = new System.Drawing.Point(140, 421);
            this.segmentPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.segmentPictureBox.Name = "segmentPictureBox";
            this.segmentPictureBox.Size = new System.Drawing.Size(383, 393);
            this.segmentPictureBox.TabIndex = 25;
            this.segmentPictureBox.TabStop = false;
            this.segmentPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.segmentPictureBox_MouseClick);
            // 
            // antiAliasСheckBox
            // 
            this.antiAliasСheckBox.AutoSize = true;
            this.antiAliasСheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.antiAliasСheckBox.Location = new System.Drawing.Point(18, 398);
            this.antiAliasСheckBox.Name = "antiAliasСheckBox";
            this.antiAliasСheckBox.Size = new System.Drawing.Size(107, 24);
            this.antiAliasСheckBox.TabIndex = 26;
            this.antiAliasСheckBox.Text = " сгладить";
            this.toolTipMainForm.SetToolTip(this.antiAliasСheckBox, "Произвести увеличение со сглаживанием (в случае, если флажок не установлен, произ" +
        "водится увеличение с четкой пикселизацией)");
            this.antiAliasСheckBox.UseVisualStyleBackColor = true;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(319, 843);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(538, 26);
            this.infoTextBox.TabIndex = 27;
            this.toolTipMainForm.SetToolTip(this.infoTextBox, "Информация: проверка корректности построенной триангуляции");
            // 
            // skoButton
            // 
            this.skoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.skoButton.Location = new System.Drawing.Point(18, 473);
            this.skoButton.Name = "skoButton";
            this.skoButton.Size = new System.Drawing.Size(112, 35);
            this.skoButton.TabIndex = 28;
            this.skoButton.Text = "СКО";
            this.skoButton.UseVisualStyleBackColor = true;
            this.skoButton.Click += new System.EventHandler(this.skoButton_Click);
            // 
            // Triangulation_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1724, 902);
            this.Controls.Add(this.skoButton);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.segmentPictureBox);
            this.Controls.Add(this.redPictureBox);
            this.Controls.Add(this.greenPictureBox);
            this.Controls.Add(this.pointPictureBox);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.trianglePictureBox);
            this.Controls.Add(this.antiAliasСheckBox);
            this.Controls.Add(this.zoomCoeffTrackBar);
            this.Controls.Add(this.limitButton);
            this.Controls.Add(this.limitTextBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.bluePictureBox);
            this.Controls.Add(this.zoomCoeff);
            this.Controls.Add(this.brightnessTextBox);
            this.Controls.Add(this.simButton);
            this.Controls.Add(this.fragmentationLimit);
            this.Controls.Add(this.brightnessLimit);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.paintButton);
            this.Controls.Add(this.triangleButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.originalPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1746, 957);
            this.MinimumSize = new System.Drawing.Size(1746, 957);
            this.Name = "Triangulation_Form";
            this.Text = "Триангуляция";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trianglePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentationLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomCoeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomCoeffTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.PictureBox trianglePictureBox;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.Button paintButton;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NumericUpDown brightnessLimit;
        private System.Windows.Forms.NumericUpDown fragmentationLimit;
        private System.Windows.Forms.PictureBox redPictureBox;
        private System.Windows.Forms.PictureBox pointPictureBox;
        private System.Windows.Forms.Button simButton;
        private System.Windows.Forms.TextBox brightnessTextBox;
        private System.Windows.Forms.NumericUpDown zoomCoeff;
        private System.Windows.Forms.PictureBox greenPictureBox;
        private System.Windows.Forms.PictureBox bluePictureBox;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.TextBox limitTextBox;
        private System.Windows.Forms.Button limitButton;
        private System.Windows.Forms.TrackBar zoomCoeffTrackBar;
        private System.Windows.Forms.PictureBox segmentPictureBox;
        private System.Windows.Forms.CheckBox antiAliasСheckBox;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.ToolTip toolTipMainForm;
        private System.Windows.Forms.Button skoButton;
    }
}

