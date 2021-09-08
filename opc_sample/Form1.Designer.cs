namespace WindowsFormsApp1
{
    partial class Form1
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
            this.read1 = new System.Windows.Forms.Button();
            this.Write1 = new System.Windows.Forms.Button();
            this.batchSubscribe = new System.Windows.Forms.Button();
            this.subscribe = new System.Windows.Forms.Button();
            this.batchread = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.batchwrite = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.readBOX1 = new System.Windows.Forms.TextBox();
            this.readBOX2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.writeBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.batchsub1 = new System.Windows.Forms.TextBox();
            this.batchsub3 = new System.Windows.Forms.TextBox();
            this.batchsub2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.ReadFormDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // read1
            // 
            this.read1.Location = new System.Drawing.Point(39, 24);
            this.read1.Name = "read1";
            this.read1.Size = new System.Drawing.Size(123, 54);
            this.read1.TabIndex = 1;
            this.read1.Text = "读取1";
            this.read1.UseVisualStyleBackColor = true;
            this.read1.Click += new System.EventHandler(this.read1_Click);
            // 
            // Write1
            // 
            this.Write1.Location = new System.Drawing.Point(197, 24);
            this.Write1.Name = "Write1";
            this.Write1.Size = new System.Drawing.Size(123, 54);
            this.Write1.TabIndex = 2;
            this.Write1.Text = "写入1";
            this.Write1.UseVisualStyleBackColor = true;
            this.Write1.Click += new System.EventHandler(this.Write1_Click);
            // 
            // batchSubscribe
            // 
            this.batchSubscribe.Location = new System.Drawing.Point(39, 282);
            this.batchSubscribe.Name = "batchSubscribe";
            this.batchSubscribe.Size = new System.Drawing.Size(123, 54);
            this.batchSubscribe.TabIndex = 3;
            this.batchSubscribe.Text = "批量订阅";
            this.batchSubscribe.UseVisualStyleBackColor = true;
            this.batchSubscribe.Click += new System.EventHandler(this.batchSubscribe_Click);
            // 
            // subscribe
            // 
            this.subscribe.Location = new System.Drawing.Point(39, 203);
            this.subscribe.Name = "subscribe";
            this.subscribe.Size = new System.Drawing.Size(123, 54);
            this.subscribe.TabIndex = 4;
            this.subscribe.Text = "订阅";
            this.subscribe.UseVisualStyleBackColor = true;
            this.subscribe.Click += new System.EventHandler(this.subscribe_Click);
            // 
            // batchread
            // 
            this.batchread.Location = new System.Drawing.Point(39, 127);
            this.batchread.Name = "batchread";
            this.batchread.Size = new System.Drawing.Size(123, 54);
            this.batchread.TabIndex = 5;
            this.batchread.Text = "批量读";
            this.batchread.UseVisualStyleBackColor = true;
            this.batchread.Click += new System.EventHandler(this.batchread_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(197, 282);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(123, 54);
            this.start.TabIndex = 6;
            this.start.Text = "启动";
            this.start.UseVisualStyleBackColor = true;
            this.start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.start_MouseDown);
            this.start.MouseUp += new System.Windows.Forms.MouseEventHandler(this.start_MouseUp);
            // 
            // batchwrite
            // 
            this.batchwrite.Location = new System.Drawing.Point(197, 127);
            this.batchwrite.Name = "batchwrite";
            this.batchwrite.Size = new System.Drawing.Size(123, 54);
            this.batchwrite.TabIndex = 7;
            this.batchwrite.Text = "批量写";
            this.batchwrite.UseVisualStyleBackColor = true;
            this.batchwrite.Click += new System.EventHandler(this.batchwrite_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(197, 203);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(123, 54);
            this.button8.TabIndex = 8;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // readBOX1
            // 
            this.readBOX1.Location = new System.Drawing.Point(597, 192);
            this.readBOX1.Name = "readBOX1";
            this.readBOX1.Size = new System.Drawing.Size(157, 21);
            this.readBOX1.TabIndex = 9;
            // 
            // readBOX2
            // 
            this.readBOX2.Location = new System.Drawing.Point(597, 236);
            this.readBOX2.Name = "readBOX2";
            this.readBOX2.Size = new System.Drawing.Size(157, 21);
            this.readBOX2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(597, 282);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(157, 21);
            this.textBox3.TabIndex = 11;
            // 
            // writeBOX
            // 
            this.writeBOX.Location = new System.Drawing.Point(180, 90);
            this.writeBOX.Name = "writeBOX";
            this.writeBOX.Size = new System.Drawing.Size(157, 21);
            this.writeBOX.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(478, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "读取Label 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(478, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "读取Label 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(478, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "订阅";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(70, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "写入的数据";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(597, 52);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(157, 94);
            this.login.TabIndex = 19;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // batchsub1
            // 
            this.batchsub1.Location = new System.Drawing.Point(597, 325);
            this.batchsub1.Name = "batchsub1";
            this.batchsub1.Size = new System.Drawing.Size(157, 21);
            this.batchsub1.TabIndex = 20;
            // 
            // batchsub3
            // 
            this.batchsub3.Location = new System.Drawing.Point(597, 379);
            this.batchsub3.Name = "batchsub3";
            this.batchsub3.Size = new System.Drawing.Size(157, 21);
            this.batchsub3.TabIndex = 21;
            // 
            // batchsub2
            // 
            this.batchsub2.Location = new System.Drawing.Point(597, 352);
            this.batchsub2.Name = "batchsub2";
            this.batchsub2.Size = new System.Drawing.Size(157, 21);
            this.batchsub2.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(478, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "批量订阅";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(197, 352);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(123, 48);
            this.stop.TabIndex = 24;
            this.stop.Text = "停止";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stop_MouseDown);
            this.stop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stop_MouseUp);
            // 
            // ReadFormDb
            // 
            this.ReadFormDb.Location = new System.Drawing.Point(326, 24);
            this.ReadFormDb.Name = "ReadFormDb";
            this.ReadFormDb.Size = new System.Drawing.Size(123, 54);
            this.ReadFormDb.TabIndex = 25;
            this.ReadFormDb.Text = "读数据库";
            this.ReadFormDb.UseVisualStyleBackColor = true;
            this.ReadFormDb.Click += new System.EventHandler(this.ReadFormDb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReadFormDb);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.batchsub2);
            this.Controls.Add(this.batchsub3);
            this.Controls.Add(this.batchsub1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.writeBOX);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.readBOX2);
            this.Controls.Add(this.readBOX1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.batchwrite);
            this.Controls.Add(this.start);
            this.Controls.Add(this.batchread);
            this.Controls.Add(this.subscribe);
            this.Controls.Add(this.batchSubscribe);
            this.Controls.Add(this.Write1);
            this.Controls.Add(this.read1);
            this.Name = "Form1";
            this.Text = "OPCUAClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button read1;
        private System.Windows.Forms.Button Write1;
        private System.Windows.Forms.Button batchSubscribe;
        private System.Windows.Forms.Button subscribe;
        private System.Windows.Forms.Button batchread;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button batchwrite;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox readBOX1;
        private System.Windows.Forms.TextBox readBOX2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox writeBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox batchsub1;
        private System.Windows.Forms.TextBox batchsub3;
        private System.Windows.Forms.TextBox batchsub2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button ReadFormDb;
    }
}

