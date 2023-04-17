
namespace OlRedraw
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.olSwitchBox1 = new OlRedraw.Control.OlSwitchBox();
            this.olCheckBox1 = new OlRedraw.Control.OlCheckBox();
            this.SuspendLayout();
            // 
            // olSwitchBox1
            // 
            resources.ApplyResources(this.olSwitchBox1, "olSwitchBox1");
            this.olSwitchBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.olSwitchBox1.Name = "olSwitchBox1";
            this.olSwitchBox1.OffBackColor = System.Drawing.Color.Gray;
            this.olSwitchBox1.OffBorderColor = System.Drawing.Color.Gray;
            this.olSwitchBox1.OffEnabledBackColor = System.Drawing.Color.DarkGray;
            this.olSwitchBox1.OffEnabledBorderColor = System.Drawing.Color.LightGray;
            this.olSwitchBox1.OffEnabledForeColor = System.Drawing.Color.LightGray;
            this.olSwitchBox1.OffForeColor = System.Drawing.Color.White;
            this.olSwitchBox1.OnBackColor = System.Drawing.Color.Green;
            this.olSwitchBox1.OnBorderColor = System.Drawing.Color.Green;
            this.olSwitchBox1.OnEnabledBackColor = System.Drawing.Color.LightGray;
            this.olSwitchBox1.OnEnabledBorderColor = System.Drawing.Color.LightGray;
            this.olSwitchBox1.OnEnabledForeColor = System.Drawing.Color.Gray;
            this.olSwitchBox1.OnForeColor = System.Drawing.Color.White;
            this.olSwitchBox1.UseVisualStyleBackColor = true;
            // 
            // olCheckBox1
            // 
            resources.ApplyResources(this.olCheckBox1, "olCheckBox1");
            this.olCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.olCheckBox1.Name = "olCheckBox1";
            this.olCheckBox1.OffBorderColor = System.Drawing.Color.Gray;
            this.olCheckBox1.OffSelectColor = System.Drawing.Color.Blue;
            this.olCheckBox1.OffTickBackColor = System.Drawing.Color.Gray;
            this.olCheckBox1.OffTickColor = System.Drawing.Color.White;
            this.olCheckBox1.OnBorderColor = System.Drawing.Color.Black;
            this.olCheckBox1.OnSelectColor = System.Drawing.Color.White;
            this.olCheckBox1.OnTickBackColor = System.Drawing.Color.Blue;
            this.olCheckBox1.OnTickColor = System.Drawing.Color.White;
            this.olCheckBox1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.olCheckBox1);
            this.Controls.Add(this.olSwitchBox1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.OlSwitchBox olSwitchBox1;
        private Control.OlCheckBox olCheckBox1;
    }
}

