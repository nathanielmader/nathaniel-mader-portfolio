using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using DvdLib.Models;

namespace DvdLib.Data
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void CreateDvd(Dvd info)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //First value(DvdId) is output parameter
                //Cant use AddWithValue for something that is already output parameter
                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                //Set parameter to output
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Title", info.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", info.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", info.Director);
                cmd.Parameters.AddWithValue("@Rating", info.Rating);
                if (info.Notes != null)
                {
                    cmd.Parameters.AddWithValue("@Notes", info.Notes);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Notes", info.Notes).Value = DBNull.Value;
                }

                cn.Open();
                cmd.ExecuteNonQuery();

                //Need to get output parameter back into dvd object
                info.DvdId = (int)param.Value;
            }
        }

        public void DeleteDvd(int DvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", DvdId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetAllDvds()
        {
            List<Dvd> dvd = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllDvds", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvd.Add(currentRow);
                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetDvdByDirector(string director)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", director);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public Dvd GetDvdByID(int DvdId)
        {
            //If not found, return null
            Dvd dvd = null;

            //Creeate Connection
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Database Stored Procedure
                SqlCommand cmd = new SqlCommand("GetDvdById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", DvdId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Director = dr["Director"].ToString();
                        dvd.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            dvd.Notes = dr["Notes"].ToString();
                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetDvdByRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", rating);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetDvdByReleaseYear(int releaseYear)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByReleaseYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetDvdByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", title);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public void UpdateDvd(Dvd info)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", info.DvdId);
                cmd.Parameters.AddWithValue("@Title", info.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", info.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", info.Director);
                cmd.Parameters.AddWithValue("@Rating", info.Rating);
                cmd.Parameters.AddWithValue("@Notes", info.Notes);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
