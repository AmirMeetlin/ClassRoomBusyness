using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomBusyness.ClassHelper
{
    class DataTransmission
    {
            public static EF.Group GetGroup { get; set; }
            public static EF.Teacher GetTeacher { get; set; }

            public static EF.Classroom GetClassroom { get; set; }
       
    }
}
