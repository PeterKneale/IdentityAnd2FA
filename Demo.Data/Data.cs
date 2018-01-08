using System;
using Dapper;

namespace Demo.Data
{
    public interface IData
    {
        Guid Id { get; set; }
    }

    public class Data : IData
    {
        [Key]
        public Guid Id { get; set; }
    }
}