using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2_1;

namespace Infrastructure
{
    public class PersonKartotekDBUtil
    {
        private Person currentPerson;

        public PersonKartotekDBUtil()
        {
            currentPerson = new Person()
            {
                _PersonID = 0,
                _ForNavn = "",
                _MellemNavn = "",
                _EfterNavn = "",
                _PersonType = "",
                _Noter = null,
                _Adresser = null,
                _Email = null,
                _Telefon = null,
                _AA = null,
            };
        }

        #region SQL
        private SqlConnection OpenConnection
        {
            get
            {
                var con = new SqlConnection(
                @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Database_Handin2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                
                //var con = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=E18I4DABau556770;User ID=E18I4DABau556770;Password=E18I4DABau556770;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                con.Open();
                return con;
            }
        }
        #endregion
        
        #region Person
        public void AddPerson(ref Person p)
        {
            string insertStringParam = @"INSERT INTO [Person] (_ForNavn, _MellemNavn, _EfterNavn, _PersonType, _Noter, _Telefon, _Email, _Adresser)
                                        OUTPUT INSERTED._PersonID
                                        VALUES (@_ForNavn, @_MellemNavn, @_EfterNavn, @_PersonType, @_Noter, @_Telefon, @_Email, @_Adresser)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_ForNavn", p._ForNavn);
                cmd.Parameters.AddWithValue("@_MellemNavn", p._MellemNavn);
                cmd.Parameters.AddWithValue("@_EfterNavn", p._EfterNavn);
                cmd.Parameters.AddWithValue("@_PersonType", p._PersonType);
                cmd.Parameters.AddWithValue("@_Noter", p._Noter);
                cmd.Parameters.AddWithValue("@_Telefon", p._Telefon);
                cmd.Parameters.AddWithValue("@_Email", p._Email);
                cmd.Parameters.AddWithValue("@_Adresser", p._Adresser);
                p._PersonID = (long) cmd.ExecuteScalar();
            }
        }

        public void UpdatePersonDB(ref Person p)
        {
            string updateString =
                @"UPDATE Person
                        SET _ForNavn = @_ForNavn, _MellemNavn = @_MellemNavn, _EfterNavn = @_EfterNavn, _PersonType = @_PersonType
                        WHERE _PersonID = @_PersonID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_ForNavn", p._ForNavn);
                cmd.Parameters.AddWithValue("@_MellemNavn", p._MellemNavn);
                cmd.Parameters.AddWithValue("@_EfterNavn", p._EfterNavn);
                cmd.Parameters.AddWithValue("@_PersonType", p._PersonType);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePersonDB(ref Person p)
        {
            string deleteString = @"DELETE FROM Person WHERE (_PersonID = @_PersonID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_PersonID", p._PersonID);

                var id = (long) cmd.ExecuteNonQuery();
                p = null;
            }
        }

