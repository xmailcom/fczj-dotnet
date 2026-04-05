using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace 彩票后台;

public class Main : Form
{
	private IContainer components = null;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem 彩票预测;

	private ToolStripMenuItem 修改密码;

	public Main()
	{
		InitializeComponent();
	}

	private void 彩票预测_Click(object sender, EventArgs e)
	{
		彩票预测 彩票预测2 = new 彩票预测();
		彩票预测2.ShowDialog();
	}

	private void 修改密码_Click(object sender, EventArgs e)
	{
		修改密码 修改密码2 = new 修改密码();
		修改密码2.ShowDialog();
	}

	private void Main_FormClosed(object sender, FormClosedEventArgs e)
	{
		Environment.Exit(0);
	}

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(彩票后台.Main));
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.彩票预测 = new System.Windows.Forms.ToolStripMenuItem();
		this.修改密码 = new System.Windows.Forms.ToolStripMenuItem();
		this.menuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.彩票预测, this.修改密码 });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(516, 25);
		this.menuStrip1.TabIndex = 0;
		this.menuStrip1.Text = "menuStrip1";
		this.彩票预测.Name = "彩票预测";
		this.彩票预测.Size = new System.Drawing.Size(68, 21);
		this.彩票预测.Text = "彩票预测";
		this.彩票预测.Click += new System.EventHandler(彩票预测_Click);
		this.修改密码.Name = "修改密码";
		this.修改密码.Size = new System.Drawing.Size(68, 21);
		this.修改密码.Text = "修改密码";
		this.修改密码.Click += new System.EventHandler(修改密码_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		base.ClientSize = new System.Drawing.Size(516, 312);
		base.Controls.Add(this.menuStrip1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Main";
		this.Text = "彩票控";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Main_FormClosed);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
