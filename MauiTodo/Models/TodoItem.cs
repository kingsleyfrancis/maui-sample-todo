﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTodo.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public DateTime Due { get; set; }

        public bool Done { get; set; } = false;

        public override string ToString()
        {
            return $"{Title} - {Due:f}";
        }
    }
}
