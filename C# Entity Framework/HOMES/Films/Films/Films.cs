//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Films
{
    using System;
    using System.Collections.Generic;
    
    public partial class Films
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> id_genre { get; set; }
    
        public virtual Genres Genres { get; set; }
    }
}
