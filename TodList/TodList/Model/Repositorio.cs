using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TodList.Model
{
   public class Repositorio
    {
        SQLite.SQLiteAsyncConnection DataBase;

        // Constructor que se encarga de crear o abrir
        // la base de datos en el directorio local de
        // la plataforma.
        public Repositorio()
        {
            string DbFilePath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "ToDoItemDb.db");

            // Crear la conexion a la BD.
            DataBase = new SQLite.SQLiteAsyncConnection(DbFilePath);
            // Crear tabla ToDoItem.
            DataBase.CreateTableAsync<Model.ToDoItem>().Wait();
            
        }

        // Crear las operaciones CRUD

        public Task<int> CreateToDoItemAsync(Model.ToDoItem toDoItem)
        {
            return DataBase.InsertAsync(toDoItem);
        }

        public Task<Model.ToDoItem> GetToDoItemByIDAsync(int id)
        {
            // select * from table where id == @id
            return DataBase.Table<ToDoItem>().Where(ti => ti.ID == id).
                FirstOrDefaultAsync();
        }

        public Task<int> UpdateToDoItemAsync(ToDoItem toDoItem)
        {
            return DataBase.UpdateAsync(toDoItem);
        }
    
        public Task<int> DeleteToDoItemAsyn(ToDoItem toDoItem)
        {
            return DataBase.DeleteAsync(toDoItem);
        }

        public Task<List<ToDoItem>> GetToDoItemsAsync()
        {
            // select * from ToDoITemDB
            return DataBase.Table<ToDoItem>().ToListAsync();
        }

        public Task<List<ToDoItem>> GetToDoItemsByCategoryIDAsync(int idCategory)
        {
            return DataBase.QueryAsync<ToDoItem>(
                $"SELECT * FROM [T_Tareas] WHERE [CategoryID] = {idCategory}");
        }
    }
}
