namespace Laba_5
{
    partial class Form1
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
            this.usbList = new System.Windows.Forms.DataGridView();
            this.disableButton = new System.Windows.Forms.Button();
            this.spaceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.enableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usbList)).BeginInit();
            this.SuspendLayout();
            // 
            // usbList
            // 
            this.usbList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usbList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.usbList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usbList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usbList.Location = new System.Drawing.Point(12, 12);
            this.usbList.Name = "usbList";
            this.usbList.Size = new System.Drawing.Size(317, 204);
            this.usbList.TabIndex = 0;
            this.usbList.SelectionChanged += new System.EventHandler(this.ChangeSelect);
            // 
            // disableButton
            // 
            this.disableButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disableButton.Location = new System.Drawing.Point(586, 222);
            this.disableButton.Name = "disableButton";
            this.disableButton.Size = new System.Drawing.Size(87, 24);
            this.disableButton.TabIndex = 1;
            this.disableButton.Text = "Отключить";
            this.disableButton.UseVisualStyleBackColor = true;
            this.disableButton.Click += new System.EventHandler(this.DisableButton);
            // 
            // spaceTextBox
            // 
            this.spaceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spaceTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spaceTextBox.Location = new System.Drawing.Point(335, 12);
            this.spaceTextBox.Multiline = true;
            this.spaceTextBox.Name = "spaceTextBox";
            this.spaceTextBox.Size = new System.Drawing.Size(338, 204);
            this.spaceTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // enableButton
            // 
            this.enableButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enableButton.Location = new System.Drawing.Point(493, 222);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(87, 24);
            this.enableButton.TabIndex = 4;
            this.enableButton.Text = "Включить";
            this.enableButton.UseVisualStyleBackColor = true;
            this.enableButton.Click += new System.EventHandler(this.EnableButton);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(685, 258);
            this.Controls.Add(this.enableButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spaceTextBox);
            this.Controls.Add(this.disableButton);
            this.Controls.Add(this.usbList);
            this.Name = "Form1";
            this.Text = "USB Manager";
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.usbList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usbList;
        private System.Windows.Forms.Button disableButton;
        private System.Windows.Forms.TextBox spaceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button enableButton;
    }
}

