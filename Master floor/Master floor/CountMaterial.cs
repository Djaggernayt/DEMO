using System;
using System.Linq;

namespace Master_floor
{
    class CountMaterial
    {
        TestBaseEntities db = new TestBaseEntities();
        int CountMaterialExist(int ID_type_product, int ID_type_material, int count_product, float parametr_1, float parametr_2)
        {
            if (parametr_1 < 0)
            {
                return -1;
            }
            if (parametr_2 < 0)
            {
                return -1;
            }

            try
            {
                var coefficient = db.Product_type.FirstOrDefault(x => x.ID == ID_type_product).Коэффициент_типа_продукции;
                var defect = db.Material_type.FirstOrDefault(x => x.ID == ID_type_material).Процент_брака_материала_;
                var count = (parametr_1 * parametr_2) * coefficient * count_product;
                var defect_count = count * defect;
                return Convert.ToInt32(count + defect_count);
            }
            catch
            {
                return -1;
            }
        }
    }
}
