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
    
    public partial class Заказы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Заказы()
        {
            this.Поставки_изделий = new HashSet<Поставки_изделий>();
        }
    
        public int Код_заказа { get; set; }
        public Nullable<int> Код_изделия { get; set; }
        public string Наименование_покупателя { get; set; }
        public string ФИО_менеджера { get; set; }
        public System.DateTime Дата { get; set; }
        public int Количество_продукции { get; set; }
        public decimal Стоимость { get; set; }
        public string Телефон_покупателя { get; set; }
        public string Статус { get; set; }
    
        public virtual Изделия Изделия { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Поставки_изделий> Поставки_изделий { get; set; }
    }
}
