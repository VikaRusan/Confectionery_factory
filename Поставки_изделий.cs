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
    
    public partial class Поставки_изделий
    {
        public int Код_пост_изд { get; set; }
        public int Код_заказа { get; set; }
        public string Организация_поставщика { get; set; }
        public string Телефон_поставщика { get; set; }
        public string Адрес_покупателя { get; set; }
        public Nullable<System.DateTime> Дата_поставки { get; set; }
        public string Статус { get; set; }
    
        public virtual Заказы Заказы { get; set; }
    }
}
