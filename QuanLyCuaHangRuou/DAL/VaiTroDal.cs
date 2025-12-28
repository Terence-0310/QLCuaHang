using System.Collections.Generic;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly vai tro
    /// </summary>
    public static class VaiTroDal
    {
        public static List<VaiTro> GetAll() =>
            DbConfig.Use(db => db.VaiTroes.AsNoTracking().OrderBy(x => x.TenVaiTro).ToList());

        public static VaiTro GetById(string maVaiTro) =>
            DbConfig.Use(db => db.VaiTroes.FirstOrDefault(x => x.MaVaiTro == maVaiTro));
    }
}
