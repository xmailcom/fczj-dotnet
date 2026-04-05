using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace 彩票后台;

public class 修改密码 : Form
{
	private IContainer components = null;

	private Label label1;

	private TextBox txtoldpwd;

	private TextBox txtnewpwd;

	private Label label2;

	private TextBox txtnewpwd2;

	private Label label3;

	private Button btnupdate;

	private Button btnout;

	private SQLiteHelper dbhelp = new SQLiteHelper();

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.label1 = new System.Windows.Forms.Label();
		this.txtoldpwd = new System.Windows.Forms.TextBox();
		this.txtnewpwd = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.txtnewpwd2 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.btnupdate = new System.Windows.Forms.Button();
		this.btnout = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(41, 16);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(59, 12);
		this.label1.TabIndex = 0;
		this.label1.Text = "原始密码:";
		this.txtoldpwd.Location = new System.Drawing.Point(131, 13);
		this.txtoldpwd.Name = "txtoldpwd";
		this.txtoldpwd.Size = new System.Drawing.Size(249, 21);
		this.txtoldpwd.TabIndex = 1;
		this.txtoldpwd.UseSystemPasswordChar = true;
		this.txtnewpwd.Location = new System.Drawing.Point(131, 54);
		this.txtnewpwd.Name = "txtnewpwd";
		this.txtnewpwd.Size = new System.Drawing.Size(249, 21);
		this.txtnewpwd.TabIndex = 3;
		this.txtnewpwd.UseSystemPasswordChar = true;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(41, 57);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 12);
		this.label2.TabIndex = 2;
		this.label2.Text = "新密码:";
		this.txtnewpwd2.Location = new System.Drawing.Point(131, 95);
		this.txtnewpwd2.Name = "txtnewpwd2";
		this.txtnewpwd2.Size = new System.Drawing.Size(249, 21);
		this.txtnewpwd2.TabIndex = 5;
		this.txtnewpwd2.UseSystemPasswordChar = true;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(41, 98);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(59, 12);
		this.label3.TabIndex = 4;
		this.label3.Text = "确认密码:";
		this.btnupdate.Location = new System.Drawing.Point(131, 147);
		this.btnupdate.Name = "btnupdate";
		this.btnupdate.Size = new System.Drawing.Size(75, 23);
		this.btnupdate.TabIndex = 6;
		this.btnupdate.Text = "修改";
		this.btnupdate.UseVisualStyleBackColor = true;
		this.btnupdate.Click += new System.EventHandler(btnupdate_Click);
		this.btnout.Location = new System.Drawing.Point(305, 147);
		this.btnout.Name = "btnout";
		this.btnout.Size = new System.Drawing.Size(75, 23);
		this.btnout.TabIndex = 7;
		this.btnout.Text = "退出";
		this.btnout.UseVisualStyleBackColor = true;
		this.btnout.Click += new System.EventHandler(btnout_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(457, 182);
		base.Controls.Add(this.btnout);
		base.Controls.Add(this.btnupdate);
		base.Controls.Add(this.txtnewpwd2);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.txtnewpwd);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txtoldpwd);
		base.Controls.Add(this.label1);
		base.Name = "修改密码";
		this.Text = "修改密码";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public 修改密码()
	{
		InitializeComponent();
	}

	private void btnout_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = MessageBox.Show("确定退出程序吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.OK)
		{
			Close();
		}
	}

	private void btnupdate_Click(object sender, EventArgs e)
	{
		object obj = dbhelp.ExecuteScalar("select username from tbUser where username='admin' and pwd='" + txtoldpwd.Text + "'");
		if (obj == null || obj.ToString() != "admin")
		{
			MessageBox.Show("旧密码不正确");
			return;
		}
		if (string.IsNullOrEmpty(txtnewpwd.Text))
		{
			MessageBox.Show("新密码不能为空");
			return;
		}
		if (txtnewpwd.Text != txtnewpwd2.Text)
		{
			MessageBox.Show("两次输入密码不一致");
			return;
		}
		dbhelp.Execute("update tbUser set pwd='" + txtnewpwd.Text + "' where username='admin'");
		MessageBox.Show("密码修改成功");
		txtoldpwd.Text = "";
		txtnewpwd.Text = "";
		txtnewpwd2.Text = "";
	}
}
