//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassRoomBusyness.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Busyness
    {
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public int IdTeacher { get; set; }
        public int IdClassroom { get; set; }
        public string NumberOfDoublePeriod { get; set; }
        public System.DateTime DateOfClasses { get; set; }
    
        public virtual Classroom Classroom { get; set; }
        public virtual Group Group { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
