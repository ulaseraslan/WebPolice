
namespace cs408_client2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.response_box = new System.Windows.Forms.RichTextBox();
            this.port_box = new System.Windows.Forms.TextBox();
            this.request_box = new System.Windows.Forms.RichTextBox();
            this.send_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(520, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Response";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(140, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Request";
            this.label3.UseMnemonic = false;
            // 
            // response_box
            // 
            this.response_box.Location = new System.Drawing.Point(379, 77);
            this.response_box.Name = "response_box";
            this.response_box.ReadOnly = true;
            this.response_box.Size = new System.Drawing.Size(405, 426);
            this.response_box.TabIndex = 3;
            this.response_box.Text = "";
            // 
            // port_box
            // 
            this.port_box.Location = new System.Drawing.Point(99, 81);
            this.port_box.Name = "port_box";
            this.port_box.Size = new System.Drawing.Size(191, 27);
            this.port_box.TabIndex = 4;
            this.port_box.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // request_box
            // 
            this.request_box.Location = new System.Drawing.Point(36, 180);
            this.request_box.Name = "request_box";
            this.request_box.Size = new System.Drawing.Size(298, 268);
            this.request_box.TabIndex = 5;
            this.request_box.Text = "";
            // 
            // send_button
            // 
            this.send_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.send_button.Location = new System.Drawing.Point(86, 454);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(191, 49);
            this.send_button.TabIndex = 6;
            this.send_button.Text = "Send Request";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 529);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.request_box);
            this.Controls.Add(this.port_box);
            this.Controls.Add(this.response_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox response_box;
        private System.Windows.Forms.TextBox port_box;
        private System.Windows.Forms.RichTextBox request_box;
        private System.Windows.Forms.Button send_button;
    }
}

