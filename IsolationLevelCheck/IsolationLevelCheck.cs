using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsolationLevelCheck {
    static class IsolationLevelCheck {

        public static String CheckLevel(String connectionString, String sourceLevel) {

            try {
                CreateTable(connectionString);
            } catch (Exception) {
                return "Undefined";
            }

            var level = String.IsNullOrEmpty(sourceLevel) ? "" : "SET TRANSACTION ISOLATION LEVEL " + sourceLevel + "; ";

            try {
                if (DirtyReadError(connectionString, level)) {
                    DropTable(connectionString);
                    return "Read Uncommitted";
                }
                if (RepeatableReadError(connectionString, level)) {
                    DropTable(connectionString);
                    return "Read Committed";
                }
                if (PhantomReadError(connectionString, level)) {
                    DropTable(connectionString);
                    return "Repeatable Read";
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
                DropTable(connectionString);
                return "Undefined";
            }
            DropTable(connectionString);
            return "Serializable";
        }

        private static bool DirtyReadError(String connectionString, String sourceLevel) {
            var res = 0;

            var com = new SqlCommand
            {
                CommandText = "BEGIN TRANSACTION; UPDATE IsolationLevelTestTable SET Col1 = 2;" +
                              "WAITFOR DELAY '00:00:10'; ROLLBACK;"
            };

            var com2 = new SqlCommand { CommandText = sourceLevel + " WAITFOR DELAY '00:00:02'; SELECT Col1 FROM IsolationLevelTestTable;" };

            Parallel.Invoke(() => {
                using (var con = new SqlConnection(connectionString)) {
                    con.Open();
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    con.Close();
                }
            },  // close first Action
                () => {
                    using (var con = new SqlConnection(connectionString)) {
                        con.Open();
                        com2.Connection = con;
                        using (var r = com2.ExecuteReader()) {
                            while (r.Read()) {
                                res = r.GetInt32(0);
                            }
                        }
                        con.Close();
                    }
                });
            if (res == 0) {
                throw new Exception("Something went wrong");
            }
            return res == 2;
        }

        private static bool RepeatableReadError(String connectionString, String sourceLevel) {
            var res = 0;
            var res2 = 0;
            
            var com = new SqlCommand {
                CommandText = sourceLevel + " BEGIN TRANSACTION; SELECT Col1 FROM IsolationLevelTestTable; " +
                              "WAITFOR DELAY '00:00:10'; SELECT Col1 FROM IsolationLevelTestTable; COMMIT;"
            };

            var com2 = new SqlCommand { CommandText = "WAITFOR DELAY '00:00:02'; UPDATE IsolationLevelTestTable SET Col1 = 2;" };

            Parallel.Invoke(() => {
                using (var con = new SqlConnection(connectionString)) {
                    con.Open();
                    com.Connection = con;
                    using (var r = com.ExecuteReader()) {
                        while (r.Read()) {
                            res = r.GetInt32(0);
                        }
                        if (r.NextResult()) {
                            while (r.Read()) {
                                res2 = r.GetInt32(0);
                            }
                        }
                    }
                    con.Close();
                }
            },
                () => {
                    using (var con = new SqlConnection(connectionString)) {
                        con.Open();
                        com2.Connection = con;
                        com2.ExecuteNonQuery();
                        con.Close();
                    }
                });
            if (res == 0 || res2 == 0) {
                throw new Exception("Something went wrong");
            }
            return res != res2;
        }

        private static bool PhantomReadError(String connectionString, String sourceLevel) {
            var res = 0;
            var res2 = 0;

            var com = new SqlCommand {
                CommandText = sourceLevel + " BEGIN TRANSACTION; SELECT count(Col1) FROM IsolationLevelTestTable; " +
                              "WAITFOR DELAY '00:00:10'; SELECT count(Col1) FROM IsolationLevelTestTable;  COMMIT;"
            };

            var com2 = new SqlCommand { CommandText = "WAITFOR DELAY '00:00:02'; INSERT INTO IsolationLevelTestTable(Col1) VALUES (1);" };

            Parallel.Invoke(() => {
                using (var con = new SqlConnection(connectionString)) {
                    con.Open();
                    com.Connection = con;
                    using (var r = com.ExecuteReader()) {
                        while (r.Read()) {
                            res = r.GetInt32(0);
                        }
                        if (r.NextResult()) {
                            while (r.Read()) {
                                res2 = r.GetInt32(0);
                            }
                        }
                    }
                    con.Close();
                }
            },
                () => {
                    using (var con = new SqlConnection(connectionString)) {
                        con.Open();
                        com2.Connection = con;
                        com2.ExecuteNonQuery();
                        con.Close();
                    }
                });
            if (res == 0 || res2 == 0) {
                throw new Exception("Something went wrong");
            }
            return res != res2;
        }

        private static void CreateTable(String connectionString) {
            var com = new SqlCommand {
                CommandText = "IF OBJECT_ID('IsolationLevelTestTable') is not null DROP TABLE IsolationLevelTestTable; "+
                "CREATE TABLE IsolationLevelTestTable (Id INT IDENTITY, Col1 INT); " + 
                "INSERT INTO IsolationLevelTestTable(Col1) SELECT (1);"
            };
            try {
                using (var con = new SqlConnection(connectionString)) {
                    con.Open();
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    con.Close();
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private static void DropTable(String connectionString) {
            var com = new SqlCommand {
                CommandText = "IF OBJECT_ID('IsolationLevelTestTable') is not null DROP TABLE IsolationLevelTestTable; "
            };
            try {
                using (var con = new SqlConnection(connectionString)) {
                    con.Open();
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    con.Close();
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }

        }

    }
}
