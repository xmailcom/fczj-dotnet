using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace 彩票后台;

public class Login : Form
{
	private IContainer components = null;

	private TextBox txtusername;

	private TextBox txtpwd;

	private Button btnLogin;

	private Button btnOut;

	private Label label3;

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(彩票后台.Login));
		this.txtusername = new System.Windows.Forms.TextBox();
		this.txtpwd = new System.Windows.Forms.TextBox();
		this.btnLogin = new System.Windows.Forms.Button();
		this.btnOut = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.txtusername.Location = new System.Drawing.Point(200, 139);
		this.txtusername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.txtusername.Name = "txtusername";
		this.txtusername.Size = new System.Drawing.Size(164, 23);
		this.txtusername.TabIndex = 2;
		this.txtpwd.Location = new System.Drawing.Point(200, 177);
		this.txtpwd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.txtpwd.Name = "txtpwd";
		this.txtpwd.Size = new System.Drawing.Size(164, 23);
		this.txtpwd.TabIndex = 4;
		this.txtpwd.UseSystemPasswordChar = true;
		this.btnLogin.Location = new System.Drawing.Point(200, 217);
		this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Size = new System.Drawing.Size(67, 27);
		this.btnLogin.TabIndex = 5;
		this.btnLogin.Text = "登 录";
		this.btnLogin.UseVisualStyleBackColor = true;
		this.btnLogin.Click += new System.EventHandler(btnLogin_Click);
		this.btnOut.Location = new System.Drawing.Point(287, 217);
		this.btnOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.btnOut.Name = "btnOut";
		this.btnOut.Size = new System.Drawing.Size(66, 27);
		this.btnOut.TabIndex = 6;
		this.btnOut.Text = "退 出";
		this.btnOut.UseVisualStyleBackColor = true;
		this.btnOut.Click += new System.EventHandler(btnOut_Click);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(45, 15);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(0, 14);
		this.label3.TabIndex = 7;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		base.ClientSize = new System.Drawing.Size(609, 296);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.btnOut);
		base.Controls.Add(this.btnLogin);
		base.Controls.Add(this.txtpwd);
		base.Controls.Add(this.txtusername);
		this.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		base.Name = "Login";
		this.Text = "彩票控后台控制";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public Login()
	{
		InitializeComponent();
		base.ControlBox = false;
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpwd.Text))
		{
			MessageBox.Show("请填写帐号或密码");
			return;
		}
		DataTable dataTable = dbhelp.Select("select * from tbUser where username='" + txtusername.Text + "' and pwd='" + txtpwd.Text + "'");
		if (dataTable == null || dataTable.Rows.Count == 0)
		{
			MessageBox.Show("帐号或密码错误");
			return;
		}
		Hide();
		Main main = new Main();
		main.Show();
	}

	private void btnOut_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = MessageBox.Show("确定退出程序吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.OK)
		{
			Application.Exit();
		}
	}
}
