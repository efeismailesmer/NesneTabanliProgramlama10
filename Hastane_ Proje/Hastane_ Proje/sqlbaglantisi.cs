using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hastane__Proje
{
    internal class Mysqlbaglantisi
    {
        public MySqlConnection baglanti()
        {
            MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=Hastane_otomasyonu;Uid=root;Pwd='ogrenci'");
            baglan.Open();
            return baglan;
        }
    }
}
