using System;
using System.Collections.Generic;
using System.Text;

namespace TodList.Model
{
    [SQLite.Table("T_Tareas")]
    public class ToDoItem
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }

        public string Nombre { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; } = true;
        public int CategoryID { get; set; }
    }
}
