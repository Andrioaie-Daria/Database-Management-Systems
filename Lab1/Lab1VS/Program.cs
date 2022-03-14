using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab1
{
	class Program
	{

        static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine("Tables in '{0}' DataSet.\n", ds.DataSetName);
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("{0} Table.\n", dt.TableName);
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.WriteLine(dt.Columns[curCol].ColumnName.Trim() + "\t");
                }
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
		{
			SqlConnection conn = new SqlConnection();
			conn.ConnectionString = ("Server=DESKTOP-ERFTJDA; Database=CatsDB; Integrated Security=true");
			conn.Open();

			SqlCommand select_cmd = new SqlCommand("SELECT * FROM Cats", conn);

			using (SqlDataReader reader = select_cmd.ExecuteReader())
            {
                while (reader.Read())
                {
					Console.Write("CatID: {0}, Name: {1} \n", reader.GetInt32(0), reader.GetString(1));
                }
            }

			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cats", conn);
			DataSet ds = new DataSet();
			da.Fill(ds, "Cats");

            PrintDataSet(ds);

			conn.Close();



			// using(SqlConnection c = new SqlConnection()){
			// c.Open();
			//
			//}
		}
	}

}