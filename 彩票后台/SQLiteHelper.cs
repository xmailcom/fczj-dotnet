using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace 彩票后台;

public class SQLiteHelper
{
	private SQLiteCommand cmd = null;

	private string sqliteConnectionString = null;

	public SQLiteHelper()
	{
		string text = "Data Source=" + Application.StartupPath + "\\caipiao.db;Pooling=true;";
		sqliteConnectionString = text;
	}

	public int ImportFromDataTable(DataTable dt)
	{
		int num = 0;
		using (SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString))
		{
			sQLiteConnection.Open();
			using DbTransaction dbTransaction = sQLiteConnection.BeginTransaction();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection))
			{
				sQLiteCommand.CommandText = "delete from " + dt.TableName;
				sQLiteCommand.ExecuteNonQuery();
				foreach (DataRow row in dt.Rows)
				{
					string text = string.Empty;
					foreach (DataColumn column in dt.Columns)
					{
						object obj = text;
						text = string.Concat(obj, "'", row[column.ColumnName], "',");
					}
					text = "null," + text.TrimEnd(',');
					sQLiteCommand.CommandText = "insert into " + dt.TableName + " values (" + text + ")";
					num += sQLiteCommand.ExecuteNonQuery();
				}
			}
			dbTransaction.Commit();
		}
		return num;
	}

	public DataTable GetTableStatus()
	{
		return Select("SELECT * FROM sqlite_master;");
	}

	public DataTable GetTableList()
	{
		DataTable tableStatus = GetTableStatus();
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("Tables");
		for (int i = 0; i < tableStatus.Rows.Count; i++)
		{
			string text = string.Concat(tableStatus.Rows[i]["name"]);
			if (text != "sqlite_sequence")
			{
				dataTable.Rows.Add(text);
			}
		}
		return dataTable;
	}

	public DataTable GetColumnStatus(string tableName)
	{
		return Select($"PRAGMA table_info(`{tableName}`);");
	}

	public DataTable ShowDatabase()
	{
		return Select("PRAGMA database_list;");
	}

	public void BeginTransaction()
	{
		cmd.CommandText = "begin transaction;";
		cmd.ExecuteNonQuery();
	}

	public void Commit()
	{
		cmd.CommandText = "commit;";
		cmd.ExecuteNonQuery();
	}

	public void Rollback()
	{
		cmd.CommandText = "rollback";
		cmd.ExecuteNonQuery();
	}

	public DataTable Select(string sql)
	{
		return Select(sql, new List<SQLiteParameter>());
	}

	public DataTable Select(string sql, Dictionary<string, object> dicParameters = null)
	{
		List<SQLiteParameter> parametersList = GetParametersList(dicParameters);
		return Select(sql, parametersList);
	}

	public DataTable Select(string sql, IEnumerable<SQLiteParameter> parameters = null)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = sql;
		if (parameters != null)
		{
			foreach (SQLiteParameter parameter in parameters)
			{
				sQLiteCommand.Parameters.Add(parameter);
			}
		}
		SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(sQLiteCommand);
		DataTable dataTable = new DataTable();
		sQLiteDataAdapter.Fill(dataTable);
		return dataTable;
	}

	public void Execute(string sql)
	{
		Execute(sql, new List<SQLiteParameter>());
	}

	public void Execute(string sql, Dictionary<string, object> dicParameters = null)
	{
		List<SQLiteParameter> parametersList = GetParametersList(dicParameters);
		Execute(sql, parametersList);
	}

	public void Execute(string sql, IEnumerable<SQLiteParameter> parameters = null)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = sql;
		if (parameters != null)
		{
			foreach (SQLiteParameter parameter in parameters)
			{
				sQLiteCommand.Parameters.Add(parameter);
			}
		}
		sQLiteCommand.ExecuteNonQuery();
	}

	public object ExecuteScalar(string sql)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = sql;
		return sQLiteCommand.ExecuteScalar();
	}

	public object ExecuteScalar(string sql, Dictionary<string, object> dicParameters = null)
	{
		List<SQLiteParameter> parametersList = GetParametersList(dicParameters);
		return ExecuteScalar(sql, parametersList);
	}

	public object ExecuteScalar(string sql, IEnumerable<SQLiteParameter> parameters = null)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = sql;
		if (parameters != null)
		{
			foreach (SQLiteParameter parameter in parameters)
			{
				sQLiteCommand.Parameters.Add(parameter);
			}
		}
		return sQLiteCommand.ExecuteScalar();
	}

	public dataType ExecuteScalar<dataType>(string sql, Dictionary<string, object> dicParameters = null)
	{
		List<SQLiteParameter> list = null;
		if (dicParameters != null)
		{
			list = new List<SQLiteParameter>();
			foreach (KeyValuePair<string, object> dicParameter in dicParameters)
			{
				list.Add(new SQLiteParameter(dicParameter.Key, dicParameter.Value));
			}
		}
		return ExecuteScalar<dataType>(sql, list);
	}

	public dataType ExecuteScalar<dataType>(string sql, IEnumerable<SQLiteParameter> parameters = null)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = sql;
		if (parameters != null)
		{
			foreach (SQLiteParameter parameter in parameters)
			{
				sQLiteCommand.Parameters.Add(parameter);
			}
		}
		return (dataType)Convert.ChangeType(sQLiteCommand.ExecuteScalar(), typeof(dataType));
	}

	public dataType ExecuteScalar<dataType>(string sql)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = sql;
		return (dataType)Convert.ChangeType(sQLiteCommand.ExecuteScalar(), typeof(dataType));
	}

	private List<SQLiteParameter> GetParametersList(Dictionary<string, object> dicParameters)
	{
		List<SQLiteParameter> list = new List<SQLiteParameter>();
		if (dicParameters != null)
		{
			foreach (KeyValuePair<string, object> dicParameter in dicParameters)
			{
				list.Add(new SQLiteParameter(dicParameter.Key, dicParameter.Value));
			}
		}
		return list;
	}

	public string Escape(string data)
	{
		data = data.Replace("'", "''");
		data = data.Replace("\\", "\\\\");
		return data;
	}

	public void Insert(string tableName, Dictionary<string, object> dic)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		foreach (KeyValuePair<string, object> item in dic)
		{
			if (stringBuilder.Length == 0)
			{
				stringBuilder.Append("insert into ");
				stringBuilder.Append(tableName);
				stringBuilder.Append("(");
			}
			else
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append("`");
			stringBuilder.Append(item.Key);
			stringBuilder.Append("`");
			if (stringBuilder2.Length == 0)
			{
				stringBuilder2.Append(" values(");
			}
			else
			{
				stringBuilder2.Append(", ");
			}
			stringBuilder2.Append("@v");
			stringBuilder2.Append(item.Key);
		}
		stringBuilder.Append(") ");
		stringBuilder2.Append(");");
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = stringBuilder.ToString() + stringBuilder2.ToString();
		foreach (KeyValuePair<string, object> item2 in dic)
		{
			sQLiteCommand.Parameters.AddWithValue("@v" + item2.Key, item2.Value);
		}
		sQLiteCommand.ExecuteNonQuery();
	}

	public void Update(string tableName, Dictionary<string, object> dicData, string colCond, object varCond)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary[colCond] = varCond;
		Update(tableName, dicData, dictionary);
	}

	public void Update(string tableName, Dictionary<string, object> dicData, Dictionary<string, object> dicCond)
	{
		if (dicData.Count == 0)
		{
			throw new Exception("dicData is empty.");
		}
		StringBuilder stringBuilder = new StringBuilder();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (KeyValuePair<string, object> dicDatum in dicData)
		{
			dictionary[dicDatum.Key] = null;
		}
		foreach (KeyValuePair<string, object> item in dicCond)
		{
			if (!dictionary.ContainsKey(item.Key))
			{
				dictionary[item.Key] = null;
			}
		}
		stringBuilder.Append("update `");
		stringBuilder.Append(tableName);
		stringBuilder.Append("` set ");
		bool flag = true;
		foreach (KeyValuePair<string, object> dicDatum2 in dicData)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append("`");
			stringBuilder.Append(dicDatum2.Key);
			stringBuilder.Append("` = ");
			stringBuilder.Append("@v");
			stringBuilder.Append(dicDatum2.Key);
		}
		stringBuilder.Append(" where ");
		flag = true;
		foreach (KeyValuePair<string, object> item2 in dicCond)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append(" and ");
			}
			stringBuilder.Append("`");
			stringBuilder.Append(item2.Key);
			stringBuilder.Append("` = ");
			stringBuilder.Append("@c");
			stringBuilder.Append(item2.Key);
		}
		stringBuilder.Append(";");
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = stringBuilder.ToString();
		foreach (KeyValuePair<string, object> dicDatum3 in dicData)
		{
			sQLiteCommand.Parameters.AddWithValue("@v" + dicDatum3.Key, dicDatum3.Value);
		}
		foreach (KeyValuePair<string, object> item3 in dicCond)
		{
			sQLiteCommand.Parameters.AddWithValue("@c" + item3.Key, item3.Value);
		}
		sQLiteCommand.ExecuteNonQuery();
	}

	public long LastInsertRowId()
	{
		return ExecuteScalar<long>("select last_insert_rowid();");
	}

	public void RenameTable(string tableFrom, string tableTo)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = $"alter table `{tableFrom}` rename to `{tableTo}`;";
		sQLiteCommand.ExecuteNonQuery();
	}

	public void CopyAllData(string tableFrom, string tableTo)
	{
		DataTable dataTable = Select($"select * from `{tableFrom}` where 1 = 2;");
		DataTable dataTable2 = Select($"select * from `{tableTo}` where 1 = 2;");
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		foreach (DataColumn column in dataTable.Columns)
		{
			if (dataTable2.Columns.Contains(column.ColumnName) && !dictionary.ContainsKey(column.ColumnName))
			{
				dictionary[column.ColumnName] = true;
			}
		}
		foreach (DataColumn column2 in dataTable2.Columns)
		{
			if (dataTable.Columns.Contains(column2.ColumnName) && !dictionary.ContainsKey(column2.ColumnName))
			{
				dictionary[column2.ColumnName] = true;
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, bool> item in dictionary)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append("`");
			stringBuilder.Append(item.Key);
			stringBuilder.Append("`");
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder2.Append("insert into `");
		stringBuilder2.Append(tableTo);
		stringBuilder2.Append("`(");
		stringBuilder2.Append(stringBuilder.ToString());
		stringBuilder2.Append(") select ");
		stringBuilder2.Append(stringBuilder.ToString());
		stringBuilder2.Append(" from `");
		stringBuilder2.Append(tableFrom);
		stringBuilder2.Append("`;");
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = stringBuilder2.ToString();
		sQLiteCommand.ExecuteNonQuery();
	}

	public void DropTable(string table)
	{
		using SQLiteConnection sQLiteConnection = new SQLiteConnection(sqliteConnectionString);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		sQLiteConnection.Open();
		sQLiteCommand.CommandText = $"drop table if exists `{table}`";
		sQLiteCommand.ExecuteNonQuery();
	}

	public void AttachDatabase(string database, string alias)
	{
		Execute($"attach '{database}' as {alias};");
	}

	public void DetachDatabase(string alias)
	{
		Execute($"detach {alias};");
	}
}
