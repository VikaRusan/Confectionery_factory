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
    
    public partial class Сырье
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Сырье()
        {
            this.Затраты = new HashSet<Затраты>();
            this.Поставки_сырья = new HashSet<Поставки_сырья>();
        }
    
        public int Код_сырья { get; set; }
        public string Вид { get; set; }
        public Nullable<decimal> Цена_кг_шт { get; set; }
        public Nullable<decimal> Фасовка { get; set; }
        public string Единица_измерения { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Затраты> Затраты { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Поставки_сырья> Поставки_сырья { get; set; }
    }
}
