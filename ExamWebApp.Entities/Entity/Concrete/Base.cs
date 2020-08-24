using ExamWebApp.Entities.Entity.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.Entities.Entity.Concrete
{
    public class Base : ICore
    {
        public int Id { get ; set; }
        private DateTime _transactionTime = DateTime.Now;
        public DateTime TransactionTime { get { return _transactionTime; } set { _transactionTime = value; } }
        private Status _status = Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
