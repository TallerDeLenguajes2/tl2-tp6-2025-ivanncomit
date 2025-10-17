using Microsoft.Data.Sqlite;
string connectionString = "Data Source=Tienda.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Consulta: Crear Tabla si no existe
    string createTableQuery = "CREATE TABLE IF NOT EXISTS Productos (id INTEGER PRIMARY KEY, nombre TEXT, precio REAL)";

    //proceso de creado
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }
    
    // Insertar datos
    string insertQuery = "INSERT INTO productos (Descripcion, Precio) VALUES ('Manzana', 0.50), ('Banana', 0.30)";

    //proceso de insertado
    using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
    {
        insertCmd.ExecuteNonQuery();
        Console.WriteLine("Datos insertados en la tabla 'Productos'.");
    }

    // Leer/Agarrar todos los datos
    string selectQuery = "SELECT * FROM Productos";

    //proceso de consulta de seleccion
    using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
    //proceso de lectura de la seleccion
    using (SqliteDataReader reader = selectCmd.ExecuteReader())
    {
        Console.WriteLine("Datos en la tabla 'Productos':");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["idProducto"]}, Descripcion: {reader["Descripcion"]}, Precio: {reader["Precio"]}");
        }
    }

    //finalizar conexion con db
    connection.Close();
}