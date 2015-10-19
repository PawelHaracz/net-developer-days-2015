/*
Project Orleans Cloud Service SDK ver. 1.0
 
Copyright (c) Microsoft Corporation
 
All rights reserved.
 
MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the ""Software""), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS
OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using TKOrleansInterfaces;

namespace TK_OrleansDemo.Grains
{
    public class Employee : Orleans.Grain, IEmployee
    {
        public Task<int> GetLevel()
        {
            return Task.FromResult(_level);
        }

        public Task Promote(int newLevel)
        {
            _level = newLevel;
            return TaskDone.Done;
        }

        public Task<IManager> GetManager()
        {
            return Task.FromResult(_manager);
        }

        public Task SetManager(IManager manager)
        {
            _manager = manager;
            return TaskDone.Done;
        }

        private int _level;
        private IManager _manager;
        public Task Greeting(IEmployee from, string message)
        {
            Console.WriteLine($"{from.GetPrimaryKey()} said: {message} to {this.GetPrimaryKey()}");
            return TaskDone.Done;
        }

        public Task Do(string message)
        {
            Console.WriteLine($"{_manager.GetPrimaryKey()} - {this.GetPrimaryKey()}: { message}");
            return TaskDone.Done;
        }
    }

    public class Manager : Orleans.Grain, IManager
    {
        public override Task OnActivateAsync()
        {
            //Manager is also employee
            _me = GrainFactory.GetGrain<IEmployee>(this.GetPrimaryKey());
            return base.OnActivateAsync();
        }

        public Task<List<IEmployee>> GetDirectReports()
        {
            return Task.FromResult(_reports);
        }

        public async Task AddDirectReport(IEmployee employee)
        {
            _reports.Add(employee);
            await employee.SetManager(this);
            await employee.Greeting(_me, "Welcome to my team!");
        }


        public Task<IEmployee> AsEmployee()
        {
            return Task.FromResult(_me);
        }

        private IEmployee _me;
        private List<IEmployee> _reports = new List<IEmployee>();

        public Task Order(string message)
        {
            foreach (var item in _reports)
            {
                item.Do(message);
            }
            return TaskDone.Done;
        }
    }


}
