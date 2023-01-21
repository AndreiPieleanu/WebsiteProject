using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Enums;
using LogicLayer.Models;

namespace LogicLayer.Interfaces
{
    public interface IUser
    {
        public int Id { get; }
        public Credentials Credentials { get; }
        public PersonalDetails PersonalDetails { get; }
        public Privilege Privilege { get; }
    }
}
