
namespace TurnkeySystemV2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateFilebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateFilebutton
            // 
            this.CreateFilebutton.Font = new System.Drawing.Font("新細明體", 28F);
            this.CreateFilebutton.Location = new System.Drawing.Point(12, 55);
            this.CreateFilebutton.Name = "CreateFilebutton";
            this.CreateFilebutton.Size = new System.Drawing.Size(526, 63);
            this.CreateFilebutton.TabIndex = 3;
            this.CreateFilebutton.Text = "產  生  X  M  L  檔  案";
            this.CreateFilebutton.UseVisualStyleBackColor = true;
            this.CreateFilebutton.Click += new System.EventHandler(this.CreateFilebutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(550, 178);
            this.Controls.Add(this.CreateFilebutton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "電子發票轉換系統";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateFilebutton;
    }
}

