//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Confectionery_factory
{
    using System;
    using System.Collections.Generic;
    
    public partial class Затраты
    {
        public int Код_затрат { get; set; }
        public int Код_изделия { get; set; }
        public int Код_сырья { get; set; }
        public Nullable<int> Количество_затрат { get; set; }
    
        public virtual Изделия Изделия { get; set; }
        public virtual Сырье Сырье { get; set; }
    }
}
