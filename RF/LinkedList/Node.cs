﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RF.Data;

namespace RF.LinkedList
{
    public class Node<TData> 
    {
        public Node<TData> Previous { get; set; }
        public Node<TData> Next { get; set; }
        public TData Value { get; set; }
    }
}
