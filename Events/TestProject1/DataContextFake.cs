﻿using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class DataContextFake : IDataContext
    {
        public List<Event> EventList { get; set; }

        public DataContextFake()
        {
            EventList = new List<Event>();

            EventList.Add(new Event { Id = 1, Title = "first event", Start = new DateTime(2023, 11, 04) });
            EventList.Add(new Event { Id = 2, Title = "second event", Start = new DateTime(2023, 11, 10) });
        }
    }

}
