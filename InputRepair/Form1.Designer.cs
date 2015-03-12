namespace InputRepair
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btn = new System.Windows.Forms.Button();
            this.cbLayoutList = new System.Windows.Forms.CheckedListBox();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnSaveToXML = new System.Windows.Forms.Button();
            this.cbActivateAutoDel = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cbLoadedLayout = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(12, 187);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(99, 23);
            this.btn.TabIndex = 0;
            this.btn.Text = "Обновить список";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbLayoutList
            // 
            this.cbLayoutList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbLayoutList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLayoutList.FormattingEnabled = true;
            this.cbLayoutList.Location = new System.Drawing.Point(13, 11);
            this.cbLayoutList.Name = "cbLayoutList";
            this.cbLayoutList.Size = new System.Drawing.Size(185, 170);
            this.cbLayoutList.TabIndex = 1;
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 60000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(12, 245);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(99, 23);
            this.btnDeleteSelected.TabIndex = 2;
            this.btnDeleteSelected.Text = "Удалить";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnSaveToXML
            // 
            this.btnSaveToXML.Location = new System.Drawing.Point(12, 216);
            this.btnSaveToXML.Name = "btnSaveToXML";
            this.btnSaveToXML.Size = new System.Drawing.Size(99, 23);
            this.btnSaveToXML.TabIndex = 3;
            this.btnSaveToXML.Text = "Сохранить";
            this.btnSaveToXML.UseVisualStyleBackColor = true;
            this.btnSaveToXML.Click += new System.EventHandler(this.btnSaveToXML_Click);
            // 
            // cbActivateAutoDel
            // 
            this.cbActivateAutoDel.AutoSize = true;
            this.cbActivateAutoDel.Location = new System.Drawing.Point(118, 192);
            this.cbActivateAutoDel.Name = "cbActivateAutoDel";
            this.cbActivateAutoDel.Size = new System.Drawing.Size(97, 17);
            this.cbActivateAutoDel.TabIndex = 4;
            this.cbActivateAutoDel.Text = "Автоконтроль";
            this.cbActivateAutoDel.UseVisualStyleBackColor = true;
            this.cbActivateAutoDel.CheckedChanged += new System.EventHandler(this.cbActivateAutoDel_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(118, 222);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "reserved";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // cbLoadedLayout
            // 
            this.cbLoadedLayout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbLoadedLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLoadedLayout.FormattingEnabled = true;
            this.cbLoadedLayout.Location = new System.Drawing.Point(204, 11);
            this.cbLoadedLayout.Name = "cbLoadedLayout";
            this.cbLoadedLayout.Size = new System.Drawing.Size(185, 170);
            this.cbLoadedLayout.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 281);
            this.Controls.Add(this.cbLoadedLayout);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.cbActivateAutoDel);
            this.Controls.Add(this.btnSaveToXML);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.cbLayoutList);
            this.Controls.Add(this.btn);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Минимастер раскладок";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.CheckedListBox cbLayoutList;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnSaveToXML;
        private System.Windows.Forms.CheckBox cbActivateAutoDel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckedListBox cbLoadedLayout;
    }
}

