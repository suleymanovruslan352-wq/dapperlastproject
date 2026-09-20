using Dapper;
using Microsoft.Data.SqlClient;


namespace dapperlastproject
{
    

    public class ProductRepository
    {
        private readonly string connectionString =
            "Server=.\\SQLEXPRESS;Database=EFcore1;Trusted_Connection=True;TrustServerCertificate=True;";

        public void BulkInsert(List<Product> products)
        {
            using var connection = new SqlConnection(connectionString);

            string sql = @"
            INSERT INTO Products (Name, Category, Price, Stock)
            VALUES (@Name, @Category, @Price, @Stock);";


            foreach (var product in products)
            {
                connection.Execute(sql, product);
            }
        }


        public void BulkUpdate()
        {
            using var connection = new SqlConnection(connectionString);

            string sql = @"
            UPDATE Products
            SET Price = Price * 1.10;
        ";

            connection.Execute(sql);
        }


        public void BulkDelete()
        {
            using var connection = new SqlConnection(connectionString);

            string sql = @"
            DELETE FROM Products
            WHERE Stock = 0;
        ";

            connection.Execute(sql);
        }


        public void BulkMerge(Product product)
        {
            using var connection = new SqlConnection(connectionString);

            string sql = @"
            IF EXISTS (SELECT 1 FROM Products WHERE Id = @Id)
            BEGIN
                UPDATE Products
                SET
                    Name = @Name,
                    Category = @Category,
                    Price = @Price,
                    Stock = @Stock
                WHERE Id = @Id;
            END
            ELSE
            BEGIN
                INSERT INTO Products (Name, Category, Price, Stock)
                VALUES (@Name, @Category, @Price, @Stock);
            END
        ";


            connection.Execute(sql, product);
        }
    }
}
