namespace MainWinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            outputTextBox = new RichTextBox();
            label1 = new Label();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            fileTextBox = new TextBox();
            buttonYAML = new Button();
            buttonCSV = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(12, 311);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size(798, 201);
            outputTextBox.TabIndex = 0;
            outputTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 283);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 1;
            label1.Text = "Вывод";
            // 
            // button1
            // 
            button1.Location = new Point(12, 533);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button2
            // 
            button2.Location = new Point(256, 43);
            button2.Name = "button2";
            button2.Size = new Size(203, 33);
            button2.TabIndex = 3;
            button2.Text = "Выбор файла";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // fileTextBox
            // 
            fileTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            fileTextBox.Location = new Point(12, 42);
            fileTextBox.Name = "fileTextBox";
            fileTextBox.ReadOnly = true;
            fileTextBox.Size = new Size(238, 34);
            fileTextBox.TabIndex = 4;
            // 
            // buttonYAML
            // 
            buttonYAML.Location = new Point(12, 105);
            buttonYAML.Name = "buttonYAML";
            buttonYAML.Size = new Size(112, 34);
            buttonYAML.TabIndex = 5;
            buttonYAML.Text = "YAML";
            buttonYAML.UseVisualStyleBackColor = true;
            // 
            // buttonCSV
            // 
            buttonCSV.Location = new Point(138, 105);
            buttonCSV.Name = "buttonCSV";
            buttonCSV.Size = new Size(112, 34);
            buttonCSV.TabIndex = 6;
            buttonCSV.Text = "CSV";
            buttonCSV.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(698, 533);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 7;
            button3.Text = "Очистить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 579);
            Controls.Add(button3);
            Controls.Add(buttonCSV);
            Controls.Add(buttonYAML);
            Controls.Add(fileTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(outputTextBox);
            Name = "Form1";
            Text = "Расчет";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox outputTextBox;
        private Label label1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private TextBox fileTextBox;
        private Button buttonYAML;
        private Button buttonCSV;
        private Button button3;
    }
}