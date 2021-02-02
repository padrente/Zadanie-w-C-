using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Dapper;

namespace MenagerApp
{
    class DataAccess
    {

        public void DodajPracownika(string surname, string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConDB("CwiczeniaDB"))) 
            {
                List<DataAccess> pracownicy = new List<DataAccess>();

                connection.Query<Person>($"insert into pracownik values('{surname}', '{name}');");
                var idObj = connection.Query<Person>($"select id from pracownik where nazwisko like '{surname}' and imie like '{name}';");
                
            }
        }

        public void AktPracownika(string surname, string name, string idPracownika )
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConDB("CwiczeniaDB")))
            {
                connection.Query<Person>($"update pracownik set nazwisko = '{surname}', imie = '{name}' where id = {idPracownika};");
            }
        }

        public void UsunPracownika(string idPracownika)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConDB("CwiczeniaDB")))
            {
                connection.Query<Person>($"delete from pracownik where id = {idPracownika};");
            }
        }

        public List<Person> WysPracownikow()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConDB("CwiczeniaDB")))
            {
                var output = connection.Query<Person>($"select pracownik.id, pracownik.nazwisko, pracownik.imie, pracownik_dane.okres, pracownik_dane.wynagr from pracownik inner join pracownik_dane on pracownik.id = pracownik_dane.id_pracownika;").ToList();
                return output;
            }
        }

    }
}
