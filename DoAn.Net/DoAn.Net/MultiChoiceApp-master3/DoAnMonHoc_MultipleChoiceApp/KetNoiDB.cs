using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DoAnMonHoc_MultipleChoiceApp
{
	public class KetNoiDB
	{
		private SqlConnection connection;

		public SqlConnection Connection
		{
			get
			{
				return connection;
			}

			set
			{
				connection = value;
			}
		}

		public KetNoiDB() 
		{ 
			connection = new SqlConnection(ConnStringConfig.ketnoistring);
		}

		public void OpenDB()
		{
			if (connection.State == System.Data.ConnectionState.Closed)
			{
				connection.Open();
			}
		}

		public void CloseDB()
		{
			if (connection.State != System.Data.ConnectionState.Closed)
			{
				connection.Close();
			}
		}

		public SqlDataReader GetDataReader(string query)
		{
			OpenDB();

			SqlCommand command = new SqlCommand(query, connection);

			SqlDataReader reader = command.ExecuteReader();

			return reader;
		}

		public object GetScalar(string query)
		{
			OpenDB();

			SqlCommand command = new SqlCommand(query, connection);

			object item = command.ExecuteScalar();

			return item;
		}

		public int GetNonQuery(string query)
		{
			OpenDB();

			SqlCommand command = new SqlCommand(query, connection);

			int nonQuery = command.ExecuteNonQuery();

			return nonQuery;
		}
	}
}
