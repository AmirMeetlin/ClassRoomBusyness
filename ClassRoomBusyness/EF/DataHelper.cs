using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomBusyness.EF
{
    public partial class Teacher
    {
        public string FIO { get => $"{FirstName} {SecondName} {Patronymic}"; }
    }
}