        public void GetPersonByName(ref Person p)
        {
            string sqlcmd = @"SELECT TOP 1 * FROM Person WHERE (_ForNavn = @fNavn) AND (_MellemNavn = @mNavn) AND (_EfterNavn = @eNavn)";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@fNavn", p._ForNavn);
                cmd.Parameters.AddWithValue("@mNavn", p._MellemNavn);
                cmd.Parameters.AddWithValue("@eNavn", p._EfterNavn);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    currentPerson._PersonID = (long) rdr["_PersonID"];
                    currentPerson._PersonType = (string) rdr["_PersonType"];
                    currentPerson._ForNavn = (string) rdr["_ForNavn"];
                    currentPerson._MellemNavn = (string) rdr["_MellemNavn"];
                    currentPerson._EfterNavn = (string) rdr["_EfterNavn"];
                    p = currentPerson;
                }
            }
        }

        public void GetPersonByID(ref Person p)
        {
            string sqlcmd =
                @"SELECT [_ForNavn], [_MellemNavn], [_EfterNavn], [_PersonType] FROM Person WHERE ([_PersonID] = @_PersonID)";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_PersonID", p._PersonID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    currentPerson._PersonID = p._PersonID;
                    currentPerson._ForNavn = (string) rdr["_ForNavn"];
                    currentPerson._MellemNavn = (string) rdr["_MellemNavn"];
                    currentPerson._EfterNavn = (string) rdr["_EfterNavn"];
                    currentPerson._PersonType = (string) rdr["_PersonType"];
                    p = currentPerson;
                }
            }
        }

        public List<Person> GetPersons()
        {
            string sqlcmd = @"SELECT * FROM Person";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                List<Person> per = new List<Person>();
                Person p = null;
                while (rdr.Read())
                {
                    p = new Person
                    {
                        _PersonID = (long)rdr["_PersonID"],
                        _ForNavn = (string)rdr["_ForNavn"],
                        _MellemNavn = (string)rdr["_MellemNavn"],
                        _EfterNavn = (string)rdr["_EfterNavn"],
                        _PersonType = (string)rdr["_PersonType"]
                    };
                    per.Add(p);
                }

                return per;
            }
        }

        public List<Adresse> GetPersoner_Adresse(ref Person p)
        {
            string selectAdresseToolString = @"SELECT * FROM [Adresse] WHERE ([Person] = @PId";
            using (var cmd = new SqlCommand(selectAdresseToolString, OpenConnection))
            {
                SqlDataReader rdr = null;
                cmd.Parameters.AddWithValue("@PId", p._PersonID);
                rdr = cmd.ExecuteReader();
                List<Adresse> AdresseP = new List<Adresse>();
                Adresse A = null;
                while (rdr.Read())
                {
                    A = new Adresse
                    {
                        _AdresseID = (long)rdr["_AdresseID"],
                        _AdresseType = (string)rdr["_AdresseType"],
                        _GadeNavn = (string)rdr["_Gade"],
                        _GadeNummer = (string)rdr["_GadeNummer"]
                    };

                    AdresseP.Add(A);

                }

                return AdresseP;
            }
        }
        #endregion

        public List<ZIP> GetZIP_i_Adresse(ref Adresse A)
        {
            string selectAdresseToolString = @"SELECT * FROM ZIP WHERE (Adresse = _AdresseID";
            using (var cmd = new SqlCommand(selectAdresseToolString, OpenConnection))
            {
                SqlDataReader rdr = null;
                cmd.Parameters.AddWithValue("@_AdresseID", A._AdresseID);
                rdr = cmd.ExecuteReader();
                List<ZIP> lort = new List<ZIP>();
                ZIP zip = null;
                while (rdr.Read())
                {
                    zip = new ZIP
                    {
                        _ZipID = (long)rdr["_ZipID"],
                        _Land = (string)rdr["_Land"],
                        _By = (string)rdr["_By"],
                        _PostNummer = (string)rdr["_PostNummer"]
                    };

                    lort.Add(zip);
                }

                return lort;
            }
        }

        #region Adresse
        public void AddAdresseDB(ref Adresse Adr)
        {
            string insertStringParam = @"INSERT INTO [Adresse] (_AdresseType, _GadeNavn, _GadeNummer, _By, _ZipID)
                                                    OUTPUT INSERTED._AdresseID
                                                    VALUES (@_AdresseType, @_GadeNavn, @_GadeNummer, @_By, @_ZipID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_AdresseType", Adr._AdresseType);
                cmd.Parameters.AddWithValue("@_GadeNavn", Adr._GadeNavn);
                cmd.Parameters.AddWithValue("@_GadeNummer", Adr._GadeNummer);
                cmd.Parameters.AddWithValue("@_ZipID", Adr._ZipID);
                cmd.Parameters.AddWithValue("@_By", Adr._By);

                Adr._AdresseID = (long) cmd.ExecuteScalar();
            }
        }

        public void GetAdresseById(ref Adresse Adr)
        {
            string sqlcmd = @"SELECT * FROM Adresse WHERE (_AdresseID = @_AdresseID)";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_AdresseID", Adr._AdresseID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Adr._AdresseID = (long) rdr["_AdresseID"];
                    Adr._AdresseType = (string) rdr["_AdresseType"];
                    Adr._GadeNavn = (string) rdr["_Gade"];
                    Adr._GadeNummer = (string) rdr["_GadeNummer"];
                    Adr._ZipID = (long) rdr["_ZipID"];
                }
            }
        }

        public void UpdateAdresse(ref Adresse Adr)
        {
            string updateString =
                @"UPDATE Adresse
                        SET _AdresseType = @_AdresseType, _GadeNavn = @_GadeNavn, _GadeNummer = @_GadeNummer, _By = @_By, _ZipID = @_ZipID
                        WHERE _AdresseID = @_AdresseID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_AdresseType", Adr._AdresseType);
                cmd.Parameters.AddWithValue("@_GadeNavn", Adr._GadeNavn);
                cmd.Parameters.AddWithValue("@_GadeNummer", Adr._GadeNummer);
                cmd.Parameters.AddWithValue("@_ZipID", Adr._ZipID);
                cmd.Parameters.AddWithValue("@_AdresseID", Adr._AdresseID);
                cmd.Parameters.AddWithValue("@_By", Adr._By);

                var id = (long) cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAdresseDB(ref Adresse Adr)
        {
            string deleteString = @"DELETE FROM Adresse WHERE (_AdresseID = @_AdresseID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_AdresseID", Adr._AdresseID);

                var id = (long) cmd.ExecuteNonQuery();
                Adr = null;
            }
        }
        #endregion

        #region ZIP
        public void AddZipDB(ref ZIP zp)
        {
            string insertStringParam = @"INSERT INTO [ZIP] (_Land, _By, _PostNummer, _ZIPListeID)
                                                            OUTPUT INSERTED._ZipID
                                                            VALUES (@_Land, @_By, @_PostNummer, @_ZIPListeID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_Land", zp._Land);
                cmd.Parameters.AddWithValue("@_By", zp._By);
                cmd.Parameters.AddWithValue("@_PostNummer", zp._PostNummer);
                cmd.Parameters.AddWithValue("@_ZIPListeID", zp._ZIPListeID);
                zp._ZipID = (long) cmd.ExecuteScalar();
            }
        }

        public void GetZIPByID(ref ZIP zp) //Virker ikke - Aner ikke hvorfor
        {
            string sqlcmd = @"SELECT * FROM ZIP WHERE (_ZipID = @_ZipID)";
            using (SqlCommand cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_ZipID", zp._ZipID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                }
            }
        }

        public void UpdateZIPDB(ref ZIP zp)
        {
            string updateString =
                @"UPDATE ZIP
                         SET _Land = @_Land, _By = @_By, _PostNummer = @_PostNummer, _ZIPListeID = @_ZIPListeID
                         WHERE _ZipID = @_ZipID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_Land", zp._Land);
                cmd.Parameters.AddWithValue("@_By", zp._By);
                cmd.Parameters.AddWithValue("@_PostNummer", zp._PostNummer);
                cmd.Parameters.AddWithValue("@_ZIPListeID", zp._ZIPListeID);
                cmd.Parameters.AddWithValue("@_ZipID", zp._ZipID);
                var id = (long) cmd.ExecuteNonQuery();
            }
        }

        public void DeleteZIPDB(ref ZIP zp)
        {
            string deleteString = @"DELETE FROM ZIP WHERE (_ZipID = @_ZipID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_ZipID", zp._ZipID);

                var id = (long) cmd.ExecuteNonQuery();
                zp = null;
            }
        }
        #endregion

        #region ZIPListe
        public List<ZIPListe> GetZipListDB(ref ZIPListe zl)  //Virker ikke
        {
            string selectZIPListString = @"SELECT *
                                                FROM ZIPListe
                                                WHERE (_ZIPListeID = @_ZIPListeID)";

            using (var cmd = new SqlCommand(selectZIPListString, OpenConnection))
            {
                SqlDataReader rdr = null;
                cmd.Parameters.AddWithValue("@_ZIPListeID", zl._ZIPListeID);
                rdr = cmd.ExecuteReader();
                List<ZIPListe> zliste = new List<ZIPListe>();
                ZIPListe zip = null;
                while (rdr.Read())
                {
                    zip._ZIPListeID = (long) rdr["_ZIPListeID"];
                    zip._Land = (string) rdr["_Land"];
                    zip._By = (string) rdr["_By"];
                    zip._PostNummer = (string) rdr["_PostNummer"];
                    zliste.Add(zip);
                }

                return zliste;
            }
        }

        public void AddZIPListeDB(ref ZIPListe zl)
        {
            string insertStringParam = @"INSERT INTO [ZIPListe] (_Land, _By, _PostNummer)
                                                    OUTPUT INSERTED._ZIPListeID
                                                    VALUES (@_Land, @_By, @_PostNummer)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_Land", zl._Land);
                cmd.Parameters.AddWithValue("@_By", zl._By);
                cmd.Parameters.AddWithValue("@_PostNummer", zl._PostNummer);
                zl._ZIPListeID = (long)cmd.ExecuteScalar();
            }
        }

        public void UpdateZipListeDB(ref ZIPListe zl)
        {
            string updateString = @"UPDATE ZIPListe
                                           SET _Land = @_Land, _By = @_By, _PostNummer = @_PostNummer
                                           WHERE _ZIPListeID = @_ZIPListeID";

            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_Land", zl._Land);
                cmd.Parameters.AddWithValue("@_By", zl._By);
                cmd.Parameters.AddWithValue("@_PostNummer", zl._PostNummer);
                cmd.Parameters.AddWithValue("@_ZIPListeID", zl._ZIPListeID);

                var id = (long) cmd.ExecuteNonQuery();
            }
        }

        public void DeleteZipListeDB(ref ZIPListe zl)
        {
            string deleteString = @"DELETE FROM ZIPListe WHERE (_ZIPListeID = @_ZIPListeID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_ZIPListeID", zl._ZIPListeID);

                var id = (long) cmd.ExecuteNonQuery();
                zl = null;
            }
        }
        #endregion

        #region Noter
        public void AddNoterDB(ref Noter note)
        {
            string insertStringParam = @"INSERT INTO [Noter] (_Noter)
                                                        OUTPUT INSERTED._NoteID
                                                        VALUES (@_Noter)";
            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_Noter", note._Noter);
                note._NoteID= (long)cmd.ExecuteScalar();
            }
        }

        public void GetNoterByID(ref Noter note)
        {
            string sqlcmd = @"SELECT * FROM Noter WHERE (_NoteID= @_NoteID)";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_NoteID", note._NoteID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    note._NoteID = (long)rdr["_NoteID"];
                    note._Noter = (string)rdr["_Noter"];
                }
            }
        }

        public void UpdateNoterDB(ref Noter note)
        {
            string updateString = @"Noter
                                    SET _Noter = @_Noter
                                    WHERE _NoteID = @_NoteID";
            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_Noter", note._Noter);
                var id = (long)cmd.ExecuteNonQuery();
            }
        }

        public void DeleteNoterDB(ref Noter note)
        {
            string deleteString = @"DELETE FROM Noter WHERE (_NoteID = @_NoteID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_NoteID", note._NoteID);

                var id = (long)cmd.ExecuteNonQuery();
                note = null;
            }
        }
        #endregion

        #region Telefon
        public void AddTelefonDB(ref Telefon tlf)
        {
            string insertStringParam = @"INSERT INTO [Telefon] (_TeleSelskab, _TelefonType, _Nummer, _PersonID)
                                                        OUTPUT INSERTED._TelefonID
                                                        VALUES (@_TeleSelskab, @_TelefonType, @_Nummer, @_PersonID)";
            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_TeleSelskab", tlf._TeleSelskab);
                cmd.Parameters.AddWithValue("@_TelefonType", tlf._TelefonType);
                cmd.Parameters.AddWithValue("@_Nummer", tlf._Nummer);
                cmd.Parameters.AddWithValue("@_PersonID", tlf._PersonID);
                tlf._TelefonID = (long)cmd.ExecuteScalar();
            }
        }

        public void GetTelefonByID(ref Telefon tlf)
        {
            string sqlcmd = @"SELECT * FROM Telefon WHERE (_TelefonID= @_TelefonID)";
            using (var cmd = new SqlCommand(sqlcmd, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_NoteID", tlf._TelefonID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    tlf._TelefonID = (long)rdr["_TelefonID"];
                    tlf._TeleSelskab = (string)rdr["_TeleSelskab"];
                    tlf._TelefonType = (string) rdr["_TelefonType"];
                    tlf._Nummer = (string) rdr["_Nummer"];
                }
            }
        }

        public void UpdateTelefonDB(ref Telefon tlf)
        {
            string updateString = @"UPDATE Telefon
                                    SET _TeleSelskab = @_TeleSelskab, _TelefonType = @_TelefonType, _Nummer = @_Nummer
                                    WHERE _TelefonID = @_TelefonID";
            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_TeleSelskab", tlf._TeleSelskab);
                cmd.Parameters.AddWithValue("@_TelefonType", tlf._TelefonType);
                cmd.Parameters.AddWithValue("@_Nummer", tlf._Nummer);
                cmd.Parameters.AddWithValue("@_TelefonID", tlf._TelefonID);
                var id = (long)cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTelefonDB(ref Telefon tlf)
        {
            string deleteString = @"DELETE FROM Telefon WHERE (_TelefonID = @_TelefonID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_TelefonID", tlf._TelefonID);

                var id = (long)cmd.ExecuteNonQuery();
                tlf= null;
            }
        }
        #endregion

        #region Email
        public void AddEmailDB(ref Email em)
        {
            string insertStringParam = @"INSERT INTO [Email] (_EmailAdresse)
                                                        OUTPUT INSERTED._EmailID
                                                        VALUES (@_EmailAdresse)";
            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_TeleSelskab", em._EmailAdresse);
                em._EmailID = (int)cmd.ExecuteScalar();
            }
        }

        public void GetEmailByID(ref Email em)
        {
            string insertStringParam = @"INSERT INTO [Email] (_EmailAdresse)
                                                        OUTPUT INSERTED._EmailID
                                                        VALUES (@_EmailAdresse)";
            using (SqlCommand cmd = new SqlCommand(insertStringParam, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_TeleSelskab", em._EmailAdresse);
                em._EmailID= (long)cmd.ExecuteScalar();
            }
        }

        public void UpdateEmailDB(ref Email em)
        {
            string updateString = @"Email
                                    SET _EmailAdresse = @_EmailAdresse
                                    WHERE _EmailID = @_EmailID";
            using (SqlCommand cmd = new SqlCommand(updateString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_EmailAdresse", em._EmailAdresse);

                var id = (long)cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmailDB(ref Email em)
        {
            string deleteString = @"DELETE FROM Email WHERE (_EmailID = @_EmailID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, OpenConnection))
            {
                cmd.Parameters.AddWithValue("@_EmailID", em._EmailID);

                var id = (long)cmd.ExecuteNonQuery();
                em = null;
            }
        }
        #endregion

        public void GetFullTreePersonDB(ref Person fp)
        {
            
        }
    }
}
