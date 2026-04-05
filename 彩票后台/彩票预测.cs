using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CommonHelp;

namespace 彩票后台;

public class 彩票预测 : Form
{
	private IContainer components = null;

	private DataGridView dataGridView1;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private Label label2;

	private ComboBox cbbqishu;

	private ComboBox cbbqishuYear;

	private Label label4;

	private Label label3;

	private TextBox txt2;

	private TextBox txt3;

	private TextBox txt4;

	private TextBox txt5;

	private TextBox txt6;

	private TextBox txt7;

	private TextBox txt1;

	private TextBox txt11;

	private TextBox txt22;

	private TextBox txt33;

	private Button btnssq;

	private Button btn3d;

	private DataGridViewTextBoxColumn KeyId;

	private DataGridViewTextBoxColumn type;

	private DataGridViewTextBoxColumn qishu;

	private DataGridViewTextBoxColumn zhongjianghaoma;

	private DataGridViewTextBoxColumn mima;

	private Button btnSearch;

	private ComboBox cbbSearchqishu2;

	private Label label1;

	private ComboBox cbbSearchqishu1;

	private Button btnDelete;

	private Label label5;

	private SQLiteHelper dbhelp = new SQLiteHelper();

	private DataBase dbsql = new DataBase();

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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.KeyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.qishu = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.zhongjianghaoma = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.mima = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.label5 = new System.Windows.Forms.Label();
		this.btn3d = new System.Windows.Forms.Button();
		this.btnssq = new System.Windows.Forms.Button();
		this.txt11 = new System.Windows.Forms.TextBox();
		this.txt22 = new System.Windows.Forms.TextBox();
		this.txt33 = new System.Windows.Forms.TextBox();
		this.txt2 = new System.Windows.Forms.TextBox();
		this.txt3 = new System.Windows.Forms.TextBox();
		this.txt4 = new System.Windows.Forms.TextBox();
		this.txt5 = new System.Windows.Forms.TextBox();
		this.txt6 = new System.Windows.Forms.TextBox();
		this.txt7 = new System.Windows.Forms.TextBox();
		this.txt1 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.cbbqishu = new System.Windows.Forms.ComboBox();
		this.cbbqishuYear = new System.Windows.Forms.ComboBox();
		this.label2 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.btnDelete = new System.Windows.Forms.Button();
		this.btnSearch = new System.Windows.Forms.Button();
		this.cbbSearchqishu2 = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.cbbSearchqishu1 = new System.Windows.Forms.ComboBox();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.dataGridView1.AllowUserToAddRows = false;
		this.dataGridView1.AllowUserToDeleteRows = false;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Columns.AddRange(this.KeyId, this.type, this.qishu, this.zhongjianghaoma, this.mima);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView1.Location = new System.Drawing.Point(3, 260);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridView1.RowTemplate.Height = 23;
		this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
		this.dataGridView1.Size = new System.Drawing.Size(755, 293);
		this.dataGridView1.TabIndex = 0;
		this.KeyId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		this.KeyId.DataPropertyName = "KeyId";
		this.KeyId.HeaderText = "主键";
		this.KeyId.Name = "KeyId";
		this.KeyId.ReadOnly = true;
		this.KeyId.Visible = false;
		this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		this.type.DataPropertyName = "type";
		this.type.HeaderText = "彩票类型";
		this.type.Name = "type";
		this.type.ReadOnly = true;
		this.type.Width = 78;
		this.qishu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		this.qishu.DataPropertyName = "qishu";
		this.qishu.HeaderText = "彩票期数";
		this.qishu.Name = "qishu";
		this.qishu.ReadOnly = true;
		this.qishu.Width = 78;
		this.zhongjianghaoma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.zhongjianghaoma.DataPropertyName = "zhongjianghaoma";
		this.zhongjianghaoma.HeaderText = "中奖号码";
		this.zhongjianghaoma.Name = "zhongjianghaoma";
		this.zhongjianghaoma.ReadOnly = true;
		this.mima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.mima.DataPropertyName = "mima";
		this.mima.HeaderText = "密码";
		this.mima.Name = "mima";
		this.mima.ReadOnly = true;
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.btn3d);
		this.groupBox1.Controls.Add(this.btnssq);
		this.groupBox1.Controls.Add(this.txt11);
		this.groupBox1.Controls.Add(this.txt22);
		this.groupBox1.Controls.Add(this.txt33);
		this.groupBox1.Controls.Add(this.txt2);
		this.groupBox1.Controls.Add(this.txt3);
		this.groupBox1.Controls.Add(this.txt4);
		this.groupBox1.Controls.Add(this.txt5);
		this.groupBox1.Controls.Add(this.txt6);
		this.groupBox1.Controls.Add(this.txt7);
		this.groupBox1.Controls.Add(this.txt1);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.cbbqishu);
		this.groupBox1.Controls.Add(this.cbbqishuYear);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Location = new System.Drawing.Point(3, 1);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(755, 128);
		this.groupBox1.TabIndex = 1;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "密码生成";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(12, 21);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(47, 12);
		this.label5.TabIndex = 19;
		this.label5.Text = "年份:20";
		this.btn3d.Location = new System.Drawing.Point(612, 86);
		this.btn3d.Name = "btn3d";
		this.btn3d.Size = new System.Drawing.Size(104, 23);
		this.btn3d.TabIndex = 18;
		this.btn3d.Text = "生成3D密码";
		this.btn3d.UseVisualStyleBackColor = true;
		this.btn3d.Click += new System.EventHandler(btn3d_Click);
		this.btnssq.Location = new System.Drawing.Point(612, 51);
		this.btnssq.Name = "btnssq";
		this.btnssq.Size = new System.Drawing.Size(104, 23);
		this.btnssq.TabIndex = 17;
		this.btnssq.Text = "生成双色球密码";
		this.btnssq.UseVisualStyleBackColor = true;
		this.btnssq.Click += new System.EventHandler(btnssq_Click);
		this.txt11.Location = new System.Drawing.Point(69, 88);
		this.txt11.MaxLength = 2;
		this.txt11.Name = "txt11";
		this.txt11.Size = new System.Drawing.Size(40, 21);
		this.txt11.TabIndex = 16;
		this.txt11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt22.Location = new System.Drawing.Point(140, 88);
		this.txt22.MaxLength = 2;
		this.txt22.Name = "txt22";
		this.txt22.Size = new System.Drawing.Size(40, 21);
		this.txt22.TabIndex = 15;
		this.txt22.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt33.Location = new System.Drawing.Point(211, 88);
		this.txt33.MaxLength = 2;
		this.txt33.Name = "txt33";
		this.txt33.Size = new System.Drawing.Size(40, 21);
		this.txt33.TabIndex = 14;
		this.txt33.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt2.Location = new System.Drawing.Point(140, 53);
		this.txt2.MaxLength = 2;
		this.txt2.Name = "txt2";
		this.txt2.Size = new System.Drawing.Size(40, 21);
		this.txt2.TabIndex = 13;
		this.txt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt3.Location = new System.Drawing.Point(211, 53);
		this.txt3.MaxLength = 2;
		this.txt3.Name = "txt3";
		this.txt3.Size = new System.Drawing.Size(40, 21);
		this.txt3.TabIndex = 12;
		this.txt3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt4.Location = new System.Drawing.Point(282, 53);
		this.txt4.MaxLength = 2;
		this.txt4.Name = "txt4";
		this.txt4.Size = new System.Drawing.Size(40, 21);
		this.txt4.TabIndex = 11;
		this.txt4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt5.Location = new System.Drawing.Point(353, 53);
		this.txt5.MaxLength = 2;
		this.txt5.Name = "txt5";
		this.txt5.Size = new System.Drawing.Size(40, 21);
		this.txt5.TabIndex = 10;
		this.txt5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt6.Location = new System.Drawing.Point(424, 53);
		this.txt6.MaxLength = 2;
		this.txt6.Name = "txt6";
		this.txt6.Size = new System.Drawing.Size(40, 21);
		this.txt6.TabIndex = 9;
		this.txt6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt7.Location = new System.Drawing.Point(495, 53);
		this.txt7.MaxLength = 2;
		this.txt7.Name = "txt7";
		this.txt7.Size = new System.Drawing.Size(40, 21);
		this.txt7.TabIndex = 8;
		this.txt7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.txt1.Location = new System.Drawing.Point(69, 53);
		this.txt1.MaxLength = 2;
		this.txt1.Name = "txt1";
		this.txt1.Size = new System.Drawing.Size(40, 21);
		this.txt1.TabIndex = 7;
		this.txt1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt1_KeyPress);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(12, 91);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(23, 12);
		this.label4.TabIndex = 6;
		this.label4.Text = "3D:";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(10, 62);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(47, 12);
		this.label3.TabIndex = 5;
		this.label3.Text = "双色球:";
		this.cbbqishu.FormattingEnabled = true;
		this.cbbqishu.Location = new System.Drawing.Point(282, 18);
		this.cbbqishu.Name = "cbbqishu";
		this.cbbqishu.Size = new System.Drawing.Size(98, 20);
		this.cbbqishu.TabIndex = 4;
		this.cbbqishuYear.FormattingEnabled = true;
		this.cbbqishuYear.Items.AddRange(new object[]
		{
			"15", "16", "17", "18", "19", "20", "21", "22", "23", "24",
			"25", "26", "27", "28"
        });
		this.cbbqishuYear.Location = new System.Drawing.Point(69, 18);
		this.cbbqishuYear.Name = "cbbqishuYear";
		this.cbbqishuYear.Size = new System.Drawing.Size(98, 20);
		this.cbbqishuYear.TabIndex = 3;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(216, 21);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(35, 12);
		this.label2.TabIndex = 2;
		this.label2.Text = "期数:";
		this.groupBox2.Controls.Add(this.btnDelete);
		this.groupBox2.Controls.Add(this.btnSearch);
		this.groupBox2.Controls.Add(this.cbbSearchqishu2);
		this.groupBox2.Controls.Add(this.label1);
		this.groupBox2.Controls.Add(this.cbbSearchqishu1);
		this.groupBox2.Location = new System.Drawing.Point(3, 135);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(755, 119);
		this.groupBox2.TabIndex = 2;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "数据查询";
		this.btnDelete.Location = new System.Drawing.Point(612, 90);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(104, 23);
		this.btnDelete.TabIndex = 22;
		this.btnDelete.Text = "删除";
		this.btnDelete.UseVisualStyleBackColor = true;
		this.btnDelete.Click += new System.EventHandler(btnDelete_Click);
		this.btnSearch.Location = new System.Drawing.Point(612, 35);
		this.btnSearch.Name = "btnSearch";
		this.btnSearch.Size = new System.Drawing.Size(104, 23);
		this.btnSearch.TabIndex = 19;
		this.btnSearch.Text = "查询";
		this.btnSearch.UseVisualStyleBackColor = true;
		this.btnSearch.Click += new System.EventHandler(btnSearch_Click);
		this.cbbSearchqishu2.FormattingEnabled = true;
		this.cbbSearchqishu2.Location = new System.Drawing.Point(211, 37);
		this.cbbSearchqishu2.Name = "cbbSearchqishu2";
		this.cbbSearchqishu2.Size = new System.Drawing.Size(98, 20);
		this.cbbSearchqishu2.TabIndex = 21;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(35, 12);
		this.label1.TabIndex = 19;
		this.label1.Text = "期数:";
		this.cbbSearchqishu1.FormattingEnabled = true;
		this.cbbSearchqishu1.Items.AddRange(new object[] { "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" });
		this.cbbSearchqishu1.Location = new System.Drawing.Point(69, 37);
		this.cbbSearchqishu1.Name = "cbbSearchqishu1";
		this.cbbSearchqishu1.Size = new System.Drawing.Size(98, 20);
		this.cbbSearchqishu1.TabIndex = 20;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(761, 555);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.dataGridView1);
		base.Name = "彩票预测";
		this.Text = "彩票控密码生成";
		base.Load += new System.EventHandler(彩票预测_Load);
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		base.ResumeLayout(false);
	}

	public 彩票预测()
	{
		InitializeComponent();
		InitCbb();
	}

	private void InitCbb()
	{
		for (int i = 1; i <= 365; i++)
		{
			cbbqishu.Items.Add(i.ToString().PadLeft(3, '0'));
			cbbSearchqishu2.Items.Add(i.ToString().PadLeft(3, '0'));
		}
		cbbqishu.SelectedIndex = 0;
		cbbqishuYear.SelectedIndex = 0;
		cbbSearchqishu1.SelectedIndex = 0;
		cbbSearchqishu2.SelectedIndex = 0;
	}

	private void txt1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	private void btnssq_Click(object sender, EventArgs e)
	{
		int year = Convert.ToInt32(cbbqishuYear.SelectedItem);
		int phase = Convert.ToInt32(cbbqishu.SelectedItem);
		string text = "20" + cbbqishuYear.SelectedItem.ToString() + cbbqishu.SelectedItem.ToString();
		if (string.IsNullOrEmpty(txt1.Text) || string.IsNullOrEmpty(txt2.Text) || string.IsNullOrEmpty(txt3.Text) || string.IsNullOrEmpty(txt4.Text) || string.IsNullOrEmpty(txt5.Text) || string.IsNullOrEmpty(txt6.Text) || string.IsNullOrEmpty(txt7.Text))
		{
			MessageBox.Show("双色球号码不能为空");
			return;
		}
		List<int> list = new List<int>();
		list.Add(Convert.ToInt32(txt1.Text));
		list.Add(Convert.ToInt32(txt2.Text));
		list.Add(Convert.ToInt32(txt3.Text));
		list.Add(Convert.ToInt32(txt4.Text));
		list.Add(Convert.ToInt32(txt5.Text));
		list.Add(Convert.ToInt32(txt6.Text));
		list.Add(Convert.ToInt32(txt7.Text));
		string text2 = string.Empty;
		foreach (int item in list)
		{
			text2 = text2 + item + ",";
		}
		text2 = text2.TrimEnd(',');
		string jiami = OyUtil.SuanEncrypt(year, phase, Convert.ToInt32(txt1.Text), Convert.ToInt32(txt2.Text), Convert.ToInt32(txt3.Text), Convert.ToInt32(txt4.Text), Convert.ToInt32(txt5.Text), Convert.ToInt32(txt6.Text), Convert.ToInt32(txt7.Text));
		InsertData(text, jiami, text2, "双色球");
		BindGridView();
	}

	private void btn3d_Click(object sender, EventArgs e)
	{
		string text = "20" + cbbqishuYear.SelectedItem.ToString() + cbbqishu.SelectedItem.ToString();
		int year = Convert.ToInt32(cbbqishuYear.SelectedItem);
		int phase = Convert.ToInt32(cbbqishu.SelectedItem);
		if (string.IsNullOrEmpty(txt11.Text) || string.IsNullOrEmpty(txt22.Text) || string.IsNullOrEmpty(txt33.Text))
		{
			MessageBox.Show("3D号码不能为空");
			return;
		}
		List<int> list = new List<int>();
		list.Add(Convert.ToInt32(txt11.Text));
		list.Add(Convert.ToInt32(txt22.Text));
		list.Add(Convert.ToInt32(txt33.Text));
		string text2 = string.Empty;
		foreach (int item in list)
		{
			text2 = text2 + item + ",";
		}
		text2 = text2.TrimEnd(',');
		string jiami = OyUtil.SdEncrypt(year, phase, Convert.ToInt32(txt11.Text), Convert.ToInt32(txt22.Text), Convert.ToInt32(txt33.Text));
		InsertData(text, jiami, text2, "3D");
		BindGridView();
	}

	private void InsertData(string qishu, string jiami, string jiemi, string type)
	{
		dbhelp.Execute("insert into tbyuce values(null,'" + type + "','" + qishu + "','" + jiemi + "','" + jiami + "')");
	}

	private void BindGridView(string where = "")
	{
		string text = " where 1=1 ";
		if (where != "")
		{
			text += where;
		}
		DataTable dataSource = dbhelp.Select("select * from tbyuce " + text + " order by KeyId desc");
		dataGridView1.AutoGenerateColumns = false;
		dataGridView1.DataSource = dataSource;
	}

	private void 彩票预测_Load(object sender, EventArgs e)
	{
		BindGridView();
	}

	private bool CheckIsExist(string type, string qishu)
	{
		object obj = dbhelp.ExecuteScalar("select type from tbyuce where type='" + type + "' and qishu='" + qishu + "'");
		if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
		{
			return true;
		}
		return false;
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		string text = cbbSearchqishu1.SelectedItem.ToString() + cbbSearchqishu2.SelectedItem.ToString();
		BindGridView(" and qishu='" + text + "'");
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("确认删除？此删除不可恢复!", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
		{
			int rowIndex = dataGridView1.CurrentCell.RowIndex;
			if (rowIndex < 0)
			{
				MessageBox.Show("请选中一行");
				return;
			}
			string text = dataGridView1["KeyId", rowIndex].Value.ToString();
			dbhelp.Execute("delete from tbyuce where KeyId=" + text);
			MessageBox.Show("删除成功!");
			BindGridView();
		}
	}

	private void InsertSqlserver()
	{
		Ping ping = new Ping();
		PingReply pingReply = ping.Send("119.75.218.45");
		if (pingReply.Status != IPStatus.Success)
		{
			return;
		}
		try
		{
			dbsql.ExecDataBySql("truncate table Caipiao");
			DataTable dt = dbhelp.Select("select * from tbyuce  order by KeyId desc");
			BulkCopy bulkCopy = new BulkCopy();
			bulkCopy.DestinationTableName = "Caipiao";
			bulkCopy.BulkToDB(dt);
		}
		catch
		{
		}
	}
}
