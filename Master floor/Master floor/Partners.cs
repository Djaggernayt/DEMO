//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Master_floor
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partners
    {
        public Partners()
        {
            this.Partners_product = new HashSet<Partners_product>();
        }
    
        public int ID { get; set; }
        public string Тип_партнера { get; set; }
        public string Наименование_партнера { get; set; }
        public string Директор { get; set; }
        public string Электронная_почта_партнера { get; set; }
        public string Телефон_партнера { get; set; }
        public string Юридический_адрес_партнера { get; set; }
        public Nullable<double> ИНН { get; set; }
        public Nullable<double> Рейтинг { get; set; }
    
        public virtual ICollection<Partners_product> Partners_product { get; set; }
    }
}
